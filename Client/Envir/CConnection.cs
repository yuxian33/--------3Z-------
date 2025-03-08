using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Windows.Forms;
using Client.Controls;
using Client.Models;
using Client.Scenes;
using Client.Scenes.Views;
using Library.Network;
using Library;
using Library.SystemModels;
using G = Library.Network.GeneralPackets;
using S = Library.Network.ServerPackets;
using C = Library.Network.ClientPackets;
using Library.Network.ServerPackets;
using TreasureChest = Library.Network.ServerPackets.TreasureChest;
using Library.Network.ClientPackets;
using MarketPlaceHistory = Library.Network.ServerPackets.MarketPlaceHistory;




namespace Client.Envir
{
    public sealed class CConnection : BaseConnection
    {

        protected override TimeSpan TimeOutDelay => Config.TimeOutDuration;

        public bool ServerConnected { get; set; }

        public int Ping;

        private DateTime _protecttime;

        public CConnection(TcpClient client)
            : base(client)
        {
            OnException += (o, e) => CEnvir.SaveError(e.ToString());

            UpdateTimeOut();

            AdditionalLogging = true;

            BeginReceive();
        }

        public override void TryDisconnect()
        {
            Disconnect();
        }

        public override void Disconnect()
        {
            base.Disconnect();

            if (CEnvir.Connection == this)
            {
                CEnvir.Connection = null;

                LoginScene scene = DXControl.ActiveScene as LoginScene;
                if (scene != null)
                {
                    scene.Disconnected();
                }
                else
                {
                    DXMessageBox.Show("与服务器断开连接\n原因：连接超时.", "已断开连接", DialogAction.ReturnToLogin);
                }
            }

            CEnvir.Storage = null;
            
        }
        public override void TrySendDisconnect(Packet p)
        {
            SendDisconnect(p);
        }

        public void Process(G.Disconnect p)
        {
            Disconnecting = true;

            LoginScene scene = DXControl.ActiveScene as LoginScene;

            if (scene != null)
            {
                if (p.Reason == DisconnectReason.WrongVersion)
                {
                    CEnvir.WrongVersion = true;
                    
                    DXMessageBox.Show("与服务器断开连接\n原因：版本错误.", "已断开连接", DialogAction.Close).Modal = false;
                }

                scene.Disconnected();
                return;
            }


            switch (p.Reason)
            {
                case DisconnectReason.Unknown:
                    DXMessageBox.Show("与服务器断开连接\n原因：未知", "已断开连接", DialogAction.ReturnToLogin);
                    break;
                case DisconnectReason.TimedOut:
                    DXMessageBox.Show("与服务器断开连接\n原因：连接超时.", "已断开连接  断开时间：" + (object)Time.Now, DialogAction.ReturnToLogin);
                    break;
                case DisconnectReason.ServerClosing:
                    DXMessageBox.Show("与服务器断开连接\n原因：服务器关闭.", "已断开连接", DialogAction.ReturnToLogin);
                    break;
                case DisconnectReason.AnotherUser:
                    DXMessageBox.Show("与服务器断开连接\n原因：其他用户登录了您的帐户.", "已断开连接", DialogAction.ReturnToLogin);
                    break;
                case DisconnectReason.AnotherUserAdmin:
                    DXMessageBox.Show("与服务器断开连接\n原因：管理员已登录您的帐户.", "已断开连接", DialogAction.ReturnToLogin);
                    break;
                case DisconnectReason.Banned:
                    DXMessageBox.Show("与服务器断开连接\n原因：你已被封禁.", "已断开连接", DialogAction.ReturnToLogin);
                    break;
                case DisconnectReason.Crashed:
                    DXMessageBox.Show("与服务器断开连接\n原因：服务器崩溃.", "已断开连接", DialogAction.ReturnToLogin);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (this == CEnvir.Connection)
                CEnvir.Connection = null;
        }
        public void Process(G.Connected p)
        {
            Enqueue(new G.Connected());
            ServerConnected = true;

        }
        public void Process(G.CheckVersion p)
        {
            byte[] clientHash;
            using (MD5 md5 = MD5.Create())
            {
                using (FileStream stream = File.OpenRead(Application.ExecutablePath))
                    clientHash = md5.ComputeHash(stream);
            }

            Enqueue(new G.Version { ClientHash = clientHash });
        }
        public void Process(G.GoodVersion p)
        {
            LoginScene scene = DXControl.ActiveScene as LoginScene;
            scene?.ShowLogin();

            Enqueue(new C.SelectLanguage { Language = Config.Language });
        }
        public void Process(G.Ping p)
        {
            Enqueue(new G.Ping());
        }
        public void Process(G.PingResponse p)
        {
            Ping = p.Ping;
        }

        public void Process(S.NewAccount p)
        {
            LoginScene login = DXControl.ActiveScene as LoginScene;
            if (login == null) return;

            login.AccountBox.CreateAttempted = false;

            switch (p.Result)
            {
                case NewAccountResult.Disabled:
                    login.AccountBox.Clear();
                    DXMessageBox.Show("帐户创建目前已停用.", "帐户创建");
                    break;
                case NewAccountResult.BadEMail:
                    login.AccountBox.EMailTextBox.SetFocus();
                    DXMessageBox.Show("E-Mail地址格式错误.", "帐户创建");
                    break;
                case NewAccountResult.BadPassword:
                    login.AccountBox.Password1TextBox.SetFocus();
                    DXMessageBox.Show("密码格式错误.", "帐户创建");
                    break;
                case NewAccountResult.BadRealName:
                    login.AccountBox.RealNameTextBox.SetFocus();
                    DXMessageBox.Show("真实姓名格式错误.", "帐户创建");
                    break;
                case NewAccountResult.AlreadyExists:
                    login.AccountBox.EMailTextBox.TextBox.Text = string.Empty;
                    login.AccountBox.EMailTextBox.SetFocus();
                    DXMessageBox.Show("E-Mail地址已被使用.", "帐户创建");
                    break;
                case NewAccountResult.BadReferral:
                    login.AccountBox.ReferralTextBox.SetFocus();
                    DXMessageBox.Show("推荐人的E-Mail地址错误.", "帐户创建");
                    break;
                case NewAccountResult.ReferralNotFound:
                    login.AccountBox.ReferralTextBox.SetFocus();
                    DXMessageBox.Show("找不到推荐人的E-Mail地址.", "帐户创建");
                    break;
                case NewAccountResult.ReferralNotActivated:
                    login.AccountBox.EMailTextBox.SetFocus();
                    DXMessageBox.Show("推荐人的E-Mail地址没有被激活.", "帐户创建");
                    break;
                case NewAccountResult.Success:
                    login.LoginBox.EMailTextBox.TextBox.Text = login.AccountBox.EMailTextBox.TextBox.Text;
                    login.LoginBox.PasswordTextBox.TextBox.Text = login.AccountBox.Password1TextBox.TextBox.Text;
                    login.AccountBox.Clear();
                    DXMessageBox.Show("您的帐户已成功创建.\n" +
                                      "请按照发送到您的电子邮件说明进行激活.", "帐户创建");
                    break;
            }

        }
        public void Process(S.ChangePassword p)
        {
            LoginScene login = DXControl.ActiveScene as LoginScene;
            if (login == null) return;

            login.ChangeBox.ChangeAttempted = false;

            switch (p.Result)
            {
                case ChangePasswordResult.Disabled:
                    login.ChangeBox.Clear();
                    DXMessageBox.Show("系统禁止修改密码.", "修改密码");
                    break;
                case ChangePasswordResult.BadEMail:
                    login.ChangeBox.EMailTextBox.SetFocus();
                    DXMessageBox.Show("E-Mail格式错误.", "修改密码");
                    break;
                case ChangePasswordResult.BadCurrentPassword:
                    login.ChangeBox.CurrentPasswordTextBox.SetFocus();
                    DXMessageBox.Show("当前密码格式错误.", "修改密码");
                    break;
                case ChangePasswordResult.BadNewPassword:
                    login.ChangeBox.NewPassword1TextBox.SetFocus();
                    DXMessageBox.Show("新密码格式错误.", "修改密码");
                    break;
                case ChangePasswordResult.AccountNotFound:
                    login.ChangeBox.EMailTextBox.SetFocus();
                    DXMessageBox.Show("账号不存在.", "修改密码");
                    break;
                case ChangePasswordResult.AccountNotActivated:
                    login.ShowActivationBox(login.ChangeBox);
                    break;
                case ChangePasswordResult.WrongPassword:
                    login.ChangeBox.CurrentPasswordTextBox.SetFocus();
                    DXMessageBox.Show("密码错误.", "修改密码");
                    break;
                case ChangePasswordResult.Banned:
                    DateTime expiry = CEnvir.Now.Add(p.Duration);
                    DXMessageBox box = DXMessageBox.Show($"此帐户已被禁止登录.\n\n原因: {p.Message}\n" +
                                                         $"到期日: {expiry}\n" +
                                                         $"持续时间: {Math.Floor(p.Duration.TotalHours):#,##0} 小时, {p.Duration.Minutes} 分钟, {p.Duration.Seconds} 秒", "更改密码");

                    box.ProcessAction = () =>
                    {
                        if (CEnvir.Now > expiry)
                        {
                            if (login.ChangeBox.CanChange)
                                login.ChangeBox.Change();
                            box.ProcessAction = null;
                            return;
                        }

                        TimeSpan remaining = expiry - CEnvir.Now;

                        box.Label.Text = $"此帐户已被禁止登录.\n\n" +
                                         $"原因: {p.Message}\n" +
                                         $"到期日: {expiry}\n" +
                                         $"持续时间: {Math.Floor(p.Duration.TotalHours):#,##0} 小时, {p.Duration.Minutes} 分钟, {p.Duration.Seconds} 秒"  ;
                    };
                    break;
                case ChangePasswordResult.Success:
                    login.ChangeBox.Clear();
                    DXMessageBox.Show("密码更换成功.", "修改密码");
                    break;
            }

        }
        public void Process(S.RequestPasswordReset p)
        {
            LoginScene login = DXControl.ActiveScene as LoginScene;
            if (login == null) return;

            login.RequestPassswordBox.RequestAttempted = false;

            DateTime expiry;
            DXMessageBox box;
            switch (p.Result)
            {
                case RequestPasswordResetResult.Disabled:
                    login.RequestPassswordBox.Clear();
                    DXMessageBox.Show("密码重置目前已禁用.", "重置密码");
                    break;
                case RequestPasswordResetResult.BadEMail:
                    login.RequestPassswordBox.EMailTextBox.SetFocus();
                    DXMessageBox.Show("E-Mail地址错误.", "重置密码");
                    break;
                case RequestPasswordResetResult.AccountNotFound:
                    login.RequestPassswordBox.EMailTextBox.SetFocus();
                    DXMessageBox.Show("帐户不存在.", "重置密码");
                    break;
                case RequestPasswordResetResult.AccountNotActivated:
                    login.ShowActivationBox(login.RequestPassswordBox);
                    break;
                case RequestPasswordResetResult.ResetDelay:
                    expiry = CEnvir.Now.Add(p.Duration);
                    box = DXMessageBox.Show($"您不能这么快就请求另一个密码重置.\n" +
                                            $"下次可重置: {expiry}\n" +
                                            $"持续时间: {Math.Floor(p.Duration.TotalHours):#,##0} 小时, {p.Duration.Minutes} 分钟, {p.Duration.Seconds} 秒", "重置密码");

                    box.ProcessAction = () =>
                    {
                        if (CEnvir.Now != expiry) 
                        {
                            if (login.RequestPassswordBox.CanReset)
                                login.RequestPassswordBox.Request();
                            box.ProcessAction = null;
                            return;
                        }

                        TimeSpan remaining = expiry - CEnvir.Now;

                        box.Label.Text = $"您不能这么快就请求另一个密码重置.\n" +
                                         $"下次可重置: {expiry}\n" +
                                         $"持续时间: {Math.Floor(remaining.TotalHours):#,##0} 小时, {remaining.Minutes} 分钟, {remaining.Seconds} 秒";
                    };
                    break;
                case RequestPasswordResetResult.Banned:
                    expiry = CEnvir.Now.Add(p.Duration);
                    box = DXMessageBox.Show($"此帐户已被禁止登录.\n\n原因: {p.Message}\n" +
                                            $"到期日: {expiry}\n" +
                                            $"持续时间: {Math.Floor(p.Duration.TotalHours):#,##0} 小时, {p.Duration.Minutes} 分钟, {p.Duration.Seconds} 秒", "重置密码");

                    box.ProcessAction = () =>
                    {
                        if (CEnvir.Now > expiry)
                        {
                            if (login.RequestPassswordBox.CanReset)
                                login.RequestPassswordBox.Request();
                            box.ProcessAction = null;
                            return;
                        }

                        TimeSpan remaining = expiry - CEnvir.Now;

                        box.Label.Text = $"此帐户已被禁止登录.\n\n" +
                                         $"原因: {p.Message}\n" +
                                         $"到期日: {expiry}\n" +
                                         $"持续时间: {Math.Floor(remaining.TotalHours):#,##0} 小时, {remaining.Minutes} 分钟, {remaining.Seconds} 秒";
                    };
                    break;
                case RequestPasswordResetResult.Success:
                    login.RequestPassswordBox.Clear();
                    DXMessageBox.Show("重置密码请求成功\n请查看您的电子邮件以获取进一步的说明.", "重置密码");
                    break;
            }

        }
        public void Process(S.ResetPassword p)
        {
            LoginScene login = DXControl.ActiveScene as LoginScene;
            if (login == null) return;

            login.ResetBox.ResetAttempted = false;

            switch (p.Result)
            {
                case ResetPasswordResult.Disabled:
                    login.ResetBox.Clear();
                    DXMessageBox.Show("手动密码重置目前已禁用.", "重置密码");
                    break;
                case ResetPasswordResult.BadNewPassword:
                    login.ResetBox.NewPassword1TextBox.SetFocus();
                    DXMessageBox.Show("新密码无法被接受.", "重置密码");
                    break;
                case ResetPasswordResult.AccountNotFound:
                    login.ResetBox.ResetKeyTextBox.SetFocus();
                    DXMessageBox.Show("无法找到帐户.", "重置密码");
                    break;
                case ResetPasswordResult.Success:
                    login.ResetBox.Clear();
                    DXMessageBox.Show("密码更换成功.", "重置密码");
                    break;
            }

        }
        public void Process(S.Activation p)
        {
            LoginScene login = DXControl.ActiveScene as LoginScene;
            if (login == null) return;

            login.ActivationBox.ActivationAttempted = false;
            
            switch (p.Result)
            {
                case ActivationResult.Disabled:
                    login.ActivationBox.Clear();
                    DXMessageBox.Show("手动激活目前已禁用.", "激活");
                    break;
                case ActivationResult.AccountNotFound:
                    login.ActivationBox.ActivationKeyTextBox.SetFocus();
                    DXMessageBox.Show("无法找到帐户.", "激活");
                    break;
                case ActivationResult.Success:
                    login.ActivationBox.Clear();
                    DXMessageBox.Show("您的帐户已成功激活\n", "激活");
                    break;
            }

        }
        public void Process(S.RequestActivationKey p)
        {
            LoginScene login = DXControl.ActiveScene as LoginScene;
            if (login == null) return;

            login.RequestActivationBox.RequestAttempted = false;

            DateTime expiry;
            DXMessageBox box;
            switch (p.Result)
            {
                case RequestActivationKeyResult.Disabled:
                    login.RequestActivationBox.Clear();
                    DXMessageBox.Show("密码重置目前已禁用.", "申请激活密钥");
                    break;
                case RequestActivationKeyResult.BadEMail:
                    login.RequestActivationBox.EMailTextBox.SetFocus();
                    DXMessageBox.Show("电子邮件错误.", "申请激活密钥");
                    break;
                case RequestActivationKeyResult.AccountNotFound:
                    login.RequestActivationBox.EMailTextBox.SetFocus();
                    DXMessageBox.Show("帐户不存在.", "申请激活密钥");
                    break;
                case RequestActivationKeyResult.AlreadyActivated:
                    login.RequestActivationBox.Clear();
                    DXMessageBox.Show("帐户已激活.", "申请激活密钥");
                    break;
                case RequestActivationKeyResult.RequestDelay:
                    expiry = CEnvir.Now.Add(p.Duration);
                    box = DXMessageBox.Show($"不能这么快就请求另一个激活邮件.\n" +
                                            $"下次请求: {expiry}\n" +
                                            $"持续时间: {Math.Floor(p.Duration.TotalHours):#,##0} 小时, {p.Duration.Minutes} 分钟, {p.Duration.Seconds} 秒", "申请激活密钥");

                    box.ProcessAction = () =>
                    {
                        if (CEnvir.Now > expiry)
                        {
                            if (login.RequestActivationBox.CanRequest)
                                login.RequestActivationBox.Request();
                            box.ProcessAction = null;
                            return;
                        }

                        TimeSpan remaining = expiry - CEnvir.Now;

                        box.Label.Text = $"不能这么快就请求另一个激活邮件.\n" +
                                         $"下次请求: {expiry}\n" +
                                         $"持续时间: {Math.Floor(remaining.TotalHours):#,##0} 小时, {remaining.Minutes} 分钟, {remaining.Seconds} 秒";
                    };
                    break;
                case RequestActivationKeyResult.Success:
                    login.RequestActivationBox.Clear();
                    DXMessageBox.Show("激活电子邮件请求成功发送\n请查看您的电子邮件以获取进一步的说明.", "申请激活密钥");
                    break;
            }

        }
        public void Process(S.Login p)
        {
            LoginScene login = DXControl.ActiveScene as LoginScene;
            if (login == null) return;

            login.LoginBox.LoginAttempted = false;

            SelectScene scene;
            switch (p.Result)
            {
                case LoginResult.Disabled:
                    DXMessageBox.Show("登录目前已禁用.", "登录");
                    break;
                case LoginResult.BadEMail:
                    login.LoginBox.EMailTextBox.SetFocus();
                    DXMessageBox.Show("用户名不可接受.", "登录");
                    break;
                case LoginResult.BadPassword:
                    login.LoginBox.PasswordTextBox.SetFocus();
                    DXMessageBox.Show("目前的密码不可接受.", "登录");
                    break;
                case LoginResult.AccountNotExists:
                    login.LoginBox.EMailTextBox.SetFocus();
                    DXMessageBox.Show("帐户不存在.", "登录");
                    break;
                case LoginResult.AccountNotActivated:
                    login.ShowActivationBox(login.LoginBox);
                    break;
                case LoginResult.WrongPassword:
                    login.LoginBox.PasswordTextBox.SetFocus();
                    DXMessageBox.Show("密码错误.", "登录");
                    break;
                case LoginResult.Banned:
                    DateTime expiry = CEnvir.Now.Add(p.Duration);

                    DXMessageBox box = DXMessageBox.Show($"此帐户已被封禁.\n\n" +
                                                         $"原因: {p.Message}\n" +
                                                         $"到期日: {expiry}\n" +
                                                         $"持续时间: {Math.Floor(p.Duration.TotalHours):#,##0} 小时, {p.Duration.Minutes} 分钟, {p.Duration.Seconds} 秒", "登录");

                    box.ProcessAction = () =>
                    {
                        if (CEnvir.Now > expiry)
                        {
                            if (login.LoginBox.CanLogin)
                                login.LoginBox.Login();
                            box.ProcessAction = null;
                            return;
                        }

                        TimeSpan remaining = expiry - CEnvir.Now;

                        box.Label.Text = $"此帐户已被封禁.\n\n" +
                                         $"原因: {p.Message}\n" +
                                         $"到期日: {expiry}\n" +
                                         $"持续时间: {Math.Floor(remaining.TotalHours):#,##0} 小时, {remaining.Minutes} 分钟, {remaining.Seconds} 秒";
                    };
                    break;
                case LoginResult.AlreadyLoggedIn:
                    login.LoginBox.EMailTextBox.SetFocus();
                    DXMessageBox.Show("帐户目前正在使用中，请稍后再试.", "登录");
                    break;
                case LoginResult.AlreadyLoggedInPassword:
                    
                    login.LoginBox.EMailTextBox.SetFocus();
                    DXMessageBox.Show("帐户目前正在使用中\n新密码已发送到电子邮件地址...", "登录");
                    break;
                case LoginResult.AlreadyLoggedInAdmin:
                    login.LoginBox.EMailTextBox.SetFocus();
                    DXMessageBox.Show("帐户目前正由管理员使用", "登录");
                    break;
                case LoginResult.Success:
                    login.LoginBox.Visible = false;
                    login.AccountBox.Visible = false;
                    login.ChangeBox.Visible = false;
                    login.RequestPassswordBox.Visible = false;
                    login.ResetBox.Visible = false;
                    login.ActivationBox.Visible = false;
                    login.RequestActivationBox.Visible = false;

                    CEnvir.TestServer = p.TestServer;
                    
                    if (Config.RememberDetails)
                    {
                        Config.RememberedEMail = login.LoginBox.EMailTextBox.TextBox.Text;
                        Config.RememberedPassword = login.LoginBox.PasswordTextBox.TextBox.Text;
                    }

                    login.Dispose();
                    DXSoundManager.Stop(SoundIndex.LoginScene);
                    DXSoundManager.Play(SoundIndex.SelectScene);

                    p.Characters.Sort((x1, x2) => x2.LastLogin.CompareTo(x1.LastLogin));

                    DXControl.ActiveScene = scene = new SelectScene(Config.IntroSceneSize)
                    {
                        SelectBox = { CharacterList = p.Characters },
                    };

                    scene.SelectBox.UpdateCharacters();

                    CEnvir.BuyAddress = p.Address;
                    CEnvir.FillStorage(p.Items, false);

                    CEnvir.BlockList = p.BlockList;

                    if (!string.IsNullOrEmpty(p.Message)) DXMessageBox.Show(p.Message, "登录消息");
                    
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        public void Process(S.SelectLogout p)
        {
            CEnvir.ReturnToLogin();
            ((LoginScene)DXControl.ActiveScene).LoginBox.Visible = true;
        }
        public void Process(S.GameLogout p)
        {
            DXSoundManager.StopAllSounds();

            GameScene.Game.Dispose();

            DXSoundManager.Play(SoundIndex.SelectScene);

            SelectScene scene;

            p.Characters.Sort((x1, x2) => x2.LastLogin.CompareTo(x1.LastLogin));

            DXControl.ActiveScene = scene = new SelectScene(Config.IntroSceneSize)
            {
                SelectBox = { CharacterList = p.Characters },
            };

            CEnvir.Storage = CEnvir.MainStorage;

            CEnvir.PatchGrid = CEnvir.MainPatchGrid;

            
            CEnvir.BaoshiGrid = CEnvir.MainBaoshiGrid;

            scene.SelectBox.UpdateCharacters();
        }

        public void Process(S.NewCharacter p)
        {
            SelectScene select = DXControl.ActiveScene as SelectScene;
            if (select == null) return;

            select.CharacterBox.CreateAttempted = false;
            
            switch (p.Result)
            {
                case NewCharacterResult.Disabled:
                    select.CharacterBox.Clear();
                    DXMessageBox.Show("目前已禁止创建角色.", "角色创建");
                    break;
                case NewCharacterResult.BadCharacterName:
                    select.CharacterBox.CharacterNameTextBox.SetFocus();
                    DXMessageBox.Show("角色名称不符合要求.", "角色创建");
                    break;
                case NewCharacterResult.BadHairType:
                    select.CharacterBox.HairNumberBox.Value = 1;
                    DXMessageBox.Show("错误：无效的头发类型.", "角色创建");
                    break;
                case NewCharacterResult.BadHairColour:
                    DXMessageBox.Show("错误：无效的头发颜色.", "角色创建");
                    break;
                case NewCharacterResult.BadArmourColour:
                    DXMessageBox.Show("错误：衣服颜色无效.", "角色创建");
                    break;
                case NewCharacterResult.BadGender:
                    select.CharacterBox.SelectedGender = MirGender.Male;
                    DXMessageBox.Show("错误：选择了无效的性别.", "角色创建");
                    break;
                case NewCharacterResult.BadClass:
                    select.CharacterBox.SelectedClass = MirClass.Warrior;
                    DXMessageBox.Show("错误：选择了无效的职业.", "角色创建");
                    break;
                case NewCharacterResult.ClassDisabled:
                    DXMessageBox.Show("所选职业目前无法使用.", "角色创建");
                    break;
                case NewCharacterResult.MaxCharacters:
                    select.CharacterBox.Clear();
                    DXMessageBox.Show("已达到字符限制.", "角色创建");
                    break;
                case NewCharacterResult.AlreadyExists:
                    select.CharacterBox.CharacterNameTextBox.SetFocus();
                    DXMessageBox.Show("角色已经存在.", "角色创建");
                    break;
                case NewCharacterResult.Success:
                    select.CharacterBox.Clear();

                    select.SelectBox.CharacterList.Add(p.Character);
                    select.SelectBox.UpdateCharacters();
                    select.SelectBox.SelectedButton = select.SelectBox.SelectButtons[select.SelectBox.CharacterList.Count -1];

                    DXMessageBox.Show("角色创建成功.", "角色创建");
                    break;
            }
        }
        public void Process(S.DeleteCharacter p)
        {
            SelectScene select = DXControl.ActiveScene as SelectScene;
            if (select == null) return;

            switch (p.Result)
            {
                case DeleteCharacterResult.Disabled:
                    DXMessageBox.Show("目前已禁止删除角色.", "删除角色");
                    break;
                case DeleteCharacterResult.AlreadyDeleted:
                    DXMessageBox.Show("角色已被删除.", "删除角色");
                    break;
                case DeleteCharacterResult.NotFound:
                    DXMessageBox.Show("找不到角色.", "删除角色");
                    break;
                case DeleteCharacterResult.Success:
                    for (int i = select.SelectBox.CharacterList.Count - 1; i >= 0; i--)
                    {
                        if (select.SelectBox.CharacterList[i].CharacterIndex != p.DeletedIndex) continue;

                        select.SelectBox.CharacterList.RemoveAt(i);
                        break;
                    }
                    select.SelectBox.UpdateCharacters();
                    DXMessageBox.Show("角色已被删除.", "删除角色");
                    break;
            }
        }
        public void Process(S.StartGame p)
        {
            try
            {

                SelectScene select = DXControl.ActiveScene as SelectScene;
                if (select == null) return;

                select.SelectBox.StartGameAttempted = false;


                DXMessageBox box;
                DateTime expiry;
                switch (p.Result)
                {
                    case StartGameResult.Disabled:
                        DXMessageBox.Show("目前已禁止开始游戏.", "开始游戏");
                        break;
                    case StartGameResult.Deleted:
                        DXMessageBox.Show("您无法使用已删除的角色开始游戏.", "开始游戏");
                        break;
                    case StartGameResult.Delayed:
                        expiry = CEnvir.Now.Add(p.Duration);

                        box = DXMessageBox.Show($"该角色刚刚退出游戏，请稍候.\n" + $"持续时间: {Math.Floor(p.Duration.TotalHours):#,##0} 小时, {p.Duration.Minutes} 分钟, {p.Duration.Seconds} 秒", "开始游戏");

                        box.ProcessAction = () =>
                        {
                            if (CEnvir.Now > expiry)
                            {
                                if (select.SelectBox.CanStartGame)
                                    select.SelectBox.StartGame();
                                box.ProcessAction = null;
                                return;
                            }

                            TimeSpan remaining = expiry - CEnvir.Now;

                            box.Label.Text = $"该角色刚刚退出游戏，请稍候.\n" + $"持续时间: {Math.Floor(remaining.TotalHours):#,##0} 小时, {remaining.Minutes:#,##0} 分钟, {remaining.Seconds} 秒";
                        };
                        break;
                    case StartGameResult.UnableToSpawn:
                        DXMessageBox.Show("无法启动游戏，无法生成角色.", "开始游戏");
                        break;
                    case StartGameResult.NotFound:
                        DXMessageBox.Show("无法启动游戏，找不到角色.", "开始游戏");
                        break;
                    case StartGameResult.Success:
                        select.Dispose();
                        DXSoundManager.StopAllSounds();

                        GameScene scene = new GameScene(Config.GameSize);
                        DXControl.ActiveScene = scene;

                        scene.MapControl.MapInfo = CartoonGlobals.MapInfoList.Binding.FirstOrDefault(x => x.Index == p.StartInformation.MapIndex);
                        GameScene.Game.QuestLog = p.StartInformation.Quests;

                        GameScene.Game.MeiriQuestLog = p.StartInformation.MeiriQuests;

                        GameScene.Game.NPCAdoptCompanionBox.AvailableCompanions = p.StartInformation.AvailableCompanions;
                        GameScene.Game.NPCAdoptCompanionBox.RefreshUnlockButton();

                        GameScene.Game.NPCCompanionStorageBox.Companions = p.StartInformation.Companions;
                        GameScene.Game.NPCCompanionStorageBox.UpdateScrollBar();

                        GameScene.Game.Companion = GameScene.Game.NPCCompanionStorageBox.Companions.FirstOrDefault(x => x.Index == p.StartInformation.Companion);

                        GameScene.Game.NPCAdoptHorseBox.AvailableHorses = p.StartInformation.AvailableHorses;
                        GameScene.Game.NPCAdoptHorseBox.RefreshUnlockButton();
                        foreach (int a in p.StartInformation.Horses)
                        {
                            ClientUserHorse clientUserHorse = new ClientUserHorse();
                            clientUserHorse.HorseInfo = CartoonGlobals.HorseInfoList.Binding.FirstOrDefault((HorseInfo x) => x.Index == a);
                            clientUserHorse.HorseNum = a;
                            GameScene.Game.NPCHorseStorageBox.Horses.Add(clientUserHorse);
                        }
                        GameScene.Game.NPCHorseStorageBox.UpdateScrollBar();
                        if (p.StartInformation.Horse != 0)
                        {
                            GameScene.Game.Horse = GameScene.Game.NPCHorseStorageBox.Horses.FirstOrDefault((ClientUserHorse x) => x.HorseInfo.Horse == p.StartInformation.Horse);
                        }

                        GameScene.Game.PatchGridSize = p.StartInformation.PatchGridSize;
                        
                        GameScene.Game.BaoshiGridSize = p.StartInformation.BaoshiGridSize;

                        scene.User = new UserObject(p.StartInformation);

                        GameScene.Game.BuffBox.BuffsChanged();
                        GameScene.Game.RankingBox.Observable = p.StartInformation.Observable;

                        GameScene.Game.StorageSize = p.StartInformation.StorageSize;

                        CEnvir.Enqueue(new C.CraftInformation());

                        if (!string.IsNullOrEmpty(p.Message)) DXMessageBox.Show(p.Message, "开始游戏");

                        
                        GameScene.Game.processlabel();
                        GameScene.Game.FubenBox?.CreateTabs();

                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public void Process(S.MapChanged p)
        {
            GameScene.Game.MapControl.MapInfo = CartoonGlobals.MapInfoList.Binding.FirstOrDefault(x => x.Index == p.MapIndex);

            MapObject.User.NameChanged();
        }

        public void Process(S.MapTime p)
        {
            if (!p.OnOff)
            {
                GameScene.Game.NPCTopTagBox.Visible = false;
                GameScene.Game.NPCTopTagBox.ProcessAction = null;
            }
            else
            {
                GameScene.Game.NPCTopTagBox.Expiry = CEnvir.Now.Add(p.MapRemaining);
                GameScene.Game.NPCTopTagBox.MapLabel.Text = "";
                GameScene.Game.NPCTopTagBox.Visible = true;
                if (GameScene.Game.NPCTopTagBox.ProcessAction == null)
                    GameScene.Game.NPCTopTagBox.ProcessAction = (Action)(() =>
                    {
                        if (CEnvir.Now > GameScene.Game.NPCTopTagBox.Expiry)
                        {
                            GameScene.Game.NPCTopTagBox.Visible = false;
                            GameScene.Game.NPCTopTagBox.ProcessAction = null;
                        }
                        else
                        {
                            TimeSpan timeSpan = GameScene.Game.NPCTopTagBox.Expiry - CEnvir.Now;
                            GameScene.Game.NPCTopTagBox.TimeLabel.Text = string.Format("{0:#,##0}:{1:#,##0}:{2}", (object)Math.Floor(timeSpan.TotalHours), (object)timeSpan.Minutes, (object)timeSpan.Seconds);
                        }
                    });
            }
            if (!p.ExpiryOnff)
            {
                GameScene.Game.NPCReplicaBox.Visible = false;
                GameScene.Game.NPCReplicaBox.ProcessAction = (Action)null;
            }
            else
            {
                GameScene.Game.NPCReplicaBox.Expiry = CEnvir.Now.Add(p.ExpiryRemaining);
                GameScene.Game.NPCReplicaBox.ExplainLabel.Text = GameScene.Game.MapControl.MapInfo.Description;
                GameScene.Game.NPCReplicaBox.Visible = true;
                if (GameScene.Game.NPCReplicaBox.ProcessAction == null)
                    GameScene.Game.NPCReplicaBox.ProcessAction = (Action)(() =>
                    {
                        if (CEnvir.Now > GameScene.Game.NPCReplicaBox.Expiry)
                        {
                            GameScene.Game.NPCReplicaBox.Visible = false;
                            GameScene.Game.NPCReplicaBox.ProcessAction = (Action)null;
                        }
                        else
                        {
                            TimeSpan timeSpan = GameScene.Game.NPCReplicaBox.Expiry - CEnvir.Now;
                            GameScene.Game.NPCReplicaBox.TimeLabel.Text = string.Format("{0:#,##0}:{1:#,##0}:{2}", (object)Math.Floor(timeSpan.TotalHours), (object)timeSpan.Minutes, (object)timeSpan.Seconds);
                        }
                    });
            }
        }

        public void Process(S.DayChanged p)
        {
            GameScene.Game.DayTime = p.DayTime;
        }

        public void Process(S.UserLocation p)
        {
            GameScene.Game.Displacement(p.Direction, p.Location);
        }
        public void Process(S.ObjectRemove p)
        {
            if (p.ObjectID == GameScene.Game.NPCID)
                GameScene.Game.NPCBox.Visible = false;

            if (MapObject.TargetObject != null && MapObject.TargetObject.ObjectID == p.ObjectID)
                MapObject.TargetObject = null;

            if (MapObject.MouseObject != null && MapObject.MouseObject.ObjectID == p.ObjectID)
                MapObject.MouseObject = null;

            if (MapObject.MagicObject != null && MapObject.MagicObject.ObjectID == p.ObjectID)
                MapObject.MagicObject = null;

            if (GameScene.Game.FocusObject != null && GameScene.Game.FocusObject.ObjectID == p.ObjectID)
                GameScene.Game.FocusObject = null;

            if (GameScene.Game.MonsterBox.Monster != null && GameScene.Game.MonsterBox.Monster.ObjectID == p.ObjectID)
                GameScene.Game.MonsterBox.Monster = null;

            if (GameScene.Game.AutoTargetObject != null && (int)GameScene.Game.AutoTargetObject.ObjectID == (int)p.ObjectID)
                GameScene.Game.AutoTargetObject = (MapObject)null;

            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
            {
                if (ob.ObjectID != p.ObjectID) continue;
                
                ob.Remove();
                return;
            }

        }
        public void Process(S.ObjectPlayer p)
        {
            new PlayerObject(p);
        }

        public void Process(S.ToGetSortItem p)
        {
            GameScene.Game.SortFillItems(p.Items);
        }

        public void Process(S.ObjectItem p)
        {
            new ItemObject(p);
        }
        public void Process(S.ObjectMonster p)
        {
            new MonsterObject(p);

        }
        public void Process(S.ObjectNPC p)
        {
            new NPCObject(p);

        }
        public void Process(S.ObjectSpell p)
        {
            new SpellObject(p);
        }
        public void Process(S.ObjectSpellChanged p)
        {
            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
            {
                if (ob.ObjectID != p.ObjectID) continue;

                SpellObject spell = (SpellObject) ob;
                spell.Power = p.Power;
                spell.UpdateLibraries();
                return;
            }
        }
        public void Process(S.PlayerUpdate p)
        {
            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
            {
                if (ob.Race != ObjectType.Player || ob.ObjectID != p.ObjectID) continue;

                PlayerObject player = (PlayerObject)ob;

                player.LibraryWeaponShape = p.Weapon;
                player.ArmourShape = p.Armour;
                player.ArmourColour = p.ArmourColour;
                player.HelmetShape = p.Helmet;
                player.HorseShape = p.HorseArmour;
                player.ArmourImage = p.ArmourImage;
                player.ShieldShape = p.Shield;
                player.EmblemShape = p.Emblem;
                player.WeaponImage = p.WeaponImage;

                
                player.ShizhuangShape = p.Shizhuang;
                player.ShizhuangImage = p.ShizhuangImage;

                
                player.Mingwen01 = p.Mingwen01;
                player.Mingwen02 = p.Mingwen02;
                player.Mingwen03 = p.Mingwen03;

                player.gameTeam = p.eventTeam;

                player.Light = p.Light;
                if (player == MapObject.User)
                    player.Light = Math.Max(p.Light, 3);

                player.UpdateLibraries();
                return;
            }
        }

        public void Process(S.ObjectTurn p)
        {
            if (MapObject.User.ObjectID == p.ObjectID && !GameScene.Game.Observer)
            {
                if (MapObject.User.CurrentLocation != p.Location || MapObject.User.Direction != p.Direction)
                    GameScene.Game.Displacement(p.Direction, p.Location);

                MapObject.User.ServerTime = DateTime.MinValue;

                MapObject.User.NextActionTime += p.Slow;
                return;
            }

            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
            {
                if (ob.ObjectID != p.ObjectID) continue;

                ob.ActionQueue.Add(new ObjectAction(MirAction.Standing, p.Direction, p.Location));
                return;
            }
        }
        public void Process(S.ObjectHarvest p)
        {
            if (MapObject.User.ObjectID == p.ObjectID && !GameScene.Game.Observer)
            {
                if (MapObject.User.CurrentLocation != p.Location || MapObject.User.Direction != p.Direction)
                    GameScene.Game.Displacement(p.Direction, p.Location);

                MapObject.User.ServerTime = DateTime.MinValue;
                MapObject.User.NextActionTime += p.Slow;
                return;
            }

            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
            {
                if (ob.ObjectID != p.ObjectID) continue;

                ob.ActionQueue.Add(new ObjectAction(MirAction.Harvest, p.Direction, p.Location));
                return;
            }
        }
        
        public void Process(S.ObjectShow p)
        {
            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
            {
                if (ob.ObjectID != p.ObjectID) continue;
                if (ob.Race == ObjectType.Monster)
                {
                    switch (((MonsterObject) ob).Image)
                    {

                        case MonsterImage.VoraciousGhost:
                        case MonsterImage.DevouringGhost:
                        case MonsterImage.CorpseRaisingGhost:
                            ob.Visible = true;
                            ob.Dead = false;
                            break;
                    }
                }

                ob.ActionQueue.Add(new ObjectAction(MirAction.Show, p.Direction, p.Location));
                return;
            }
        }
        public void Process(S.ObjectHide p)
        {
            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
            {
                if (ob.ObjectID != p.ObjectID) continue;

                ob.ActionQueue.Add(new ObjectAction(MirAction.Hide, p.Direction, p.Location));
                return;
            }
        }
        public void Process(S.ObjectMove p)
        {
            if (MapObject.User.ObjectID == p.ObjectID && !GameScene.Game.Observer)
            {

                if (MapObject.User.CurrentLocation != p.Location || MapObject.User.Direction != p.Direction)
                    GameScene.Game.Displacement(p.Direction, p.Location);
                MapObject.User.ServerTime = DateTime.MinValue;

                MapObject.User.NextActionTime += p.Slow;
                return;
            }


            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
            {
                if (ob.ObjectID != p.ObjectID) continue;

                ob.ActionQueue.Add(new ObjectAction(MirAction.Moving, p.Direction, p.Location, p.Distance, MagicType.None));
                return;
            }
        }
        public void Process(S.ObjectPushed p)
        {
            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
            {
                if (ob.ObjectID != p.ObjectID) continue;

                ob.ActionQueue.Add(new ObjectAction(MirAction.Pushed, p.Direction, p.Location));
                return;
            }
        }
        public void Process(S.ObjectNameColour p)
        {
            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
            {
                if (ob.ObjectID != p.ObjectID) continue;

                ob.NameColour = p.Colour;
                return;
            }
        }
        public void Process(S.ObjectMount p)
        {
            if (MapObject.User.ObjectID == p.ObjectID)
            {
                MapObject.User.ServerTime = DateTime.MinValue;
                MapObject.User.NextActionTime = CEnvir.Now + CartoonGlobals.TurnTime;
            }

            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
            {
                if (ob.ObjectID != p.ObjectID) continue;

                if (ob.Race != ObjectType.Player) return;
                
                PlayerObject player = (PlayerObject) ob;
                
                player.Horse = p.Horse;

                if (player.Interupt)
                    player.FrameStart = DateTime.MinValue;
                return;
            }
        }
        public void Process(S.MountFailed p)
        {
            MapObject.User.ServerTime = DateTime.MinValue;
            GameScene.Game.User.Horse = p.Horse;
        }

        public void Process(S.ObjectStruck p)
        {



            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
            {
                if (ob.ObjectID != p.ObjectID) continue;

                if (ob == MapObject.User) 
                {
                    GameScene.Game.CanRun = false;
                    
                    

                    /* if (MapObject.User.ServerTime > DateTime.MinValue) 
                     {
                         switch (MapObject.User.CurrentAction)
                         {
                             case MirAction.Attack:
                             case MirAction.RangeAttack:
                                 MapObject.User.AttackTime += TimeSpan.FromMilliseconds(300);
                                 break;
                             case MirAction.Spell:
                                 MapObject.User.NextMagicTime += TimeSpan.FromMilliseconds(300);
                                 break;
                         }
                     }*/
                }

                

                

                ob.Struck(p.AttackerID, p.Element);

                return;
            }
        }

        public void Process(S.ObjectDash p)
        {
            

            if (MapObject.User.ObjectID == p.ObjectID && !GameScene.Game.Observer)
                MapObject.User.ServerTime = DateTime.MinValue;

            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
            {
                if (ob.ObjectID != p.ObjectID) continue;

                ob.StanceTime = CEnvir.Now.AddSeconds(3);
                ob.ActionQueue.Add(new ObjectAction(MirAction.Standing, p.Direction, Functions.Move(p.Location, p.Direction, - p.Distance)));

                for (int i = 1; i <= p.Distance; i++)
                    ob.ActionQueue.Add(new ObjectAction(MirAction.Moving, p.Direction, Functions.Move(p.Location, p.Direction, i - p.Distance), 1, p.Magic));

                return;
            }
        }
        public void Process(S.ObjectAttack p)
        {
            if (MapObject.User.ObjectID == p.ObjectID && !GameScene.Game.Observer && p.AttackMagic != MagicType.DanceOfSwallow)
            {
                if (MapObject.User.CurrentLocation != p.Location || MapObject.User.Direction != p.Direction)
                    GameScene.Game.Displacement(p.Direction, p.Location);

                MapObject.User.ServerTime = DateTime.MinValue;

                MapObject.User.NextActionTime += p.Slow;
                return;
            }

            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
            {
                if (ob.ObjectID != p.ObjectID) continue;

                ob.ActionQueue.Add(new ObjectAction(MirAction.Attack, p.Direction, p.Location, p.TargetID, p.AttackMagic, p.AttackElement));
                return;
            }
        }
        public void Process(S.ObjectMining p)
        {
            if (MapObject.User.ObjectID == p.ObjectID && !GameScene.Game.Observer)
            {
                if (MapObject.User.CurrentLocation != p.Location || MapObject.User.Direction != p.Direction)
                    GameScene.Game.Displacement(p.Direction, p.Location);

                MapObject.User.ServerTime = DateTime.MinValue;

                MapObject.User.NextActionTime += p.Slow;
                MapObject.User.MiningEffect = p.Effect;
                return;
            }

            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
            {
                if (ob.ObjectID != p.ObjectID) continue;

                ob.ActionQueue.Add(new ObjectAction(MirAction.Mining, p.Direction, p.Location, p.Effect));
                return;
            }
        }
        public void Process(S.ObjectRangeAttack p)
        {
            if (MapObject.User.ObjectID == p.ObjectID && !GameScene.Game.Observer)
            {
                if (MapObject.User.CurrentLocation != p.Location || MapObject.User.Direction != p.Direction)
                    GameScene.Game.Displacement(p.Direction, p.Location);

                MapObject.User.ServerTime = DateTime.MinValue;
                return;
            }

            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
            {
                if (ob.ObjectID != p.ObjectID) continue;

                ob.ActionQueue.Add(new ObjectAction(MirAction.RangeAttack, p.Direction, p.Location, p.Targets, p.AttackMagic, p.AttackElement));
                return;
            }
        }
        public void Process(S.ObjectMagic p)
        {
            if (MapObject.User.ObjectID == p.ObjectID && !GameScene.Game.Observer)
            {
                if (MapObject.User.CurrentLocation != p.CurrentLocation || MapObject.User.Direction != p.Direction)
                    GameScene.Game.Displacement(p.Direction, p.CurrentLocation);
                
                MapObject.User.ServerTime = DateTime.MinValue;

                MapObject.User.AttackTargets = new List<MapObject>();

                foreach (uint target in p.Targets)
                {
                    MapObject attackTarget = GameScene.Game.MapControl.Objects.FirstOrDefault(x => x.ObjectID == target);

                    if (attackTarget == null) continue;
                    
                    MapObject.User.AttackTargets.Add(attackTarget);
                }

                MapObject.User.MagicLocations = p.Locations;
                MapObject.User.MagicCast = p.Cast;
                MapObject.User.NextActionTime += p.Slow;
                return;
            }

            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
            {
                if (ob.ObjectID != p.ObjectID) continue;

                ob.ActionQueue.Add(new ObjectAction(MirAction.Spell, p.Direction, p.CurrentLocation, p.Type, p.Targets, p.Locations, p.Cast));
                return;
            }
        }
        public void Process(S.ObjectDied p)
        {
            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
            {
                if (ob.ObjectID != p.ObjectID) continue;

                ob.Dead = true;
                ob.ActionQueue.Add(new ObjectAction(MirAction.Die, p.Direction, p.Location));

                if (ob == MapObject.User)
                    GameScene.Game.ReceiveChat(MessageAction.Revive);

                return;
            }
        }
        public void Process(S.ObjectHarvested p)
        {
            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
            {
                if (ob.ObjectID != p.ObjectID) continue;

                ob.Skeleton = true;

                ob.ActionQueue.Add(new ObjectAction(MirAction.Dead, p.Direction, p.Location));
                
                return;
            }
        }
        public void Process(S.ObjectEffect p)
        {
            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
            {
                if (ob.ObjectID != p.ObjectID) continue;

                switch (p.Effect)
                {
                    case Effect.TeleportOut:
                        ob.Effects.Add(new MirEffect(110, 10, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 30, 60, Color.White)
                        {
                            MapTarget =  ob.CurrentLocation,
                            Blend = true,
                            Reversed = true,
                            BlendRate = 0.6F
                        });

                        DXSoundManager.Play(SoundIndex.TeleportOut);
                        break;
                    case Effect.TeleportIn:
                        ob.Effects.Add(new MirEffect(110, 10, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 30, 60, Color.White)
                        {
                            Target = ob,
                            Blend = true,
                            BlendRate = 0.6F
                        });

                        DXSoundManager.Play(SoundIndex.TeleportIn);
                        break;
                    case Effect.FullBloom:
                        ob.Effects.Add(new MirEffect(1700, 4, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx4, 30, 60, Color.White)
                        {
                            Target = ob,
                            Blend = true,
                            BlendRate = 0.6F
                        });

                        DXSoundManager.Play(SoundIndex.FullBloom);
                        break;
                    case Effect.WhiteLotus:
                        ob.Effects.Add(new MirEffect(1600, 12, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx4, 30, 60, Color.White)
                        {
                            Target = ob,
                            Blend = true,
                            BlendRate = 0.6F
                        });

                        DXSoundManager.Play(SoundIndex.WhiteLotus);
                        break;
                    case Effect.RedLotus:
                        ob.Effects.Add(new MirEffect(1700, 12, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx4, 30, 60, Color.White)
                        {
                            Target = ob,
                            Blend = true,
                            BlendRate = 0.6F
                        });

                        DXSoundManager.Play(SoundIndex.RedLotus);
                        break;
                    case Effect.SweetBrier:
                        ob.Effects.Add(new MirEffect(1900, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx4, 30, 60, Color.White)
                        {
                            Target = ob,
                            Blend = true,
                            BlendRate = 0.6F
                        });

                        DXSoundManager.Play(SoundIndex.SweetBrier);
                        break;
                    case Effect.Karma:
                        ob.Effects.Add(new MirEffect(1800, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx4, 30, 60, Color.White)
                        {
                            Target = ob,
                            Blend = true,
                            BlendRate = 0.6F
                        });

                        DXSoundManager.Play(SoundIndex.Karma);
                        break;

                    case Effect.Puppet:
                        ob.Effects.Add(new MirEffect(820, 8, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx4, 30, 60, CartoonGlobals.FireColour)
                        {
                            Target = ob,
                            Blend = true,
                            BlendRate = 0.6F
                        });
                        break;
                    case Effect.PuppetFire:
                        ob.Effects.Add(new MirEffect(1546, 8, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx4, 30, 60, CartoonGlobals.FireColour)
                        {
                            Target = ob,
                            Blend = true,
                            BlendRate = 0.6F
                        });
                        break;
                    case Effect.PuppetIce:
                        ob.Effects.Add(new MirEffect(2700, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx4, 30, 60, CartoonGlobals.IceColour)
                        {
                            Target = ob,
                            Blend = true,
                            BlendRate = 0.6F
                        });
                        break;
                    case Effect.PuppetLightning:
                        ob.Effects.Add(new MirEffect(2800, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx4, 30, 60, CartoonGlobals.LightningColour)
                        {
                            Target = ob,
                            Blend = true,
                            BlendRate = 0.6F
                        });
                        break;
                    case Effect.PuppetWind:
                        ob.Effects.Add(new MirEffect(2900, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx4, 30, 60, CartoonGlobals.WindColour)
                        {
                            Target = ob,
                            Blend = true,
                            BlendRate = 0.6F
                        });
                        break;
                    #region Thunder Bolt & Thunder Strike

                    case Effect.ThunderBolt:

                            ob.Effects.Add(new MirEffect(1450, 3, TimeSpan.FromMilliseconds(150), LibraryFile.Magic, 150, 50, CartoonGlobals.LightningColour)
                            {
                                Blend = true,
                                Target = ob
                            });

                            DXSoundManager.Play(SoundIndex.LightningStrikeEnd);
                        break;

                    #endregion
                    case Effect.DanceOfSwallow:
                        ob.Effects.Add(new MirEffect(1300, 8, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx4, 20, 70, CartoonGlobals.NoneColour) 
                        {
                            Blend = true,
                            Target = ob,
                        });

                        DXSoundManager.Play(SoundIndex.DanceOfSwallowsEnd);
                        break;
                    case Effect.FlashOfLight:
                        ob.Effects.Add(new MirEffect(2400, 5, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx4, 20, 70, CartoonGlobals.NoneColour) 
                        {
                            Blend = true,
                            Target = ob,
                        });

                        DXSoundManager.Play(SoundIndex.FlashOfLightEnd);
                        break;
                    case Effect.DemonExplosion:
                        ob.Effects.Add(new MirEffect(3300, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MonMagicEx8, 30, 60, CartoonGlobals.PhantomColour)
                        {
                            Target = ob,
                            Blend = true,
                            BlendRate = 0.6F
                        });

                        
                        break;
                    case Effect.FrostBiteEnd:
                        ob.Effects.Add(new MirEffect(700, 7, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx5, 30, 60, CartoonGlobals.IceColour)
                        {
                            Target = ob,
                            Blend = true,
                            BlendRate = 0.6F
                        });


                        DXSoundManager.Play(SoundIndex.FireStormEnd);
                        break;
                    case Effect.DemonicRecovery:
                        ob.Effects.Add(new MirEffect(3000, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MonMagicEx8, 30, 60, CartoonGlobals.PhantomColour)
                        {
                            Target = ob,
                            Blend = true,
                            BlendRate = 0.6F
                        });

                        
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                return;
            }
        }
        public void Process(S.MapEffect p)
        {
            switch (p.Effect)
            {
                case Effect.SummonSkeleton:
                    new MirEffect(750, 10, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 30, 60, CartoonGlobals.PhantomColour)
                    {
                        MapTarget = p.Location,
                        Blend = true,
                    };

                    DXSoundManager.Play(SoundIndex.SummonSkeletonEnd);
                    break;
                case Effect.SummonShinsu:
                    if (GameScene.Game.User.Mingwen01 == 42 || GameScene.Game.User.Mingwen02 == 42 || GameScene.Game.User.Mingwen03 == 42)
                    {
                        new MirEffect(0, 10, TimeSpan.FromMilliseconds(100), LibraryFile.Mon_68, 30, 60, CartoonGlobals.PhantomColour)
                        {
                            MapTarget = p.Location,
                            Direction = p.Direction,
                        };
                    }
                    else if (GameScene.Game.User.Mingwen01 == 43 || GameScene.Game.User.Mingwen02 == 43 || GameScene.Game.User.Mingwen03 == 43)
                    {
                        new MirEffect(410, 10, TimeSpan.FromMilliseconds(100), LibraryFile.Mon_70, 30, 60, CartoonGlobals.PhantomColour)
                        {
                            MapTarget = p.Location,
                            Direction = p.Direction,
                        };
                    }
                    else if (GameScene.Game.User.Mingwen01 == 44 || GameScene.Game.User.Mingwen02 == 44 || GameScene.Game.User.Mingwen03 == 44)
                    {
                        new MirEffect(410, 10, TimeSpan.FromMilliseconds(100), LibraryFile.Mon_72, 30, 60, CartoonGlobals.PhantomColour)
                        {
                            MapTarget = p.Location,
                            Direction = p.Direction,
                        };
                    }
                    else
                    {
                        new MirEffect(9640, 10, TimeSpan.FromMilliseconds(100), LibraryFile.Mon_9, 30, 60, CartoonGlobals.PhantomColour)
                        {
                            MapTarget = p.Location,
                            Direction = p.Direction,
                        };
                    }

                    DXSoundManager.Play(SoundIndex.SummonShinsuEnd);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        public void Process(S.ObjectBuffAdd p)
        {
            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
            {
                if (ob.ObjectID != p.ObjectID) continue;

                ob.VisibleBuffs.Add(p.Type);

                if (p.Type == BuffType.SuperiorMagicShield && ob.MagicShieldEffect != null)
                    ob.MagicShieldEnd();
            }
        }
        public void Process(S.ObjectBuffRemove p)
        {
            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
            {
                if (ob.ObjectID != p.ObjectID) continue;

                if (p.Type == BuffType.VipMapY || p.Type == BuffType.VipMapE || p.Type == BuffType.VipMapS)
                    ob.Huiyuan = 0;

                ob.VisibleBuffs.Remove(p.Type);
                return;
            }
        }
        public void Process(S.ObjectPoison p)
        {
            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
            {
                if (ob.ObjectID != p.ObjectID) continue;

                ob.Poison = p.Poison;
                return;
            }
        }
        public void Process(S.ObjectPetOwnerChanged p)
        {
            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
            {
                if (ob.ObjectID != p.ObjectID) continue;

                if (ob.Race != ObjectType.Monster) return;

                MonsterObject mob = (MonsterObject)ob;
                mob.PetOwner = p.PetOwner;
                return;
            }
        }
        public void Process(S.ObjectStats p)
        {
            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
            {
                if (ob.ObjectID != p.ObjectID) continue;
                
                if (ob.Race == ObjectType.Monster)
                {
                    MonsterObject mob = (MonsterObject) ob;
                    p.Stats.Add(mob.MonsterInfo.Stats);
                }

                ob.Stats= p.Stats;
                return;
            }
        }
        public void Process(S.HealthChanged p)
        {


            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
            {
                if (ob.ObjectID != p.ObjectID) continue;

                ob.CurrentHP += p.Change;
                ob.DrawHealthTime = CEnvir.Now.AddSeconds(300);
                ob.DamageList.Add(new DamageInfo { Value = p.Change, Block = p.Block, Critical = p.Critical, Miss = p.Miss, OneKill = p.Onekill });

                return;
            }
        }

        public void Process(S.NewMagic p)
        {
            MapObject.User.Magics[p.Magic.Info] = p.Magic;

            GameScene.Game.MagicBox.Magics[p.Magic.Info].Refresh();
        }
        public void Process(S.RemoveMagic p)
        {
            
            

            
            
            
        }
        public void Process(S.MagicLeveled p)
        {
            ClientUserMagic clientUserMagic;
            if (MapObject.User.Magics.TryGetValue(p.Info, out clientUserMagic))
            {
                MapObject.User.Magics[p.Info].Level = p.Level;
                MapObject.User.Magics[p.Info].Experience = p.Experience;
                GameScene.Game.MagicBox.Magics[p.Info].Refresh();
            }
        }
        public void Process(S.MagicCooldown p)
        {
            ClientUserMagic clientUserMagic;
            if (MapObject.User.Magics.TryGetValue(p.Info, out clientUserMagic))
                MapObject.User.Magics[p.Info].NextCast = CEnvir.Now.AddMilliseconds(p.Delay);
        }
        public void Process(S.MagicToggle p)
        {

            switch (p.Magic)
            {
                
                
                case MagicType.SpiritSword:
                    if (MapObject.User.Mingwen01 == 5 || MapObject.User.Mingwen02 == 5 || MapObject.User.Mingwen03 == 5)
                        GameScene.Game.User.CanPowersAttack = p.CanUse;
                    else { }
                    break;
                
                
                case MagicType.Swordsmanship:
                    if (MapObject.User.Mingwen01 == 133 || MapObject.User.Mingwen02 == 133 || MapObject.User.Mingwen03 == 133)
                        GameScene.Game.User.CanxuanfengyinAttack = p.CanUse;
                    else { }
                    break;
                case MagicType.Slaying:
                    GameScene.Game.User.CanPowerAttack = p.CanUse;
                    
                    
                    GameScene.Game.User.CanxueshaYinAttack = false;
                    break;
                
                
                case MagicType.XueshaSlaying:
                    if (MapObject.User.Mingwen01 == 139 || MapObject.User.Mingwen02 == 139 || MapObject.User.Mingwen03 == 139)
                        GameScene.Game.User.CanxueshaYinAttack = p.CanUse;
                    break;
                case MagicType.Thrusting:
                    GameScene.Game.User.CanThrusting = p.CanUse;
                    break;
                case MagicType.HalfMoon:
                    GameScene.Game.User.CanHalfMoon = p.CanUse;
                    break;
                
                
                case MagicType.GuanyueHalfMoon:
                    GameScene.Game.User.CanguanyueYinAttack = p.CanUse;
                    break;
                
                
                case MagicType.JiyueHalfMoon:
                    GameScene.Game.User.CanjiyueYinAttack = p.CanUse;
                    break;
                case MagicType.DestructiveSurge:
                    GameScene.Game.User.CanDestructiveBlow = p.CanUse;
                    break;
                case MagicType.FlamingSword:
                    GameScene.Game.User.CanFlamingSword = p.CanUse;
                    if (p.CanUse)
                        GameScene.Game.ReceiveChat("能量在你的武器中积聚，烈火剑法准备就绪.", MessageType.Hint);
                    break;
                case MagicType.DragonRise:
                    GameScene.Game.User.CanDragonRise = p.CanUse;

                    if (p.CanUse)
                        GameScene.Game.ReceiveChat("能量在你的武器中积聚，翔空剑法准备就绪.", MessageType.Hint);
                    break;
                
                
                case MagicType.ShenquDragonRise:
                    GameScene.Game.User.CanShenquYinAttack = p.CanUse;
                    break;
                
                
                case MagicType.ShenglongDragonRise:
                    GameScene.Game.User.CanShenglongYinAttack = p.CanUse;
                    break;
                
                
                case MagicType.ZhanchuiSeismicSlam:
                    GameScene.Game.User.CanZhanchuiYinAttack = p.CanUse;
                    break;
                
                
                case MagicType.TianshenSeismicSlam:
                    GameScene.Game.User.CanTianshenYinAttack = p.CanUse;
                    break;
                case MagicType.BladeStorm:
                    GameScene.Game.User.CanBladeStorm = p.CanUse;
                    if (p.CanUse)
                        GameScene.Game.ReceiveChat("能量在你的武器中积聚，莲月剑法准备就绪.", MessageType.Hint);
                    break;
                case MagicType.FlameSplash:
                    GameScene.Game.User.CanFlameSplash = p.CanUse;
                    break;
                case MagicType.FullBloom:
                case MagicType.WhiteLotus:
                case MagicType.RedLotus:
                case MagicType.SweetBrier:
                case MagicType.Karma:
                    if (GameScene.Game.User.AttackMagic == p.Magic)
                        GameScene.Game.User.AttackMagic = MagicType.None;
                    break;
            }
        }


        public void Process(S.ManaChanged p)
        {
            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
            {
                if (ob.ObjectID != p.ObjectID) continue;

                ob.CurrentMP += p.Change;
                
                return;
            }
        }
        public void Process(S.LevelChanged p)
        {
            MapObject.User.Level = p.Level;
            MapObject.User.Experience = p.Experience;
            GameScene.Game.ReceiveChat("恭喜你升级啦", MessageType.System);
            GameScene.Game.MiniGamesBox.UpdateEvents();

            /*
            if (p.levelled)
            {
                GameScene.Game.ReceiveChat("恭喜你升级啦", MessageType.System);
                GameScene.Game.MiniGamesBox.UpdateEvents();
            }
            else
               GameScene.Game.ReceiveChat("Level Cap Reached, Bonus Hermit Point Gained Experience Has Been Reset", MessageType.System);
               */
        }
        
        public void Process(S.ExpSjian p)
        {
            GameScene.Game.CharacterBox.Jingyanshuaijian.Text = $"— {p.ExpShuaijian}%";
            GameScene.Game.CharacterBox.Jingyanshuaijian.Hint = $"杀怪时会衰减百分比{p.ExpShuaijian}的经验";
        }
        
        public void Process(S.FubenDian p)
        {
            GameScene.Game.User.Fubendian = p.Fubendian;
        }
        
        public void Process(S.HuiyuanUp p)
        {
            GameScene.Game.User.Huiyuan = p.Huiyuan;
        }

        
        public void Process(S.JyhuishoulevelChanged p)
        {
            MapObject.User.Jyhuishoulevel = p.Jyhuishoulevel;
            MapObject.User.Exphuishou = p.Exphuishou;

            GameScene.Game.ReceiveChat($"你的回收等级升{p.Jyhuishoulevel}级啦", MessageType.System);

        }
        public void Process(S.GainedExperience p)
        {
            MapObject.User.Experience += p.Amount;

            ClientUserItem weapon = GameScene.Game.Equipment[(int)EquipmentSlot.Weapon];

            if (p.Amount < 0)
            {
                GameScene.Game.ReceiveChat($"失去经验值{p.Amount:#,##0}", MessageType.Combat);
                return;
            }


            string message = $"得到经验值{p.Amount:#,##0}";

            if (weapon != null && weapon.Info.Effect != ItemEffect.PickAxe && (weapon.Flags & UserItemFlags.Refinable) != UserItemFlags.Refinable && (weapon.Flags & UserItemFlags.NonRefinable) != UserItemFlags.NonRefinable && weapon.Level < CartoonGlobals.WeaponExperienceList.Count)
            {
                weapon.Experience += p.Amount / 10;

                if (weapon.Experience >= CartoonGlobals.WeaponExperienceList[weapon.Level])
                {
                    weapon.Experience = 0;
                    weapon.Level++;
                    weapon.Flags |= UserItemFlags.Refinable;

                    message += ", 你的武器准备好精炼了";
                }
                else
                    message += $" , 武器修炼值{p.Amount / 10:#,##0} ";
            }

            if (!Config.关闭经验提示)
                GameScene.Game.ReceiveChat(message + "", MessageType.Combat);

            GameScene.Game.BigPatchBox.Helper.GainedExperience(p.Amount);
        }

        
        public void Process(S.Gainedhsexperience p)
        {
            MapObject.User.Exphuishou += p.Amount;

            
            if (p.Amount < 0)
            {
                GameScene.Game.ReceiveChat($"失去回收经验值{p.Amount:#,##0}", MessageType.Combat);
                return;
            }

            string message = $"得到回收经验值{p.Amount:#,##0}";
            GameScene.Game.ReceiveChat(message, MessageType.Combat);
            
        }

        
        public void Process(S.GainedShengwang p)
        {
            GameScene.Game.User.Gerenshengwang = p.Shengwang;

            if (p.Amount > 0 && p.MonsterName != null && !p.Sfbaogwming)
            {
                string message = $"你杀死{p.MonsterName}得到了{p.Amount:#,##0}点声望，目前有{p.Shengwang:#,##0}点声望。";
                GameScene.Game.ReceiveChat(message, MessageType.Combat);
            }
            else if (p.Amount > 0 && p.Sfbaogwming)
            {
                string message = $"你得到了{p.Amount:#,##0}点声望，目前有{p.Shengwang:#,##0}点声望。";
                GameScene.Game.ReceiveChat(message, MessageType.Combat);
            }
            else if (p.Amount < 0 && p.Sfbaogwming)
            {
                string message = $"你被扣除{p.Amount:#,##0}点声望，目前剩下{p.Shengwang:#,##0}点声望。";
                GameScene.Game.ReceiveChat(message, MessageType.Combat);
            }
        }

        
        public void Process(S.MingwenUpDate p)
        {
            MingwenInfo Mingweninfo01 = CartoonGlobals.MingwenInfoList.Binding.FirstOrDefault((MingwenInfo x) => x.MingWenID == p.Index01);
            MingwenInfo Mingweninfo02 = CartoonGlobals.MingwenInfoList.Binding.FirstOrDefault((MingwenInfo x) => x.MingWenID == p.Index02);
            MingwenInfo Mingweninfo03 = CartoonGlobals.MingwenInfoList.Binding.FirstOrDefault((MingwenInfo x) => x.MingWenID == p.Index03);

            foreach (KeyValuePair<MagicInfo, MagicCell> pair in GameScene.Game.MagicBox.Magics)
            {
                pair.Value.MingwenIcon01.Visible = false;
                pair.Value.MingwenIcon02.Visible = false;
                pair.Value.MingwenIcon03.Visible = false;

                ClientUserMagic clientUserMagic;

                if (MapObject.User.Magics.TryGetValue(pair.Value.Info, out clientUserMagic))
                {
                    if (clientUserMagic == null) return;

                    if (pair.Value.Info.Magic == Mingweninfo01.Magic && Mingweninfo01.MingWenID != 0)
                    {
                        string text = $"\n{Mingweninfo01.Name}\n\n";
                        text += DXLabel.CutStr(Mingweninfo01.MwJieshi, 15);
                        pair.Value.MingwenIcon01.Visible = p.Kaiqi01;
                        pair.Value.MingwenIcon01.Hint = text;
                    }
                    if (pair.Value.Info.Magic == Mingweninfo02.Magic && Mingweninfo02.MingWenID != 0)
                    {
                        string text = $"\n{Mingweninfo02.Name}\n\n";
                        text += DXLabel.CutStr(Mingweninfo02.MwJieshi, 15);
                        pair.Value.MingwenIcon02.Visible = p.Kaiqi02;
                        pair.Value.MingwenIcon02.Hint = text;
                    }
                    if (pair.Value.Info.Magic == Mingweninfo03.Magic && Mingweninfo03.MingWenID != 0)
                    {
                        string text = $"\n{Mingweninfo03.Name}\n\n";
                        text += DXLabel.CutStr(Mingweninfo03.MwJieshi, 15);
                        pair.Value.MingwenIcon03.Visible = p.Kaiqi03;
                        pair.Value.MingwenIcon03.Hint = text;
                    }
                }
            }

        }

        
        public void Process(S.NPCShenmiSRBuyAmount p)
        {
            GameScene.Game.User.ItemCountyi = p.ItemCountyi;
            GameScene.Game.User.ItemCounter = p.ItemCounter;
            GameScene.Game.User.ItemCountsan = p.ItemCountsan;
            GameScene.Game.User.ItemCountsi = p.ItemCountsi;
            GameScene.Game.User.ItemCountwu = p.ItemCountwu;
            GameScene.Game.User.ItemCountliu = p.ItemCountliu;
            GameScene.Game.User.ItemCountqi = p.ItemCountqi;
            GameScene.Game.User.ItemCountba = p.ItemCountba;
            GameScene.Game.User.ItemCountjiu = p.ItemCountjiu;
            GameScene.Game.User.ItemCountshi = p.ItemCountshi;
        }

        public void Process(S.ObjectLeveled p)
        {
            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
            {
                if (ob.ObjectID != p.ObjectID) continue;

                ob.Effects.Add(new MirEffect(2030, 16, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx, 50, 120, Color.DeepSkyBlue)
                {
                    Blend = true,
                    DrawColour = Color.RosyBrown,
                    Target = ob
                });

                return;
            }
        }
        public void Process(S.ObjectRevive p)
        {
            

            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
            {
                if (ob.ObjectID != p.ObjectID) continue;

                ob.Dead = false;

                ob.ActionQueue.Add(new ObjectAction(MirAction.Standing, ob.Direction, p.Location));

                if (p.Effect)
                    ob.Effects.Add(new MirEffect(1110, 25, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx3, 50, 90, Color.White)
                    {
                        Blend = true,
                        Target = ob
                    });

                GameScene.Game.MapControl.FLayer.TextureValid = false;

                return;
            }
        }

        public void Process(S.ItemsGained p)
        {
            

            foreach (ClientUserItem item in p.Items)
            {
                ItemInfo displayInfo = item.Info;

                if (item.Info.Effect == ItemEffect.Gold)
                {
                    if (GameScene.Game.User.Gold + item.Count <= CartoonGlobals.MaxGold)
                        GameScene.Game.BigPatchBox.Helper.GainedGold(item.Count);
                }

                if (item.Info.Effect == ItemEffect.ItemPart)
                    displayInfo = CartoonGlobals.ItemInfoList.Binding.First(x => x.Index == item.AddedStats[Stat.ItemIndex]);

                item.New = true;
                string text = item.Count > 1 ? $"得到{displayInfo.ItemName}物品（{item.Count}）个." : $"得到{displayInfo.ItemName}.";

                if ((item.Flags & UserItemFlags.QuestItem) == UserItemFlags.QuestItem)
                    text += " (任务)";

                if (item.Info.Effect == ItemEffect.ItemPart)
                    text += " [碎片]";

                GameScene.Game.ReceiveChat(text, MessageType.Combat);
            }
            
            GameScene.Game.AddItems(p.Items);
            GameScene.Game.MiniGamesBox.UpdateEvents();
        }
        public void Process(S.ItemMove p)
        {
            DXItemCell fromCell, toCell;

            switch (p.FromGrid)
            {
                case GridType.Inventory:
                    fromCell = GameScene.Game.InventoryBox.Grid.Grid[p.FromSlot];
                    break;
                case GridType.Equipment:
                    fromCell = GameScene.Game.CharacterBox.Grid[p.FromSlot];
                    break;
              case GridType.Storage:
                    fromCell = GameScene.Game.StorageBox.Grid.Grid[p.FromSlot];
                    break;
                case GridType.GuildStorage:
                    fromCell = GameScene.Game.GuildBox.StorageGrid.Grid[p.FromSlot];
                    break;
                case GridType.CompanionInventory:
                    fromCell = GameScene.Game.CompanionBox.InventoryGrid.Grid[p.FromSlot];
                    break;
                case GridType.CompanionEquipment:
                    fromCell = GameScene.Game.CompanionBox.EquipmentGrid[p.FromSlot];
                    break;
                case GridType.PatchGrid:
                    fromCell = GameScene.Game.InventoryBox.PatchGrid.Grid[p.FromSlot];
                    break;
                
                case GridType.BaoshiItems:
                    fromCell = GameScene.Game.InventoryBox.BaoshiGrid.Grid[p.FromSlot];
                    break;
                default: return;
            }

            switch (p.ToGrid)
            {
                case GridType.Inventory:
                    toCell = GameScene.Game.InventoryBox.Grid.Grid[p.ToSlot];
                    break;
                case GridType.Equipment:
                    toCell = GameScene.Game.CharacterBox.Grid[p.ToSlot];
                    break;
                case GridType.Storage:
                    toCell = GameScene.Game.StorageBox.Grid.Grid[p.ToSlot];
                    break;
                case GridType.GuildStorage:
                    toCell = GameScene.Game.GuildBox.StorageGrid.Grid[p.ToSlot];
                    break;
                case GridType.CompanionInventory:
                    toCell = GameScene.Game.CompanionBox.InventoryGrid.Grid[p.ToSlot];
                    break;
                case GridType.CompanionEquipment:
                    toCell = GameScene.Game.CompanionBox.EquipmentGrid[p.ToSlot];
                    break;
                case GridType.PatchGrid:
                    toCell = GameScene.Game.InventoryBox.PatchGrid.Grid[p.ToSlot];
                    break;
                
                case GridType.BaoshiItems:
                    toCell = GameScene.Game.InventoryBox.BaoshiGrid.Grid[p.ToSlot];
                    break;
                default:
                    return;
            }

            toCell.Locked = false;
            fromCell.Locked = false;

            if (!p.Success) return;


            if (p.FromGrid != p.ToGrid)
            {
                if (p.FromGrid == GridType.Inventory) 
                {
                    if (!fromCell.Item.Info.ShouldLinkInfo)
                    {
                        for (int i = 0; i < GameScene.Game.BeltBox.Links.Length; i++)
                        {
                            ClientBeltLink link = GameScene.Game.BeltBox.Links[i];
                            if (link.LinkItemIndex != fromCell.Item.Index) continue;

                            link.LinkItemIndex = -1;

                            if (i < GameScene.Game.BeltBox.Grid.Grid.Length)
                                GameScene.Game.BeltBox.Grid.Grid[i].QuickItem = null; 

                            if (p.ToGrid == GridType.Equipment && toCell.Item != null) 
                            {
                                link.LinkItemIndex = toCell.Item.Index;

                                if (i < GameScene.Game.BeltBox.Grid.Grid.Length)
                                    GameScene.Game.BeltBox.Grid.Grid[i].QuickItem = toCell.Item; 
                            }

                            if (!GameScene.Game.Observer)
                                CEnvir.Enqueue(new C.BeltLinkChanged { Slot = link.Slot, LinkIndex = link.LinkInfoIndex, LinkItemIndex = link.LinkItemIndex }); 
                        }
                    }
                }
                else if (p.ToGrid == GridType.Inventory && toCell.Item != null) 
                {
                    if (!toCell.Item.Info.ShouldLinkInfo)
                    {
                        for (int i = 0; i < GameScene.Game.BeltBox.Links.Length; i++)
                        {
                            ClientBeltLink link = GameScene.Game.BeltBox.Links[i];
                            if (link.LinkItemIndex != toCell.Item.Index) continue;

                            link.LinkItemIndex = -1;

                            if (i < GameScene.Game.BeltBox.Grid.Grid.Length)
                                GameScene.Game.BeltBox.Grid.Grid[i].QuickItem = null; 

                            if (!GameScene.Game.Observer)
                                CEnvir.Enqueue(new C.BeltLinkChanged { Slot = link.Slot, LinkIndex = link.LinkInfoIndex, LinkItemIndex = link.LinkItemIndex }); 
                        }
                    }
                }
            }

            if (p.MergeItem)
            {
                if (toCell.Item.Count + fromCell.Item.Count <= toCell.Item.Info.StackSize)
                {
                    toCell.Item.Count += fromCell.Item.Count;
                    fromCell.Item = null;
                    toCell.RefreshItem();
                    
                    return;
                }

                fromCell.Item.Count -= fromCell.Item.Info.StackSize - toCell.Item.Count;
                toCell.Item.Count = toCell.Item.Info.StackSize;
                fromCell.RefreshItem();
                toCell.RefreshItem();
                return;
            }

            ClientUserItem temp = toCell.Item;

            toCell.Item = fromCell.Item;
            fromCell.Item = temp;

            GameScene.Game.MiniGamesBox.UpdateEvents();

            
            
        }
        public void Process(GoldChanged p)
        {
            GameScene.Game.User.Gold = p.Gold;
            DXSoundManager.Play(SoundIndex.GoldGained);
        }
        public void Process(GameGoldChanged p)
        {
            GameScene.Game.User.GameGold = p.GameGold;
            DXSoundManager.Play(SoundIndex.GoldGained);
        }
        public void Process(HuntGoldChanged p)
        {
            if (GameScene.Game.User.HuntGold > 0)
            {
                GameScene.Game.BigPatchBox.Helper.GainedHuntGold(p.HuntGold - GameScene.Game.User.HuntGold);
            }
            GameScene.Game.User.HuntGold = p.HuntGold;
            DXSoundManager.Play(SoundIndex.GoldGained);
        }

        public void Process(AutoTimeChanged p)
        {
            GameScene.Game.User.AutoTime = p.AutoTime;
        }

        
        public void Process(HuanhuaGuagouChanged p)
        {
            GameScene.Game.User.HuanhuaGuagou = p.HuanhuaGuagou;
        }

        
        public void Process(Baoshi5433Changed p)
        {
            GameScene.Game.User.BaoshiKaiqi5433 = p.Baoshi5433;
        }

        
        public void Process(JYhuishouChanged p)
        {
            GameScene.Game.User.JYhuishoudengji = p.JYhuishou;
        }
        
        public void Process(ZhuangbeiFenjieChanged p)
        {
            GameScene.Game.User.ZaixianFenjie = p.Fenjie;
        }

        
        public void Process(GuildLevelChanged p)
        {
            GameScene.Game.User.GuildLvKQ = p.GuildLevel;
        }

        
        public void Process(GuanggaolanChanged p)
        {
            GameScene.Game.GuanggaoBox.Visible = p.Shifoukaiqi;
            GameScene.Game.GuanggaoBox.SetClientSize(new Size(p.Kuandu, p.Gaodu));
            GameScene.Game.GuanggaoBox.TitleLabel.Text = p.Biaoti;
        }
        
        public void Process(Qiehuanxunzhaoguaiwumoshi p)
        {
            GameScene.Game.User.XunzhaoGuaiwuMoshi01 = p.Moshi01;
            GameScene.Game.User.XunzhaoGuaiwuMoshi02 = p.Moshi02;
        }

        public void Process(TreasureChest p)
        {
            GameScene.Game.TreasureChestBox.Visible = true;
            GameScene.Game.TreasureChestBox.NumberLabel.Text = string.Format("开启次数：{0}次", p.Count);
            if (p.Cost >= 0)
            {
                GameScene.Game.TreasureChestBox.Reset.Label.Text = string.Format("重置（{0}元宝）", p.Cost);
                GameScene.Game.TreasureChestBox.Reset.Visible = true;
                GameScene.Game.TreasureChestBox.ExplainLabel.Text = "可获得的奖励道具。\n没有想要的奖励道具，\n可以选择重置。";
            }

            else
            {
                GameScene.Game.TreasureChestBox.Reset.Label.Text = string.Format("不能重置", p.Cost);
                GameScene.Game.TreasureChestBox.Reset.Visible = false;
                GameScene.Game.TreasureChestBox.ExplainLabel.Text = "可获得的奖励道具。\n点击决定后选择一个\n宝箱然后双击。";
            }

            for (int index = 0; index < p.Items.Count; ++index)
                GameScene.Game.TreasureChestBox.TreasureGrid[index].ItemGrid[0] = p.Items[index];
        }

        public void Process(TreasureSel p)
        {
            GameScene.Game.LuckDrawBox.GridImage[p.Slot].Visible = false;
            GameScene.Game.LuckDrawBox.TreasureGrid[p.Slot].ItemGrid[0] = p.Item;
            if (p.Count > 0)
            {
                string format = "确定选择奖励道具列表。\n请选择（剩余{0}次），\n（本次需要{1}元宝）。";
                GameScene.Game.LuckDrawBox.ChoiceLabel.Text = string.Format(format, p.Count, p.Cost);
            }
            else
                GameScene.Game.LuckDrawBox.ChoiceLabel.Text = "抽奖机会全部用完！";
        }

        public void Process(S.ItemChanged p)
        {
            DXItemCell[] grid;

            switch (p.Link.GridType)
            {
                case GridType.Inventory:
                    grid = GameScene.Game.InventoryBox.Grid.Grid;
                    break;
                case GridType.Equipment:
                    grid = GameScene.Game.CharacterBox.Grid;
                    break;
                case GridType.Storage:
                    grid = GameScene.Game.StorageBox.Grid.Grid;
                    break;
                case GridType.GuildStorage:
                    grid = GameScene.Game.GuildBox.StorageGrid.Grid;
                    break;
                case GridType.CompanionInventory:
                    grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                    break;
                case GridType.CompanionEquipment:
                    grid = GameScene.Game.CompanionBox.EquipmentGrid;
                    break;
                case GridType.PatchGrid:
                    grid = GameScene.Game.InventoryBox.PatchGrid.Grid;
                    break;
                
                case GridType.BaoshiItems:
                    grid = GameScene.Game.InventoryBox.BaoshiGrid.Grid;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            DXItemCell fromCell = grid[p.Link.Slot];

            fromCell.Locked = false;

            if (!p.Success) return;


            if (!fromCell.Item.Info.ShouldLinkInfo)
            {
                for (int i = 0; i < GameScene.Game.BeltBox.Links.Length; i++)
                {
                    ClientBeltLink link = GameScene.Game.BeltBox.Links[i];
                    if (link.LinkItemIndex != fromCell.Item.Index) continue;

                    link.LinkItemIndex = -1;

                    if (i < GameScene.Game.BeltBox.Grid.Grid.Length)
                        GameScene.Game.BeltBox.Grid.Grid[i].QuickItem = null; 

                    if (!GameScene.Game.Observer)
                        CEnvir.Enqueue(new C.BeltLinkChanged { Slot = link.Slot, LinkIndex = link.LinkInfoIndex, LinkItemIndex = link.LinkItemIndex }); 
                }
            }


            if (p.Link.Count == 0)
                fromCell.Item = null;
            else
                fromCell.Item.Count = p.Link.Count;

            fromCell.RefreshItem();

            GameScene.Game.MiniGamesBox.UpdateEvents();
        }
        public void Process(S.ItemsChanged p)
        {
            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    case GridType.PatchGrid:
                        grid = GameScene.Game.InventoryBox.PatchGrid.Grid;
                        break;
                    
                    case GridType.BaoshiItems:
                        grid = GameScene.Game.InventoryBox.BaoshiGrid.Grid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }



                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;

                if (!p.Success) continue;


                if (!fromCell.Item.Info.ShouldLinkInfo)
                {
                    for (int i = 0; i < GameScene.Game.BeltBox.Links.Length; i++)
                    {
                        ClientBeltLink link = GameScene.Game.BeltBox.Links[i];
                        if (link.LinkItemIndex != fromCell.Item.Index) continue;

                        link.LinkItemIndex = -1;

                        if (i < GameScene.Game.BeltBox.Grid.Grid.Length)
                            GameScene.Game.BeltBox.Grid.Grid[i].QuickItem = null; 

                        if (!GameScene.Game.Observer)
                            CEnvir.Enqueue(new C.BeltLinkChanged { Slot = link.Slot, LinkIndex = link.LinkInfoIndex, LinkItemIndex = link.LinkItemIndex }); 
                    }
                }


                if (cellLinkInfo.Count == fromCell.Item.Count)
                    fromCell.Item = null;
                else
                    fromCell.Item.Count -= cellLinkInfo.Count;

                fromCell.RefreshItem();
            }
        }
        public void Process(S.ItemStatsChanged p)
        {
            DXItemCell[] grid;

            switch (p.GridType)
            {
                case GridType.Inventory:
                    grid = GameScene.Game.InventoryBox.Grid.Grid;
                    break;
                case GridType.Equipment:
                    grid = GameScene.Game.CharacterBox.Grid;
                    break;
                case GridType.Storage:
                    grid = GameScene.Game.StorageBox.Grid.Grid;
                    break;
                case GridType.CompanionInventory:
                    grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                    break;
                case GridType.CompanionEquipment:
                    grid = GameScene.Game.CompanionBox.EquipmentGrid;
                    break;
                case GridType.PatchGrid:
                    grid = GameScene.Game.InventoryBox.PatchGrid.Grid;
                    break;
                
                case GridType.BaoshiItems:
                    grid = GameScene.Game.InventoryBox.BaoshiGrid.Grid;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            DXItemCell fromCell = grid[p.Slot];

            fromCell.Item.AddedStats.Add(p.NewStats);

            if (p.NewStats.Count == 0)
            {
                GameScene.Game.ReceiveChat($"你的 {fromCell.Item.Info.ItemName} 没发生任何改变", MessageType.System);
                return;
            }

            foreach (KeyValuePair<Stat, int> pair in p.NewStats.Values)
            {
                if (pair.Key == Stat.WeaponElement)
                {
                    GameScene.Game.ReceiveChat($"你的 {fromCell.Item.Info.ItemName} 已经生效：新元素 {(Element)fromCell.Item.AddedStats[Stat.WeaponElement]}", MessageType.System);
                    continue;
                }

                string msg = p.NewStats.GetDisplay(pair.Key);

                if (string.IsNullOrEmpty(msg)) continue;

                GameScene.Game.ReceiveChat($"你的 {fromCell.Item.Info.ItemName} 已生效: {msg}", MessageType.System);
            }

            fromCell.RefreshItem();
        }
        public void Process(S.ItemStatsRefreshed p)
        {
            DXItemCell[] grid;

            switch (p.GridType)
            {
                case GridType.Inventory:
                    grid = GameScene.Game.InventoryBox.Grid.Grid;
                    break;
                case GridType.Equipment:
                    grid = GameScene.Game.CharacterBox.Grid;
                    break;
                case GridType.Storage:
                    grid = GameScene.Game.StorageBox.Grid.Grid;
                    break;
                case GridType.CompanionInventory:
                    grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                    break;
                case GridType.CompanionEquipment:
                    grid = GameScene.Game.CompanionBox.EquipmentGrid;
                    break;
                case GridType.PatchGrid:
                    grid = GameScene.Game.InventoryBox.PatchGrid.Grid;
                    break;
                
                case GridType.BaoshiItems:
                    grid = GameScene.Game.InventoryBox.BaoshiGrid.Grid;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            DXItemCell fromCell = grid[p.Slot];

            fromCell.Item.AddedStats = p.NewStats;

            fromCell.RefreshItem();
        }
        public void Process(S.ItemInfoRefreshed p)
        {
            DXItemCell[] grid;

            switch (p.GridType)
            {
                case GridType.Inventory:
                    grid = GameScene.Game.InventoryBox.Grid.Grid;
                    break;
                case GridType.Equipment:
                    grid = GameScene.Game.CharacterBox.Grid;
                    break;
                case GridType.Storage:
                    grid = GameScene.Game.StorageBox.Grid.Grid;
                    break;
                case GridType.CompanionInventory:
                    grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                    break;
                case GridType.CompanionEquipment:
                    grid = GameScene.Game.CompanionBox.EquipmentGrid;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            DXItemCell fromCell = grid[p.Slot];

            fromCell.Item.Info = p.NewInfo;

            fromCell.RefreshItem();
        }
        public void Process(S.ItemDurability p)
        {
            DXItemCell[] grid;

            switch (p.GridType)
            {
                case GridType.Inventory:
                    grid = GameScene.Game.InventoryBox.Grid.Grid;
                    break;
                case GridType.Equipment:
                    grid = GameScene.Game.CharacterBox.Grid;
                    break;
                case GridType.Storage:
                    grid = GameScene.Game.StorageBox.Grid.Grid;
                    break;
                case GridType.CompanionInventory:
                    grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                    break;
                case GridType.CompanionEquipment:
                    grid = GameScene.Game.CompanionBox.EquipmentGrid;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }


            DXItemCell fromCell = grid[p.Slot];

            fromCell.Item.CurrentDurability = p.CurrentDurability;

            
            if (p.CurrentDurability == 0)
            {
                GameScene.Game.ReceiveChat($"你的 {fromCell.Item.Info.ItemName} 持久下降为 0", MessageType.System);
                
                if (fromCell.Item.Info.ItemType == ItemType.DarkStone) return;

                if (Config.SpecialRepair)
                {
                    DXItemCell dxItemCell = ((IEnumerable<DXItemCell>)GameScene.Game.InventoryBox.Grid.Grid).FirstOrDefault(x => x?.Item?.Info.ItemName == "一键特殊修理药水");
                    GameScene.Game.ReceiveChat("你用自动特修功能，将身上的所有装备进行特修完毕。", MessageType.System);
                    if (dxItemCell != null && dxItemCell.UseItem())
                        _protecttime = CEnvir.Now.AddSeconds(5.0);
                }
            }
            fromCell.RefreshItem();
        }
        public void Process(S.StatsUpdate p)
        {
            MapObject.User.HermitPoints = p.HermitPoints;
            MapObject.User.Stats = p.Stats;
            MapObject.User.HermitStats = p.HermitStats;
        }
        public void Process(S.ItemUseDelay p)
        {
            GameScene.Game.UseItemTime = CEnvir.Now + p.Delay;
        }
        public void Process(S.ItemSplit p)
        {
            

            DXItemCell fromCell;

            switch (p.Grid)
            {
                case GridType.Inventory:
                    fromCell = GameScene.Game.InventoryBox.Grid.Grid[p.Slot];
                    break;
                case GridType.Storage:
                    fromCell = GameScene.Game.StorageBox.Grid.Grid[p.Slot];
                    break;
                case GridType.GuildStorage:
                    fromCell = GameScene.Game.GuildBox.StorageGrid.Grid[p.Slot];
                    break;
                case GridType.CompanionInventory:
                    fromCell = GameScene.Game.CompanionBox.InventoryGrid.Grid[p.Slot];
                    break;
                case GridType.CompanionEquipment:
                    fromCell = GameScene.Game.CompanionBox.EquipmentGrid[p.Slot];
                    break;
                case GridType.PatchGrid:
                    fromCell = GameScene.Game.InventoryBox.PatchGrid.Grid[p.Slot];
                    break;
                
                case GridType.BaoshiItems:
                    fromCell = GameScene.Game.InventoryBox.BaoshiGrid.Grid[p.Slot];
                    break;
                default: return;
            }

            fromCell.Locked = false;

            if (!p.Success) return;

            DXItemCell toCell;
            switch (p.Grid)
            {
                case GridType.Inventory:
                    toCell = GameScene.Game.InventoryBox.Grid.Grid[p.NewSlot];
                    break;
                case GridType.Storage:
                    toCell = GameScene.Game.StorageBox.Grid.Grid[p.NewSlot];
                    break;
                case GridType.GuildStorage:
                    toCell = GameScene.Game.GuildBox.StorageGrid.Grid[p.NewSlot];
                    break;
                case GridType.CompanionInventory:
                    toCell = GameScene.Game.CompanionBox.InventoryGrid.Grid[p.NewSlot];
                    break;
                case GridType.CompanionEquipment:
                    toCell = GameScene.Game.CompanionBox.EquipmentGrid[p.NewSlot];
                    break;
                case GridType.PatchGrid:
                    toCell = GameScene.Game.InventoryBox.PatchGrid.Grid[p.NewSlot];
                    break;
                
                case GridType.BaoshiItems:
                    toCell = GameScene.Game.InventoryBox.BaoshiGrid.Grid[p.NewSlot];
                    break;
                default: return;
            }


            ClientUserItem item = new ClientUserItem(fromCell.Item, p.Count) { Slot = p.NewSlot };

            toCell.Item = item;
            toCell.RefreshItem();

            if (p.Count == fromCell.Item.Count)
                fromCell.Item = null;
            else
                fromCell.Item.Count -= p.Count;

            fromCell.RefreshItem();


        }
        public void Process(S.ItemLock p)
        {
            DXItemCell cell;

            switch (p.Grid)
            {
                case GridType.Inventory:
                    cell = GameScene.Game.InventoryBox.Grid.Grid[p.Slot];
                    break;
                case GridType.Equipment:
                    cell = GameScene.Game.CharacterBox.Grid[p.Slot];
                    break;
                case GridType.Storage:
                    cell = GameScene.Game.StorageBox.Grid.Grid[p.Slot];
                    break;
                /*    case GridType.GuildStorage:
                      fromCell = GameScene.Game.GuildPanel.StorageControl.Grid[p.FromSlot];
                      break;*/
                case GridType.CompanionInventory:
                    cell = GameScene.Game.CompanionBox.InventoryGrid.Grid[p.Slot];
                    break;
                case GridType.CompanionEquipment:
                    cell = GameScene.Game.CompanionBox.EquipmentGrid[p.Slot];
                    break;
                case GridType.PatchGrid:
                    cell = GameScene.Game.InventoryBox.PatchGrid.Grid[p.Slot];
                    break;
                
                case GridType.BaoshiItems:
                    cell = GameScene.Game.InventoryBox.BaoshiGrid.Grid[p.Slot];
                    break;
                default: return;
            }

            if (cell.Item == null) return;

            if (p.Locked)
                cell.Item.Flags |= UserItemFlags.Locked;
            else
                cell.Item.Flags &= ~UserItemFlags.Locked;

            cell.RefreshItem();
        }
        public void Process(S.ItemExperience p)
        {
            DXItemCell cell;

            switch (p.Target.GridType)
            {
                case GridType.Inventory:
                    cell = GameScene.Game.InventoryBox.Grid.Grid[p.Target.Slot];
                    break;
                case GridType.Equipment:
                    cell = GameScene.Game.CharacterBox.Grid[p.Target.Slot];
                    break;
                case GridType.Storage:
                    cell = GameScene.Game.StorageBox.Grid.Grid[p.Target.Slot];
                    break;
                case GridType.CompanionInventory:
                    cell = GameScene.Game.CompanionBox.InventoryGrid.Grid[p.Target.Slot];
                    break;
                case GridType.CompanionEquipment:
                    cell = GameScene.Game.CompanionBox.EquipmentGrid[p.Target.Slot];
                    break;
                case GridType.PatchGrid:
                    cell = GameScene.Game.InventoryBox.PatchGrid.Grid[p.Target.Slot];
                    break;
                
                case GridType.BaoshiItems:
                    cell = GameScene.Game.InventoryBox.BaoshiGrid.Grid[p.Target.Slot];
                    break;
                default: return;
            }

            if (cell.Item == null) return;

            cell.Item.Experience = p.Experience;
            cell.Item.Level = p.Level;
            cell.Item.Flags = p.Flags;

            
            cell.Item.MingwenExp = p.MingwenExp;
            cell.Item.MingwenLv = p.MingwenLv;

            cell.Item.BaoshiMaYi = p.BaoshiMaYi;
            cell.Item.BaoshiMaEr = p.BaoshiMaEr;
            cell.Item.BaoshiMaSan = p.BaoshiMaSan;
            cell.Item.BaoshiMaSi = p.BaoshiMaSi;
            cell.Item.BaoshiMaWu = p.BaoshiMaWu;
            cell.Item.BaoshiMaLiu = p.BaoshiMaLiu;
            cell.Item.BaoshiMaQi = p.BaoshiMaQi;
            cell.Item.BaoshiMaBa = p.BaoshiMaBa;
            cell.Item.BaoshiMaJiu = p.BaoshiMaJiu;
            cell.Item.BaoshiMaShi = p.BaoshiMaShi;
            cell.Item.BaoshiMaShiyi = p.BaoshiMaShiyi;
            cell.Item.BaoshiMaShier = p.BaoshiMaShier;
            cell.Item.BaoshiMaShisan = p.BaoshiMaShisan;
            cell.Item.BaoshiMaShisi = p.BaoshiMaShisi;
            
            cell.Item.MingwenMaYi = p.MingwenMaYi;
            cell.Item.MingwenMaEr = p.MingwenMaEr;
            cell.Item.MingwenMaSan = p.MingwenMaSan;
            cell.Item.MingwenMaSi = p.MingwenMaSi;
            cell.Item.MingwenMaWu = p.MingwenMaWu;
            cell.Item.MingwenMaLiu = p.MingwenMaLiu;
            cell.Item.MingwenMaQi = p.MingwenMaQi;
            cell.Item.MingwenMaBa = p.MingwenMaBa;
            cell.Item.MingwenMaJiu = p.MingwenMaJiu;
            cell.Item.MingwenMaShi = p.MingwenMaShi;
            cell.Item.MingwenMaShiyi = p.MingwenMaShiyi;
            cell.Item.MingwenMaShier = p.MingwenMaShier;
            cell.Item.MingwenMaShisan = p.MingwenMaShisan;
            cell.Item.MingwenMaShisi = p.MingwenMaShisi;
            cell.Item.MingwenMaShiwu = p.MingwenMaShiwu;
            cell.Item.MingwenMaShiliu = p.MingwenMaShiliu;
            cell.Item.MingwenMaShiqi = p.MingwenMaShiqi;
            cell.Item.MingwenMaShiba = p.MingwenMaShiba;
            cell.Item.MingwenMaShijiu = p.MingwenMaShijiu;
            cell.Item.MingwenMaErshi = p.MingwenMaErshi;
            cell.Item.MingwenMaErshiyi = p.MingwenMaErshiyi;
            cell.Item.MingwenMaErshier = p.MingwenMaErshier;
            cell.Item.MingwenMaErshisan = p.MingwenMaErshisan;
            cell.Item.MingwenMaErshisi = p.MingwenMaErshisi;
            cell.Item.MingwenMaErshiwu = p.MingwenMaErshiwu;
            cell.Item.MingwenMaErshiliu = p.MingwenMaErshiliu;
            cell.Item.MingwenMaErshiqi = p.MingwenMaErshiqi;
            cell.Item.MingwenMaErshiba = p.MingwenMaErshiba;
            cell.Item.MingwenMaErshijiu = p.MingwenMaErshijiu;
            cell.Item.MingwenMaSanshi = p.MingwenMaSanshi;

            cell.RefreshItem();

            
            if (GameScene.Game.NPCMingwenBox.TargetCell.Grid[0].Item != null)
            {
                GameScene.Game.NPCMingwenBox.processlabel();
            }

        }

        public void Process(S.ItemsExperience p)
        {
            DXItemCell cell;

            switch (p.Grid)
            {
                case GridType.Inventory:
                    cell = GameScene.Game.InventoryBox.Grid.Grid[p.Slot];
                    break;
                case GridType.Equipment:
                    cell = GameScene.Game.CharacterBox.Grid[p.Slot];
                    break;
                case GridType.Storage:
                    cell = GameScene.Game.StorageBox.Grid.Grid[p.Slot];
                    break;
                case GridType.CompanionInventory:
                    cell = GameScene.Game.CompanionBox.InventoryGrid.Grid[p.Slot];
                    break;
                case GridType.CompanionEquipment:
                    cell = GameScene.Game.CompanionBox.EquipmentGrid[p.Slot];
                    break;
                case GridType.PatchGrid:
                    cell = GameScene.Game.InventoryBox.PatchGrid.Grid[p.Slot];
                    break;
                
                case GridType.BaoshiItems:
                    cell = GameScene.Game.InventoryBox.BaoshiGrid.Grid[p.Slot];
                    break;
                default: return;
            }

            if (cell.Item == null) return;

            cell.Item.Experience = p.Experience;
            cell.Item.Level = p.Level;
            cell.Item.Flags = p.Flags;

            
            cell.Item.MingwenExp = p.MingwenExp;
            cell.Item.MingwenLv = p.MingwenLv;

            cell.Item.BaoshiMaYi = p.BaoshiMaYi;
            cell.Item.BaoshiMaEr = p.BaoshiMaEr;
            cell.Item.BaoshiMaSan = p.BaoshiMaSan;
            cell.Item.BaoshiMaSi = p.BaoshiMaSi;
            cell.Item.BaoshiMaWu = p.BaoshiMaWu;
            cell.Item.BaoshiMaLiu = p.BaoshiMaLiu;
            cell.Item.BaoshiMaQi = p.BaoshiMaQi;
            cell.Item.BaoshiMaBa = p.BaoshiMaBa;
            cell.Item.BaoshiMaJiu = p.BaoshiMaJiu;
            cell.Item.BaoshiMaShi = p.BaoshiMaShi;
            cell.Item.BaoshiMaShiyi = p.BaoshiMaShiyi;
            cell.Item.BaoshiMaShier = p.BaoshiMaShier;
            cell.Item.BaoshiMaShisan = p.BaoshiMaShisan;
            cell.Item.BaoshiMaShisi = p.BaoshiMaShisi;
            
            cell.Item.MingwenMaYi = p.MingwenMaYi;
            cell.Item.MingwenMaEr = p.MingwenMaEr;
            cell.Item.MingwenMaSan = p.MingwenMaSan;
            cell.Item.MingwenMaSi = p.MingwenMaSi;
            cell.Item.MingwenMaWu = p.MingwenMaWu;
            cell.Item.MingwenMaLiu = p.MingwenMaLiu;
            cell.Item.MingwenMaQi = p.MingwenMaQi;
            cell.Item.MingwenMaBa = p.MingwenMaBa;
            cell.Item.MingwenMaJiu = p.MingwenMaJiu;
            cell.Item.MingwenMaShi = p.MingwenMaShi;
            cell.Item.MingwenMaShiyi = p.MingwenMaShiyi;
            cell.Item.MingwenMaShier = p.MingwenMaShier;
            cell.Item.MingwenMaShisan = p.MingwenMaShisan;
            cell.Item.MingwenMaShisi = p.MingwenMaShisi;
            cell.Item.MingwenMaShiwu = p.MingwenMaShiwu;
            cell.Item.MingwenMaShiliu = p.MingwenMaShiliu;
            cell.Item.MingwenMaShiqi = p.MingwenMaShiqi;
            cell.Item.MingwenMaShiba = p.MingwenMaShiba;
            cell.Item.MingwenMaShijiu = p.MingwenMaShijiu;
            cell.Item.MingwenMaErshi = p.MingwenMaErshi;
            cell.Item.MingwenMaErshiyi = p.MingwenMaErshiyi;
            cell.Item.MingwenMaErshier = p.MingwenMaErshier;
            cell.Item.MingwenMaErshisan = p.MingwenMaErshisan;
            cell.Item.MingwenMaErshisi = p.MingwenMaErshisi;
            cell.Item.MingwenMaErshiwu = p.MingwenMaErshiwu;
            cell.Item.MingwenMaErshiliu = p.MingwenMaErshiliu;
            cell.Item.MingwenMaErshiqi = p.MingwenMaErshiqi;
            cell.Item.MingwenMaErshiba = p.MingwenMaErshiba;
            cell.Item.MingwenMaErshijiu = p.MingwenMaErshijiu;
            cell.Item.MingwenMaSanshi = p.MingwenMaSanshi;

            cell.RefreshItem();

        }

        public void Process(S.Chat p)
        {
            if (GameScene.Game == null) return;

            
            if (p.Items == null) GameScene.Game.ReceiveChat(p.Text, p.Type);
            else GameScene.Game.ReceiveChat(p.Text, p.Type, p.Items);

            if (p.Type != MessageType.Normal || p.ObjectID <= 0) return;

            

            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
            {
                if (ob.ObjectID != p.ObjectID) continue;

                ob.Chat(p.Text);

                return;
            }
        }
        
        public void Process(TestGj p)
        {
            if (GameScene.Game == null)
                return;

            GameScene.Game.FangGuajiBox.Visible = true;
            GameScene.Game.FangGuajiBox.Label.Text = p.Text;
            GameScene.Game.FangGuajiBox.ConfirmButton.Enabled = false;
            GameScene.Game.FangGuajiBox.ShowTimeSpan = CEnvir.Now + p.AnswerTime;
            GameScene.Game.FangGuajiBox.Modal = false;

            GameScene.Game.FangGuajiBox.ShowTimeLabel.Text = string.Format("请注意，剩余回答时间为{0:#,##0.0}秒", (object)(int)(GameScene.Game.FangGuajiBox.ShowTimeSpan - CEnvir.Now).TotalSeconds);
            GameScene.Game.FangGuajiBox.ValueTextBox.TextBox.TextChanged += (EventHandler)((value, obj1) => GameScene.Game.FangGuajiBox.ConfirmButton.Enabled = GameScene.Game.FangGuajiBox.ValueTextBox.TextBox.Text != "");
            GameScene.Game.FangGuajiBox.ConfirmButton.MouseClick += (EventHandler<MouseEventArgs>)((value, obj1) =>
            {
                ClientAnswerTestGj clientAnswerTestGj = new ClientAnswerTestGj();
                clientAnswerTestGj.Answer = GameScene.Game.FangGuajiBox.Value;
                CEnvir.Enqueue((Packet)clientAnswerTestGj);
            });
        }

        public void Process(ZidongGjguanbi p)
        {
            GameScene.Game.User.Zdgjgongneng = p.Zdgjgongneng;
        }

        public void Process(S.NPCResponse p)
        {
            GameScene.Game.NPCBox.Response(p);
        }
        public void Process(S.NPCRepair p)
        {
            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {

                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.GuildStorage:
                        if (GameScene.Game.Observer) continue;

                        grid = GameScene.Game.GuildBox.StorageGrid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }



                DXItemCell cell = grid[cellLinkInfo.Slot];

                cell.Locked = false;

                if (!p.Success) continue;

                cell.Link = null;

                if (p.Special)
                {
                    cell.Item.CurrentDurability = cell.Item.MaxDurability;
                    if (cell.Item.Info.ItemType != ItemType.Weapon && p.SpecialRepairDelay > TimeSpan.Zero)
                        cell.Item.NextSpecialRepair = CEnvir.Now.Add(p.SpecialRepairDelay);
                }
                else
                {
                    cell.Item.MaxDurability = Math.Max(0, cell.Item.MaxDurability - (cell.Item.MaxDurability - cell.Item.CurrentDurability) / CartoonGlobals.DuraLossRate);
                    cell.Item.CurrentDurability = cell.Item.MaxDurability;
                }

                cell.RefreshItem();
            }
        }
        public void Process(S.NPCRefine p)
        {
            foreach (CellLinkInfo cellLinkInfo in p.Ores)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }



                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;

                if (!p.Success) continue;


                if (!fromCell.Item.Info.ShouldLinkInfo)
                {
                    for (int i = 0; i < GameScene.Game.BeltBox.Links.Length; i++)
                    {
                        ClientBeltLink link = GameScene.Game.BeltBox.Links[i];
                        if (link.LinkItemIndex != fromCell.Item.Index) continue;

                        link.LinkItemIndex = -1;

                        if (i < GameScene.Game.BeltBox.Grid.Grid.Length)
                            GameScene.Game.BeltBox.Grid.Grid[i].QuickItem = null; 

                        if (!GameScene.Game.Observer)
                            CEnvir.Enqueue(new C.BeltLinkChanged { Slot = link.Slot, LinkIndex = link.LinkInfoIndex, LinkItemIndex = link.LinkItemIndex }); 
                    }
                }


                if (cellLinkInfo.Count == fromCell.Item.Count)
                    fromCell.Item = null;
                else
                    fromCell.Item.Count -= cellLinkInfo.Count;

                fromCell.RefreshItem();
            }

            foreach (CellLinkInfo cellLinkInfo in p.Items)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    case GridType.PatchGrid:
                        grid = GameScene.Game.InventoryBox.PatchGrid.Grid;
                        break;
                    
                    case GridType.BaoshiItems:
                        grid = GameScene.Game.InventoryBox.BaoshiGrid.Grid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }



                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;

                if (!p.Success) continue;


                if (!fromCell.Item.Info.ShouldLinkInfo)
                {
                    for (int i = 0; i < GameScene.Game.BeltBox.Links.Length; i++)
                    {
                        ClientBeltLink link = GameScene.Game.BeltBox.Links[i];
                        if (link.LinkItemIndex != fromCell.Item.Index) continue;

                        link.LinkItemIndex = -1;

                        if (i < GameScene.Game.BeltBox.Grid.Grid.Length)
                            GameScene.Game.BeltBox.Grid.Grid[i].QuickItem = null; 

                        if (!GameScene.Game.Observer)
                            CEnvir.Enqueue(new C.BeltLinkChanged { Slot = link.Slot, LinkIndex = link.LinkInfoIndex, LinkItemIndex = link.LinkItemIndex }); 
                    }
                }


                if (cellLinkInfo.Count == fromCell.Item.Count)
                    fromCell.Item = null;
                else
                    fromCell.Item.Count -= cellLinkInfo.Count;

                fromCell.RefreshItem();
            }

            foreach (CellLinkInfo cellLinkInfo in p.Specials)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    case GridType.PatchGrid:
                        grid = GameScene.Game.InventoryBox.PatchGrid.Grid;
                        break;
                    
                    case GridType.BaoshiItems:
                        grid = GameScene.Game.InventoryBox.BaoshiGrid.Grid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }


                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;

                if (!p.Success) continue;


                if (!fromCell.Item.Info.ShouldLinkInfo)
                {
                    for (int i = 0; i < GameScene.Game.BeltBox.Links.Length; i++)
                    {
                        ClientBeltLink link = GameScene.Game.BeltBox.Links[i];
                        if (link.LinkItemIndex != fromCell.Item.Index) continue;

                        link.LinkItemIndex = -1;

                        if (i < GameScene.Game.BeltBox.Grid.Grid.Length)
                            GameScene.Game.BeltBox.Grid.Grid[i].QuickItem = null; 

                        if (!GameScene.Game.Observer)
                            CEnvir.Enqueue(new C.BeltLinkChanged { Slot = link.Slot, LinkIndex = link.LinkInfoIndex, LinkItemIndex = link.LinkItemIndex }); 
                    }
                }


                if (cellLinkInfo.Count == fromCell.Item.Count)
                    fromCell.Item = null;
                else
                    fromCell.Item.Count -= cellLinkInfo.Count;

                fromCell.RefreshItem();
            }

            if (p.Success)
            {
                DXItemCell fromCell = GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Weapon];
                fromCell.Item = null;
                fromCell.RefreshItem();

                GameScene.Game.ReceiveChat($"你的武器升级工作已完成，请收回你的武器 {Functions.ToString(CartoonGlobals.RefineTimes[p.RefineQuality], false)}", MessageType.System);
            }
        }
        public void Process(S.NPCMasterRefine p)
        {
            foreach (CellLinkInfo cellLinkInfo in p.Fragment1s)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }



                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;

                if (!p.Success) continue;


                if (!fromCell.Item.Info.ShouldLinkInfo)
                {
                    for (int i = 0; i < GameScene.Game.BeltBox.Links.Length; i++)
                    {
                        ClientBeltLink link = GameScene.Game.BeltBox.Links[i];
                        if (link.LinkItemIndex != fromCell.Item.Index) continue;

                        link.LinkItemIndex = -1;

                        if (i < GameScene.Game.BeltBox.Grid.Grid.Length)
                            GameScene.Game.BeltBox.Grid.Grid[i].QuickItem = null; 

                        if (!GameScene.Game.Observer)
                            CEnvir.Enqueue(new C.BeltLinkChanged { Slot = link.Slot, LinkIndex = link.LinkInfoIndex, LinkItemIndex = link.LinkItemIndex }); 
                    }
                }


                if (cellLinkInfo.Count == fromCell.Item.Count)
                    fromCell.Item = null;
                else
                    fromCell.Item.Count -= cellLinkInfo.Count;

                fromCell.RefreshItem();
            }

            foreach (CellLinkInfo cellLinkInfo in p.Fragment2s)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }



                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;

                if (!p.Success) continue;


                if (!fromCell.Item.Info.ShouldLinkInfo)
                {
                    for (int i = 0; i < GameScene.Game.BeltBox.Links.Length; i++)
                    {
                        ClientBeltLink link = GameScene.Game.BeltBox.Links[i];
                        if (link.LinkItemIndex != fromCell.Item.Index) continue;

                        link.LinkItemIndex = -1;

                        if (i < GameScene.Game.BeltBox.Grid.Grid.Length)
                            GameScene.Game.BeltBox.Grid.Grid[i].QuickItem = null; 

                        if (!GameScene.Game.Observer)
                            CEnvir.Enqueue(new C.BeltLinkChanged { Slot = link.Slot, LinkIndex = link.LinkInfoIndex, LinkItemIndex = link.LinkItemIndex }); 
                    }
                }


                if (cellLinkInfo.Count == fromCell.Item.Count)
                    fromCell.Item = null;
                else
                    fromCell.Item.Count -= cellLinkInfo.Count;

                fromCell.RefreshItem();
            }

            foreach (CellLinkInfo cellLinkInfo in p.Fragment3s)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }


                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;

                if (!p.Success) continue;


                if (!fromCell.Item.Info.ShouldLinkInfo)
                {
                    for (int i = 0; i < GameScene.Game.BeltBox.Links.Length; i++)
                    {
                        ClientBeltLink link = GameScene.Game.BeltBox.Links[i];
                        if (link.LinkItemIndex != fromCell.Item.Index) continue;

                        link.LinkItemIndex = -1;

                        if (i < GameScene.Game.BeltBox.Grid.Grid.Length)
                            GameScene.Game.BeltBox.Grid.Grid[i].QuickItem = null; 

                        if (!GameScene.Game.Observer)
                            CEnvir.Enqueue(new C.BeltLinkChanged { Slot = link.Slot, LinkIndex = link.LinkInfoIndex, LinkItemIndex = link.LinkItemIndex }); 
                    }
                }


                if (cellLinkInfo.Count == fromCell.Item.Count)
                    fromCell.Item = null;
                else
                    fromCell.Item.Count -= cellLinkInfo.Count;

                fromCell.RefreshItem();
            }

            foreach (CellLinkInfo cellLinkInfo in p.Stones)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }


                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;

                if (!p.Success) continue;


                if (!fromCell.Item.Info.ShouldLinkInfo)
                {
                    for (int i = 0; i < GameScene.Game.BeltBox.Links.Length; i++)
                    {
                        ClientBeltLink link = GameScene.Game.BeltBox.Links[i];
                        if (link.LinkItemIndex != fromCell.Item.Index) continue;

                        link.LinkItemIndex = -1;

                        if (i < GameScene.Game.BeltBox.Grid.Grid.Length)
                            GameScene.Game.BeltBox.Grid.Grid[i].QuickItem = null; 

                        if (!GameScene.Game.Observer)
                            CEnvir.Enqueue(new C.BeltLinkChanged { Slot = link.Slot, LinkIndex = link.LinkInfoIndex, LinkItemIndex = link.LinkItemIndex }); 
                    }
                }


                if (cellLinkInfo.Count == fromCell.Item.Count)
                    fromCell.Item = null;
                else
                    fromCell.Item.Count -= cellLinkInfo.Count;

                fromCell.RefreshItem();
            }

            foreach (CellLinkInfo cellLinkInfo in p.Specials)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    case GridType.PatchGrid:
                        grid = GameScene.Game.InventoryBox.PatchGrid.Grid;
                        break;
                    
                    case GridType.BaoshiItems:
                        grid = GameScene.Game.InventoryBox.BaoshiGrid.Grid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }


                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;

                if (!p.Success) continue;


                if (!fromCell.Item.Info.ShouldLinkInfo)
                {
                    for (int i = 0; i < GameScene.Game.BeltBox.Links.Length; i++)
                    {
                        ClientBeltLink link = GameScene.Game.BeltBox.Links[i];
                        if (link.LinkItemIndex != fromCell.Item.Index) continue;

                        link.LinkItemIndex = -1;

                        if (i < GameScene.Game.BeltBox.Grid.Grid.Length)
                            GameScene.Game.BeltBox.Grid.Grid[i].QuickItem = null; 

                        if (!GameScene.Game.Observer)
                            CEnvir.Enqueue(new C.BeltLinkChanged { Slot = link.Slot, LinkIndex = link.LinkInfoIndex, LinkItemIndex = link.LinkItemIndex }); 
                    }
                }


                if (cellLinkInfo.Count == fromCell.Item.Count)
                    fromCell.Item = null;
                else
                    fromCell.Item.Count -= cellLinkInfo.Count;

                fromCell.RefreshItem();
            }
        }
        public void Process(S.RefineList p)
        {
            GameScene.Game.NPCRefineRetrieveBox.Refines.AddRange(p.List);
        }
        public void Process(S.NPCRefineRetrieve p)
        {
            foreach (ClientRefineInfo info in GameScene.Game.NPCRefineRetrieveBox.Refines)
            {
                if (info.Index != p.Index) continue;

                GameScene.Game.NPCRefineRetrieveBox.Refines.Remove(info);
                break;
            }

            GameScene.Game.NPCRefineRetrieveBox.RefreshList();
        }
        public void Process(S.NPCClose p)
        {
            

            GameScene.Game.NPCBox.Visible = false;
        }
        public void Process(S.NPCAccessoryLevelUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        
        public void Process(S.NPCDunLevelUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        
        public void Process(S.NPCHuiLevelUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        
        public void Process(S.NPCMingwenUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        public void Process(S.NPCGZLKaikongUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        public void Process(S.NPCGZLBKaikongUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        public void Process(S.NPCQTKaikongUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        public void Process(S.NPCXiangKanGJSTUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }

        
        public void Process(S.Zhongzi p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        
        public void Process(S.NPCDunUpgradeFY p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        
        public void Process(S.NPCDunUpgradeMY p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        
        public void Process(S.NPCDunUpgradeSM p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        
        public void Process(S.NPCDunUpgradeMF p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }

        
        public void Process(S.NPCHuiUpgradeGJ p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        
        public void Process(S.NPCHuiUpgradeZR p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        
        public void Process(S.NPCHuiUpgradeLH p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }

        public void Process(S.NPCXiangKanGJBSTUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }

        public void Process(S.NPCXiangKanZRSTUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }

        public void Process(S.NPCXiangKanZRBSTUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }

        public void Process(S.NPCXiangKanLHSTUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }

        public void Process(S.NPCXiangKanLHBSTUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }

        public void Process(S.NPCXiangKanSMSTUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }

        public void Process(S.NPCXiangKanMFSTUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }

        public void Process(S.NPCXiangKanSDSTUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }

        public void Process(S.NPCXiangKanFYSTUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }

        public void Process(S.NPCXiangKanMYSTUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }

        
        public void Process(S.NPCXiangKanjinglianUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        
        public void Process(S.NPCHuanhuaUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        public void Process(S.NPCChaichustUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        public void Process(S.NPCXiangkanjystUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        public void Process(S.NPCXiangkanxxstUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        public void Process(S.NPCXiangKanghuoUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        public void Process(S.NPCXiangKangbingUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        public void Process(S.NPCXiangKangleiUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        public void Process(S.NPCXiangKangfengUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        public void Process(S.NPCXiangKangshenUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        public void Process(S.NPCXiangKanganUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        public void Process(S.NPCXiangKanghuanUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        public void Process(S.NPCXiangKanmofadunUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        public void Process(S.NPCXiangKanbingdongUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        public void Process(S.NPCXiangKanmabiUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        public void Process(S.NPCXiangKanyidongUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        public void Process(S.NPCXiangKanchenmoUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        public void Process(S.NPCXiangKangedangUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        public void Process(S.NPCXiangKanduobiUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        public void Process(S.NPCXiangKanqhuoUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        public void Process(S.NPCXiangKanqbingUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        public void Process(S.NPCXiangKanqleiUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        public void Process(S.NPCXiangKanqfengUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        public void Process(S.NPCXiangKanqshenUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        public void Process(S.NPCXiangKanqanUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        public void Process(S.NPCXiangKanqhuanUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        public void Process(S.NPCXiangKanlvduUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        public void Process(S.NPCXiangKanzymUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }
        public void Process(S.NPCXiangKanmhhfUp p)
        {
            if (p.Target != null)
                p.Links.Add(p.Target);

            foreach (CellLinkInfo cellLinkInfo in p.Links)
            {
                DXItemCell[] grid;

                switch (cellLinkInfo.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                DXItemCell fromCell = grid[cellLinkInfo.Slot];
                fromCell.Locked = false;
            }
        }

        public void Process(S.GroupSwitch p)
        {
            GameScene.Game.GroupBox.AllowGroup = p.Allow;
        }
        public void Process(S.GroupMember p)
        {
            GameScene.Game.GroupBox.Members.Add(new ClientPlayerInfo { ObjectID = p.ObjectID, Name = p.Name, Class = p.Class });


            GameScene.Game.ReceiveChat($"-{p.Name} 加入小组.", MessageType.Group);

            GameScene.Game.GroupBox.UpdateMembers();

            
            GameScene.Game.PartyListBox.PopulateMembers();

            ClientObjectData data;
            if (!GameScene.Game.DataDictionary.TryGetValue(p.ObjectID, out data)) return;

            GameScene.Game.BigMapBox.Update(data);
            GameScene.Game.MiniMapBox.Update(data);

        }
        public void Process(S.GroupRemove p)
        {
            ClientPlayerInfo info = GameScene.Game.GroupBox.Members.First(x => x.ObjectID == p.ObjectID);
            
            GameScene.Game.ReceiveChat($"-{info.Name} 离开小组.", MessageType.Group);

            HashSet<uint> checks = new HashSet<uint>();
            
            if (p.ObjectID == MapObject.User.ObjectID)
            {
                foreach (ClientPlayerInfo member in GameScene.Game.GroupBox.Members)
                    checks.Add(member.ObjectID);

                GameScene.Game.GroupBox.Members.Clear();
            }
            else
            {
                checks.Add(p.ObjectID);
                GameScene.Game.GroupBox.Members.Remove(info);
            }

            GameScene.Game.GroupBox.UpdateMembers();

            foreach (uint objectID in checks)
            {
                ClientObjectData data;
                if (!GameScene.Game.DataDictionary.TryGetValue(objectID, out data)) return;

                GameScene.Game.BigMapBox.Update(data);
                GameScene.Game.MiniMapBox.Update(data);
            }
        }
        public void Process(S.GroupInvite p)
        {
            

            DXMessageBox messageBox = new DXMessageBox($"你想和 {p.Name} 组队吗? ", "组队邀请", DXMessageBoxButtons.YesNo);
            
            messageBox.YesButton.MouseClick += (o, e) => CEnvir.Enqueue(new C.GroupResponse { Accept = true });
            messageBox.NoButton.MouseClick += (o, e) => CEnvir.Enqueue(new C.GroupResponse { Accept = false });
            messageBox.CloseButton.MouseClick += (o, e) => CEnvir.Enqueue(new C.GroupResponse { Accept = false });
            messageBox.Modal = false;
            messageBox.CloseButton.Visible = false;
            
        }
        
        public void Process(S.BuffAdd p)
        {
            MapObject.User.Buffs.Add(p.Buff);
            MapObject.User.VisibleBuffs.Add(p.Buff.Type);

            GameScene.Game.BuffBox.BuffsChanged();
        }
        public void Process(S.BuffRemove p)
        {
            foreach (ClientBuffInfo buff in MapObject.User.Buffs)
            {
                if (buff.Index != p.Index) continue;

                MapObject.User.Buffs.Remove(buff);
                MapObject.User.VisibleBuffs.Remove(buff.Type);
                break;
            }
            
            GameScene.Game.BuffBox.BuffsChanged();
        }
        public void Process(S.BuffChanged p)
        {
            MapObject.User.Buffs.First(x => x.Index == p.Index).Stats = p.Stats;

            GameScene.Game.BuffBox.BuffsChanged();
        }
        public void Process(S.BuffTime p)
        {
            MapObject.User.Buffs.First(x => x.Index == p.Index).RemainingTime = p.Time;

            GameScene.Game.BuffBox.BuffsChanged();
        }
        public void Process(S.BuffPaused p)
        {
            

            MapObject.User.Buffs.First(x => x.Index == p.Index).Pause = p.Paused;

            GameScene.Game.BuffBox.BuffsChanged();
        }

        
        
        
        
        public void Process(S.SafeZoneChanged P)
        {
            MapObject.User.InSafeZone = P.InSafeZone;

            GameScene.Game.SafeZoneChanged(P.InSafeZone);


        }
        public void Process(S.CombatTime p)
        {
            GameScene.Game.User.CombatTime = CEnvir.Now;
        }

        public void Process(S.Inspect p)
        {
            

            GameScene.Game.InspectBox.NewInformation(p);

        }
        public void Process(S.Rankings p)
        {
            (DXControl.ActiveScene as LoginScene)?.RankingBox.Update(p);
            GameScene.Game?.RankingBox.Update(p);
        }
        
        public void Process(S.GuildRankings p)
        {
            (DXControl.ActiveScene as LoginScene)?.GuildRankingBox.Update(p);
            GameScene.Game?.GuildRankingBox.Update(p);
        }
        
        public void Process(S.GuildGerenRankings p)
        {
            (DXControl.ActiveScene as LoginScene)?.GuildGerenBox.Update(p);
            GameScene.Game?.GuildGerenBox.Update(p);
        }
        public void Process(S.StartObserver p)
        {
            CEnvir.FillStorage(p.Items, true);

            int index = 0;

            if (GameScene.Game != null)
                index = GameScene.Game.RankingBox.StartIndex;

            DXControl.ActiveScene.Dispose();

            DXSoundManager.StopAllSounds();

            GameScene scene = new GameScene(Config.GameSize);
            DXControl.ActiveScene = scene;
            GameScene.Game.Observer = true;

            scene.MapControl.MapInfo = CartoonGlobals.MapInfoList.Binding.FirstOrDefault(x => x.Index == p.StartInformation.MapIndex);
            GameScene.Game.QuestLog = p.StartInformation.Quests;

            GameScene.Game.MeiriQuestLog = p.StartInformation.MeiriQuests;

            GameScene.Game.NPCAdoptCompanionBox.AvailableCompanions = p.StartInformation.AvailableCompanions;
            GameScene.Game.NPCAdoptCompanionBox.RefreshUnlockButton();

            GameScene.Game.NPCCompanionStorageBox.Companions = p.StartInformation.Companions;
            GameScene.Game.NPCCompanionStorageBox.UpdateScrollBar();

            GameScene.Game.Companion = GameScene.Game.NPCCompanionStorageBox.Companions.FirstOrDefault(x => x.Index == p.StartInformation.Companion);

            GameScene.Game.PatchGridSize = p.StartInformation.PatchGridSize;

            
            GameScene.Game.BaoshiGridSize = p.StartInformation.BaoshiGridSize;


            scene.User = new UserObject(p.StartInformation);

            GameScene.Game.StorageSize = p.StartInformation.StorageSize;

            GameScene.Game.BuffBox.BuffsChanged();

            GameScene.Game.RankingBox.StartIndex = index;

            
            GameScene.Game.processlabel();
            GameScene.Game.FubenBox?.CreateTabs();
        }
        public void Process(S.ObservableSwitch p)
        {
            

            GameScene.Game.RankingBox.Observable = p.Allow;
        }

        public void Process(MarketPlaceHistory p)
        {
            switch (p.Display)
            {
                case 1:
                    DXTextBox.MirTextBox textBox1 = GameScene.Game.MarketPlaceBox.SearchNumberSoldBox.TextBox;
                    long num1;
                    string str1;
                    if (p.SaleCount <= 0L)
                    {
                        str1 = "没有记录";
                    }
                    else
                    {
                        num1 = p.SaleCount;
                        str1 = num1.ToString("#,##0");
                    }
                    textBox1.Text = str1;
                    DXTextBox.MirTextBox textBox2 = GameScene.Game.MarketPlaceBox.SearchAveragePriceBox.TextBox;
                    string str2;
                    if (p.AveragePrice <= 0L)
                    {
                        str2 = "没有记录";
                    }
                    else
                    {
                        num1 = p.AveragePrice;
                        str2 = num1.ToString("#,##0");
                    }
                    textBox2.Text = str2;
                    DXTextBox.MirTextBox textBox3 = GameScene.Game.MarketPlaceBox.SearchLastPriceBox.TextBox;
                    string str3;
                    if (p.LastPrice <= 0L)
                    {
                        str3 = "没有记录";
                    }
                    else
                    {
                        num1 = p.LastPrice;
                        str3 = num1.ToString("#,##0");
                    }
                    textBox3.Text = str3;
                    DXTextBox.MirTextBox textBox4 = GameScene.Game.MarketPlaceBox.SearchGameGoldAveragePriceBox.TextBox;
                    string str4;
                    if (p.GameGoldAveragePrice <= 0L)
                    {
                        str4 = "没有记录";
                    }
                    else
                    {
                        num1 = p.GameGoldAveragePrice;
                        str4 = num1.ToString("#,##0");
                    }
                    textBox4.Text = str4;
                    DXTextBox.MirTextBox textBox5 = GameScene.Game.MarketPlaceBox.SearchGameGoldLastPriceBox.TextBox;
                    string str5;
                    if (p.GameGoldLastPrice <= 0L)
                    {
                        str5 = "没有记录";
                    }
                    else
                    {
                        num1 = p.GameGoldLastPrice;
                        str5 = num1.ToString("#,##0");
                    }
                    textBox5.Text = str5;
                    break;
                case 2:
                    DXTextBox.MirTextBox textBox6 = GameScene.Game.MarketPlaceBox.NumberSoldBox.TextBox;
                    long num2;
                    string str6;
                    if (p.SaleCount <= 0L)
                    {
                        str6 = "没有记录";
                    }
                    else
                    {
                        num2 = p.SaleCount;
                        str6 = num2.ToString("#,##0");
                    }
                    textBox6.Text = str6;
                    DXTextBox.MirTextBox textBox7 = GameScene.Game.MarketPlaceBox.AveragePriceBox.TextBox;
                    string str7;
                    if (p.AveragePrice <= 0L)
                    {
                        str7 = "没有记录";
                    }
                    else
                    {
                        num2 = p.AveragePrice;
                        str7 = num2.ToString("#,##0");
                    }
                    textBox7.Text = str7;
                    DXTextBox.MirTextBox textBox8 = GameScene.Game.MarketPlaceBox.LastPriceBox.TextBox;
                    string str8;
                    if (p.LastPrice <= 0L)
                    {
                        str8 = "没有记录";
                    }
                    else
                    {
                        num2 = p.LastPrice;
                        str8 = num2.ToString("#,##0");
                    }
                    textBox8.Text = str8;
                    DXTextBox.MirTextBox textBox9 = GameScene.Game.MarketPlaceBox.AveragePriceBox1.TextBox;
                    string str9;
                    if (p.GameGoldAveragePrice <= 0L)
                    {
                        str9 = "没有记录";
                    }
                    else
                    {
                        num2 = p.GameGoldAveragePrice;
                        str9 = num2.ToString("#,##0");
                    }
                    textBox9.Text = str9;
                    DXTextBox.MirTextBox textBox10 = GameScene.Game.MarketPlaceBox.LastPriceBox1.TextBox;
                    string str10;
                    if (p.GameGoldLastPrice <= 0L)
                    {
                        str10 = "没有记录";
                    }
                    else
                    {
                        num2 = p.GameGoldLastPrice;
                        str10 = num2.ToString("#,##0");
                    }
                    textBox10.Text = str10;
                    break;
            }
        }

        public void Process(Library.Network.ServerPackets.MarketPlaceConsign p)
        {
            GameScene.Game.MarketPlaceBox.ConsignItems.AddRange((IEnumerable<ClientMarketPlaceInfo>)p.Consignments);
            GameScene.Game.MarketPlaceBox.RefreshConsignList();
        }

        public void Process(Library.Network.ServerPackets.MarketPlaceSearch p)
        {
            GameScene.Game.MarketPlaceBox.SearchResults = new ClientMarketPlaceInfo[p.Count];
            for (int index = 0; index < p.Results.Count; ++index)
                GameScene.Game.MarketPlaceBox.SearchResults[index] = p.Results[index];
            GameScene.Game.MarketPlaceBox.RefreshList();
        }

        public void Process(MarketPlaceSearchCount p)
        {
            Array.Resize<ClientMarketPlaceInfo>(ref GameScene.Game.MarketPlaceBox.SearchResults, p.Count);
            GameScene.Game.MarketPlaceBox.RefreshList();
        }

        public void Process(Library.Network.ServerPackets.MarketPlaceSearchIndex p)
        {
            if (GameScene.Game.MarketPlaceBox.SearchResults == null)
                return;
            GameScene.Game.MarketPlaceBox.SearchResults[p.Index] = p.Result;
            GameScene.Game.MarketPlaceBox.RefreshList();
        }

        public void Process(MarketPlaceConsignChanged p)
        {
            ClientMarketPlaceInfo clientMarketPlaceInfo = GameScene.Game.MarketPlaceBox.ConsignItems.FirstOrDefault<ClientMarketPlaceInfo>((Func<ClientMarketPlaceInfo, bool>)(x => x.Index == p.Index));
            if (clientMarketPlaceInfo == null)
                return;
            if (p.Count > 0L)
                clientMarketPlaceInfo.Item.Count = p.Count;
            else
                GameScene.Game.MarketPlaceBox.ConsignItems.Remove(clientMarketPlaceInfo);
            GameScene.Game.MarketPlaceBox.RefreshConsignList();
        }

        public void Process(Library.Network.ServerPackets.MarketPlaceBuy p)
        {
            GameScene.Game.MarketPlaceBox.BuyButton.Enabled = true;
            if (!p.Success)
                return;
            ClientMarketPlaceInfo clientMarketPlaceInfo = ((IEnumerable<ClientMarketPlaceInfo>)GameScene.Game.MarketPlaceBox.SearchResults).FirstOrDefault<ClientMarketPlaceInfo>((Func<ClientMarketPlaceInfo, bool>)(x =>
            {
                if (x != null)
                    return x.Index == p.Index;
                return false;
            }));
            if (clientMarketPlaceInfo == null)
                return;
            if (p.Count > 0L)
                clientMarketPlaceInfo.Item.Count = p.Count;
            else
                clientMarketPlaceInfo.Item = (ClientUserItem)null;
            GameScene.Game.MarketPlaceBox.RefreshList();
        }

        public void Process(Library.Network.ServerPackets.MarketPlaceStoreBuy p)
        {
            GameScene.Game.MarketPlaceBox.StoreBuyButton.Enabled = true;
        }


        public void Process(S.MailList p)
        {
            
            
            GameScene.Game.MailBox.MailList.AddRange(p.Mail);
            GameScene.Game.MailBox.UpdateIcon();
        }
        public void Process(S.MailNew p)
        {
            


            GameScene.Game.MailBox.MailList.Insert(0, p.Mail);
            GameScene.Game.MailBox.RefreshList();
            GameScene.Game.MailBox.UpdateIcon();
            GameScene.Game.ReceiveChat("你收到一封新邮件来自" + p.Mail.Sender + "。", MessageType.System);
        }
        public void Process(S.MailDelete p)
        {
            
            
            ClientMailInfo mail = GameScene.Game.MailBox.MailList.FirstOrDefault(x => x.Index == p.Index);

            if (mail == null) return;

            GameScene.Game.MailBox.MailList.Remove(mail);
            GameScene.Game.MailBox.RefreshList();
            GameScene.Game.MailBox.UpdateIcon();

            if (mail == GameScene.Game.ReadMailBox.Mail)
                GameScene.Game.ReadMailBox.Mail = null;
        }

        public void Process(S.MailItemDelete p)
        {
            

            ClientMailInfo mail = GameScene.Game.MailBox.MailList.FirstOrDefault(x => x.Index == p.Index);

            if (mail == null) return;

            ClientUserItem item = mail.Items.FirstOrDefault(x => x.Slot == p.Slot);

            if (item != null)
            {
                mail.Items.Remove(item);

                foreach (MailRow row in GameScene.Game.MailBox.Rows)
                {
                    if (row.Mail != mail) continue;

                    row.RefreshIcon();
                    break;
                }
            }

            GameScene.Game.MailBox.UpdateIcon();

            if (mail != GameScene.Game.ReadMailBox.Mail) return;

            foreach (DXItemCell cell in GameScene.Game.ReadMailBox.Grid.Grid)
            {
                if (cell.Slot != p.Slot) continue;

                cell.Item = null;
                break;
            }
        }
        public void Process(S.MailSend p)
        {
            

            GameScene.Game.SendMailBox.SendAttempted = false;
        }

        public void Process(S.ChangeAttackMode p)
        {
            

            GameScene.Game.User.AttackMode = p.Mode;

            GameScene.Game.ReceiveChat(GameScene.Game.MainPanel.AttackModeLabel.Text, MessageType.System);

        }
        public void Process(S.ChangePetMode p)
        {
            

            GameScene.Game.User.PetMode = p.Mode;

            GameScene.Game.ReceiveChat(GameScene.Game.MainPanel.PetModeLabel.Text, MessageType.System);

        }

        public void Process(S.WeightUpdate p)
        {
            

            GameScene.Game.User.BagWeight = p.BagWeight;
            GameScene.Game.User.WearWeight = p.WearWeight;
            GameScene.Game.User.HandWeight = p.HandWeight;

            GameScene.Game.WeightChanged();
        }


        public void Process(S.TradeRequest p)
        {
            

            DXMessageBox messageBox = new DXMessageBox($"{p.Name} 想与你进行交易，你是否接受? ", "交易请求", DXMessageBoxButtons.YesNo);

            messageBox.YesButton.MouseClick += (o, e) => CEnvir.Enqueue(new C.TradeRequestResponse { Accept = true });
            messageBox.NoButton.MouseClick += (o, e) => CEnvir.Enqueue(new C.TradeRequestResponse { Accept = false });
            messageBox.CloseButton.MouseClick += (o, e) => CEnvir.Enqueue(new C.TradeRequestResponse { Accept = false });
        }
        public void Process(S.TradeOpen p)
        {
            
            
            GameScene.Game.TradeBox.Visible = true;
            GameScene.Game.TradeBox.IsTrading = true;
            GameScene.Game.TradeBox.PlayerLabel.Text = p.Name;
        }
        public void Process(S.TradeClose p)
        {
            

            GameScene.Game.TradeBox.Visible = false;
            GameScene.Game.TradeBox.Clear();
        }
        public void Process(S.TradeAddItem p)
        {
            

            DXItemCell fromCell;
            
            switch (p.Cell.GridType)
            {
                case GridType.Inventory:
                    fromCell = GameScene.Game.InventoryBox.Grid.Grid[p.Cell.Slot];
                    break;
                case GridType.Equipment:
                    fromCell = GameScene.Game.CharacterBox.Grid[p.Cell.Slot];
                    break;
                case GridType.Storage:
                    fromCell = GameScene.Game.StorageBox.Grid.Grid[p.Cell.Slot];
                    break;
                /*    case GridType.GuildStorage:
                      fromCell = GameScene.Game.GuildPanel.StorageControl.Grid[p.FromSlot];
                      break;*/
                case GridType.CompanionInventory:
                    fromCell = GameScene.Game.CompanionBox.InventoryGrid.Grid[p.Cell.Slot];
                    break;
                case GridType.CompanionEquipment:
                    fromCell = GameScene.Game.CompanionBox.EquipmentGrid[p.Cell.Slot];
                    break;
                case GridType.PatchGrid:
                    fromCell = GameScene.Game.InventoryBox.PatchGrid.Grid[p.Cell.Slot];
                    break;
                
                case GridType.BaoshiItems:
                    fromCell = GameScene.Game.InventoryBox.BaoshiGrid.Grid[p.Cell.Slot];
                    break;
                default: return;
            }


            if (!p.Success)
            {
                fromCell.Link = null;
                return;
            }

            if (fromCell.Link != null) return;
            
            foreach (DXItemCell cell in GameScene.Game.TradeBox.UserGrid.Grid)
            {
                if (cell.Item != null) continue;

                cell.LinkedCount = p.Cell.Count;
                cell.Link = fromCell;
                return;
            }

        }
        public void Process(S.TradeItemAdded p)
        {
            

            foreach (DXItemCell cell in GameScene.Game.TradeBox.PlayerGrid.Grid)
            {
                if (cell.Item != null) continue;

                cell.Item = p.Item;
                return;
            }
        }
        public void Process(S.TradeAddGold p)
        {
            

            GameScene.Game.TradeBox.UserGoldLabel.Text = p.Gold.ToString("#,##0");
        }
        public void Process(S.TradeGoldAdded p)
        {
            

            GameScene.Game.TradeBox.PlayerGoldLabel.Text = p.Gold.ToString("#,##0");
        }
        public void Process(S.TradeUnlock p)
        {
            

            GameScene.Game.TradeBox.ConfirmButton.Enabled = true;
        }

        public void Process(S.GuildCreate p)
        {
            

            GameScene.Game.GuildBox.CreateAttempted = false;
        }
        public void Process(S.GuildInfo p)
        {
            HashSet<uint> checks = new HashSet<uint>();

            if (GameScene.Game.GuildBox.GuildInfo != null)
            {
                foreach (ClientGuildMemberInfo member in GameScene.Game.GuildBox.GuildInfo.Members)
                    if (member.ObjectID > 0)
                        checks.Add(member.ObjectID);
            }

            GameScene.Game.GuildBox.GuildInfo = p.Guild;

            if (GameScene.Game.GuildBox.GuildInfo != null)
            {
                foreach (ClientGuildMemberInfo member in GameScene.Game.GuildBox.GuildInfo.Members)
                    if (member.ObjectID > 0)
                        checks.Add(member.ObjectID);
            }

            foreach (uint objectID in checks)
            {
                ClientObjectData data;
                if (!GameScene.Game.DataDictionary.TryGetValue(objectID, out data)) return;

                GameScene.Game.BigMapBox.Update(data);
                GameScene.Game.MiniMapBox.Update(data);
            }
        }
        public void Process(S.GuildNoticeChanged p)
        {
            

            GameScene.Game.GuildBox.GuildInfo.Notice = p.Notice;

            if (!GameScene.Game.GuildBox.NoticeTextBox.Editable)
                GameScene.Game.GuildBox.NoticeTextBox.TextBox.Text = p.Notice;
        }
        public void Process(S.GuildGetItem p)
        {
            


            DXItemCell[] grid;

            switch (p.Grid)
            {
                case GridType.Inventory:
                    grid = GameScene.Game.InventoryBox.Grid.Grid;
                    break;
                case GridType.Equipment:
                    grid = GameScene.Game.CharacterBox.Grid;
                    break;
                case GridType.Storage:
                    grid = GameScene.Game.StorageBox.Grid.Grid;
                    break;
                case GridType.GuildStorage:
                    grid = GameScene.Game.GuildBox.StorageGrid.Grid;
                    break;
                case GridType.CompanionInventory:
                    grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                    break;
                case GridType.CompanionEquipment:
                    grid = GameScene.Game.CompanionBox.EquipmentGrid;
                    break;
                case GridType.PatchGrid:
                    grid = GameScene.Game.InventoryBox.PatchGrid.Grid;
                    break;
                
                case GridType.BaoshiItems:
                    grid = GameScene.Game.InventoryBox.BaoshiGrid.Grid;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }


            DXItemCell fromCell = grid[p.Slot];

            fromCell.Item = p.Item;
        }
        public void Process(S.GuildNewItem p)
        {
            
            
            GameScene.Game.GuildBox.StorageGrid.Grid[p.Slot].Item = p.Item;
        }
        public void Process(S.GuildUpdate p)
        {
            GameScene.Game.GuildBox.GuildInfo.GuildFunds = p.GuildFunds;
            GameScene.Game.GuildBox.GuildInfo.DailyGrowth = p.DailyGrowth;

            GameScene.Game.GuildBox.GuildInfo.GuildLevel = p.GuildLevel;

            GameScene.Game.GuildBox.GuildInfo.TotalContribution = p.TotalContribution;
            GameScene.Game.GuildBox.GuildInfo.DailyContribution = p.DailyContribution;

            GameScene.Game.GuildBox.GuildInfo.JyTotalContribution = p.JyTotalContribution;


            GameScene.Game.GuildBox.GuildInfo.MemberLimit = p.MemberLimit;
            GameScene.Game.GuildBox.GuildInfo.StorageLimit = p.StorageLimit;

            GameScene.Game.GuildBox.GuildInfo.Tax = p.Tax;

            GameScene.Game.GuildBox.GuildInfo.DefaultPermission = p.DefaultPermission;
            GameScene.Game.GuildBox.GuildInfo.DefaultRank = p.DefaultRank;
            
            
            GameScene.Game.GuildBox.GuildInfo.ShuangGongxian = p.ShuangGongxian;
            if (GameScene.Game.GuildBox.GuildInfo.ShuangGongxian == 2 || GameScene.Game.GuildBox.GuildInfo.ShuangGongxian == 3)
            {
                GameScene.Game.GuildBox.YiGongxiangIcon.Visible = true;

                if (GameScene.Game.GuildBox.GuildInfo.ShuangGongxian == 2)
                {
                    GameScene.Game.GuildBox.YiGongxiangIcon.Index = 8036;
                    GameScene.Game.GuildBox.YiGongxiangIcon.Hint = "1.5倍贡献回收";
                }
                else if (GameScene.Game.GuildBox.GuildInfo.ShuangGongxian == 3)
                {
                    GameScene.Game.GuildBox.YiGongxiangIcon.Index = 8037;
                    GameScene.Game.GuildBox.YiGongxiangIcon.Hint = "2倍贡献回收";
                }

            }
            else
                GameScene.Game.GuildBox.YiGongxiangIcon.Visible = false;


            
            GameScene.Game.GuildBox.GuildInfo.GuildBosshd01 = p.GuildBosshd01;
            if (GameScene.Game.GuildBox.GuildInfo.GuildBosshd01 == 1)
            {
                GameScene.Game.GuildBox.HuodongmingdanLabel.Text = "没开启";
                GameScene.Game.GuildBox.HuodongmingdanLabel.ForeColour = Color.Yellow;
            }
            else if (GameScene.Game.GuildBox.GuildInfo.GuildBosshd01 == 2)
            {
                GameScene.Game.GuildBox.HuodongmingdanLabel.Text = "开启中";
                GameScene.Game.GuildBox.HuodongmingdanLabel.ForeColour = Color.Lime;
            }
            else if (GameScene.Game.GuildBox.GuildInfo.GuildBosshd01 == 3)
            {
                GameScene.Game.GuildBox.HuodongmingdanLabel.Text = "已关闭";
                GameScene.Game.GuildBox.HuodongmingdanLabel.ForeColour = Color.LightCoral;
            }
            
            GameScene.Game.GuildBox.GuildInfo.GuildBosshdrenshu = p.GuildBosshdrenshu;
            GameScene.Game.GuildBox.GuildBossHdrenshuLabel.Text = $"{ GameScene.Game.GuildBox.GuildInfo.GuildBosshdrenshu }";

            
            GameScene.Game.GuildBox.GuildInfo.GuildQuanhd02 = p.GuildQuanhd02;
            if (GameScene.Game.GuildBox.GuildInfo.GuildQuanhd02 == 1)
            {
                GameScene.Game.GuildBox.GuildQuanLabel.Text = "没开启";
                GameScene.Game.GuildBox.GuildQuanLabel.ForeColour = Color.Yellow;
            }
            else if (GameScene.Game.GuildBox.GuildInfo.GuildQuanhd02 == 2)
            {
                GameScene.Game.GuildBox.GuildQuanLabel.Text = "开启中";
                GameScene.Game.GuildBox.GuildQuanLabel.ForeColour = Color.Lime;
            }
            else if (GameScene.Game.GuildBox.GuildInfo.GuildQuanhd02 == 3)
            {
                GameScene.Game.GuildBox.GuildQuanLabel.Text = "已关闭";
                GameScene.Game.GuildBox.GuildQuanLabel.ForeColour = Color.LightCoral;
            }
            
            GameScene.Game.GuildBox.GuildInfo.GuildQuanhdrenshu = p.GuildQuanhdrenshu;
            GameScene.Game.GuildBox.GuildQuanrenshuLabel.Text = $"{ GameScene.Game.GuildBox.GuildInfo.GuildQuanhdrenshu }";

            
            GameScene.Game.GuildBox.GuildInfo.GuildFubenhd03 = p.GuildFubenhd03;
            if (GameScene.Game.GuildBox.GuildInfo.GuildFubenhd03 == 1)
            {
                GameScene.Game.GuildBox.GuildFubenLabel.Text = "没开启";
                GameScene.Game.GuildBox.GuildFubenLabel.ForeColour = Color.Yellow;
            }
            else if (GameScene.Game.GuildBox.GuildInfo.GuildFubenhd03 == 2)
            {
                GameScene.Game.GuildBox.GuildFubenLabel.Text = "开启中";
                GameScene.Game.GuildBox.GuildFubenLabel.ForeColour = Color.Lime;
            }
            else if (GameScene.Game.GuildBox.GuildInfo.GuildFubenhd03 == 3)
            {
                GameScene.Game.GuildBox.GuildFubenLabel.Text = "已关闭";
                GameScene.Game.GuildBox.GuildFubenLabel.ForeColour = Color.LightCoral;
            }
            
            GameScene.Game.GuildBox.GuildInfo.GuildFubenhdrenshu = p.GuildFubenhdrenshu;
            GameScene.Game.GuildBox.GuildFubenrenshuLabel.Text = $"{ GameScene.Game.GuildBox.GuildInfo.GuildFubenhdrenshu }";

            
            GameScene.Game.GuildBox.GuildInfo.GuildJiachenghd04 = p.GuildJiachenghd04;
            if (GameScene.Game.GuildBox.GuildInfo.GuildJiachenghd04 == 1)
            {
                GameScene.Game.GuildBox.GuildJiachengLabel.Text = "没开启";
                GameScene.Game.GuildBox.GuildJiachengLabel.ForeColour = Color.Yellow;
            }
            else if (GameScene.Game.GuildBox.GuildInfo.GuildJiachenghd04 == 2)
            {
                GameScene.Game.GuildBox.GuildJiachengLabel.Text = "开启中";
                GameScene.Game.GuildBox.GuildJiachengLabel.ForeColour = Color.Lime;
            }
            else if (GameScene.Game.GuildBox.GuildInfo.GuildJiachenghd04 == 3)
            {
                GameScene.Game.GuildBox.GuildJiachengLabel.Text = "已关闭";
                GameScene.Game.GuildBox.GuildJiachengLabel.ForeColour = Color.LightCoral;
            }
            
            GameScene.Game.GuildBox.GuildInfo.GuildJiachenghdrenshu = p.GuildJiachenghdrenshu;
            GameScene.Game.GuildBox.GuildJiachengrenshuLabel.Text = $"{ GameScene.Game.GuildBox.GuildInfo.GuildJiachenghdrenshu }";



            foreach (ClientGuildMemberInfo member in p.Members)
            {
                ClientGuildMemberInfo info = GameScene.Game.GuildBox.GuildInfo.Members.FirstOrDefault(x => x.Index == member.Index);

                if (info == null)
                {
                    info = new ClientGuildMemberInfo
                    {
                        Index = member.Index,
                        Name = member.Name,
                    };
                    GameScene.Game.GuildBox.GuildInfo.Members.Add(info);
                }


                info.JyTotalContribution = member.JyTotalContribution;

                info.TotalContribution = member.TotalContribution;
                info.DailyContribution = member.DailyContribution;
                info.LastOnline = member.LastOnline;
                info.Permission = member.Permission;
                info.Rank = member.Rank;
                info.ObjectID = member.ObjectID;

                if (info.Index == GameScene.Game.GuildBox.GuildInfo.UserIndex)
                    GameScene.Game.GuildBox.PermissionChanged();
                
                ClientObjectData data;
                if (!GameScene.Game.DataDictionary.TryGetValue(member.ObjectID, out data)) continue;

                GameScene.Game.BigMapBox.Update(data);
                GameScene.Game.MiniMapBox.Update(data);
            }

            if (GameScene.Game.GuildBox.Visible)
                GameScene.Game.GuildBox.RefreshGuildDisplay();
        }
        public void Process(S.GuildKick p)
        {
            

            ClientGuildMemberInfo info = GameScene.Game.GuildBox.GuildInfo.Members.First(x => x.Index == p.Index);

            GameScene.Game.GuildBox.GuildInfo.Members.Remove(info);

            if (GameScene.Game.GuildBox.Visible)
                GameScene.Game.GuildBox.RefreshGuildDisplay();


            ClientObjectData data;
            if (!GameScene.Game.DataDictionary.TryGetValue(info.ObjectID, out data)) return;

            GameScene.Game.BigMapBox.Update(data);
            GameScene.Game.MiniMapBox.Update(data);
        }
        public void Process(S.GuildIncreaseMember p)
        {
            

            GameScene.Game.GuildBox.IncreaseMemberButton.Enabled = true;
        }
        public void Process(S.GuildIncreaseStorage p)
        {
            GameScene.Game.GuildBox.IncreaseStorageButton.Enabled = true;
        }
        public void Process(S.GuildInviteMember p)
        {
            

            GameScene.Game.GuildBox.AddMemberTextBox.Enabled = true;
            GameScene.Game.GuildBox.AddMemberButton.Enabled = true;
        }
        public void Process(S.GuildTax p)
        {
            

            GameScene.Game.GuildBox.GuildTaxBox.Enabled = true;
            GameScene.Game.GuildBox.SetTaxButton.Enabled = true;
        }

        public void Process(S.GuildMemberOffline p)
        {
            

            ClientGuildMemberInfo info = GameScene.Game.GuildBox.GuildInfo.Members.First(x => x.Index == p.Index);

            info.LastOnline = CEnvir.Now;
            info.ObjectID = 0;

            if (GameScene.Game.GuildBox.Visible)
                GameScene.Game.GuildBox.RefreshGuildDisplay();

        }
        public void Process(S.GuildInvite p)
        {
            

            DXMessageBox messageBox = new DXMessageBox($"{p.Name} 邀请你加入公会 {p.GuildName}\n" +
                                                       $"你想加入公会吗? ", "公会邀请", DXMessageBoxButtons.YesNo);

            messageBox.YesButton.MouseClick += (o, e) => CEnvir.Enqueue(new C.GuildResponse { Accept = true });
            messageBox.NoButton.MouseClick += (o, e) => CEnvir.Enqueue(new C.GuildResponse { Accept = false });
            messageBox.CloseButton.MouseClick += (o, e) => CEnvir.Enqueue(new C.GuildResponse { Accept = false });
            messageBox.Modal = false;
            messageBox.CloseButton.Visible = false;
            
        }
        public void Process(S.GuildMemberOnline p)
        {
            

            ClientGuildMemberInfo info = GameScene.Game.GuildBox.GuildInfo.Members.First(x => x.Index == p.Index);

            info.LastOnline = DateTime.MaxValue;
            info.Name = p.Name;
            info.ObjectID = p.ObjectID;

            if (GameScene.Game.GuildBox.Visible)
                GameScene.Game.GuildBox.RefreshGuildDisplay();
        }
        public void Process(S.GuildMemberContribution p)
        {

            if (!GameScene.Game.User.GuildLvKQ)
            {
                ClientGuildMemberInfo info = GameScene.Game.GuildBox.GuildInfo.Members.First(x => x.Index == p.Index);

                info.DailyContribution += p.Contribution;
                info.TotalContribution += p.Contribution;
                
                
                

                info.MapName = p.MapName;

                GameScene.Game.GuildBox.GuildInfo.GuildFunds += p.Contribution;
                GameScene.Game.GuildBox.GuildInfo.DailyGrowth += p.Contribution;

                GameScene.Game.GuildBox.GuildInfo.TotalContribution += p.Contribution;
                GameScene.Game.GuildBox.GuildInfo.DailyContribution += p.Contribution;
                
                
                

                if (GameScene.Game.GuildBox.Visible)
                    GameScene.Game.GuildBox.RefreshGuildDisplay();
            }
            else
            {

                ClientGuildMemberInfo info = GameScene.Game.GuildBox.GuildInfo.Members.First(x => x.Index == p.Index);
                
                
                

                info.DailyContribution += (long)p.HuishouContribution;
                info.TotalContribution += (long)p.HuishouContribution;

                info.JyTotalContribution += p.HuishouContribution;

                info.MapName = p.MapName;

                GameScene.Game.GuildBox.GuildInfo.GuildFunds += p.Contribution;
                GameScene.Game.GuildBox.GuildInfo.DailyGrowth += p.Contribution;
                
                
                

                GameScene.Game.GuildBox.GuildInfo.TotalContribution += (long)p.HuishouContribution;
                GameScene.Game.GuildBox.GuildInfo.DailyContribution += (long)p.HuishouContribution;

                GameScene.Game.GuildBox.GuildInfo.JyTotalContribution += p.HuishouContribution;


                if (GameScene.Game.GuildBox.Visible)
                    GameScene.Game.GuildBox.RefreshGuildDisplay();
            }

        }
        public void Process(S.GuildDayReset p)
        {
            

            foreach (ClientGuildMemberInfo member in GameScene.Game.GuildBox.GuildInfo.Members)
                member.DailyContribution = 0;
            
            GameScene.Game.GuildBox.GuildInfo.DailyGrowth = 0;
            GameScene.Game.GuildBox.GuildInfo.DailyContribution = 0;

            if (GameScene.Game.GuildBox.Visible)
                GameScene.Game.GuildBox.RefreshGuildDisplay();
        }
        public void Process(S.GuildFundsChanged p)
        {
            
            
            GameScene.Game.GuildBox.GuildInfo.GuildFunds += p.Change;
            GameScene.Game.GuildBox.GuildInfo.DailyGrowth += p.Change;
            
            if (GameScene.Game.GuildBox.Visible)
                GameScene.Game.GuildBox.RefreshGuildDisplay();
        }
        public void Process(S.GuildChanged p)
        {
            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
            {
                if (ob.ObjectID != p.ObjectID) continue;

                ((PlayerObject)ob).Title = p.GuildName;
                ((PlayerObject)ob).GuildRank = p.GuildRank;
                return;
            }
        }
        public void Process(S.GuildWar p)
        {
            GameScene.Game.GuildBox.WarAttempted = false;

            if (p.Success)
                GameScene.Game.GuildBox.GuildWarTextBox.TextBox.Text = string.Empty;
        }
        public void Process(S.GuildWarStarted p)
        {
            GameScene.Game.GuildWars.Add(p.GuildName);

            GameScene.Game.ReceiveChat($"你正在与 {p.GuildName} 进行公会战,持续 {Functions.ToString(p.Duration, true)}", MessageType.System);

            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
                ob.NameChanged();
        }
        public void Process(S.GuildWarFinished p)
        {
            GameScene.Game.GuildWars.Remove(p.GuildName);

            GameScene.Game.ReceiveChat($" {p.GuildName} 的公会战已结束.", MessageType.System);

            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
                ob.NameChanged();
        }
        public void Process(S.GuildConquestStarted p)
        {
            GameScene.Game.ConquestWars.Add(CEnvir.CastleInfoList.Binding.First(x => x.Index == p.Index));
            
            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
                ob.NameChanged();
        }
        public void Process(S.GuildConquestFinished p)
        {
            GameScene.Game.ConquestWars.Remove(CEnvir.CastleInfoList.Binding.First(x => x.Index == p.Index));

            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
                ob.NameChanged();
        }
        public void Process(S.GuildCastleInfo p)
        {
            CastleInfo castle = CEnvir.CastleInfoList.Binding.First(x => x.Index == p.Index);
            GameScene.Game.CastleOwners[castle] = p.Owner;

            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
                ob.NameChanged();

            GameScene.Game.GuildBox.CastlePanels[castle].Update();
        }
        public void Process(S.GuildConquestDate p)
        {
            CastleInfo castle = CEnvir.CastleInfoList.Binding.First(x => x.Index == p.Index);
            
            castle.WarDate = p.WarDate;
        }


        public void Process(S.ReviveTimers p)
        {
            

            GameScene.Game.ItemReviveTime = CEnvir.Now + p.ItemReviveTime;
            GameScene.Game.ReincarnationPillTime = CEnvir.Now + p.ReincarnationPillTime;
        }


        public void Process(S.QuestChanged p)
        {
            foreach (ClientUserQuest quest in GameScene.Game.QuestLog)
            {
                if (quest.Quest != p.Quest.Quest) continue;


                quest.Completed = p.Quest.Completed;
                quest.Track = p.Quest.Track;
                quest.SelectedReward = p.Quest.SelectedReward;
                quest.Tasks.Clear();
                quest.Tasks.AddRange(p.Quest.Tasks);

                GameScene.Game.QuestChanged(p.Quest);
                return;
            }
            GameScene.Game.QuestLog.Add(p.Quest);
            GameScene.Game.QuestChanged(p.Quest);
        }

        public void Process(S.MeiriQuestChanged p)
        {
            foreach (ClientMeiriUserQuest quest in GameScene.Game.MeiriQuestLog)
            {
                if (quest.Quest != p.Quest.Quest) continue;


                quest.Completed = p.Quest.Completed;
                quest.Track = p.Quest.Track;
                quest.SelectedReward = p.Quest.SelectedReward;
                quest.Tasks.Clear();
                quest.Tasks.AddRange(p.Quest.Tasks);

                GameScene.Game.MeiriQuestChanged(p.Quest);
                return;
            }
            GameScene.Game.MeiriQuestLog.Add(p.Quest);
            GameScene.Game.MeiriQuestChanged(p.Quest);
        }

        public void Process(S.MeiriQuestRemoved p)
        {
            foreach (ClientMeiriUserQuest item in GameScene.Game.MeiriQuestLog)
            {
                if (item.Quest == p.Quest.Quest)
                {
                    item.Completed = true;
                    item.Track = false;
                    item.Tasks.Clear();
                    GameScene.Game.MeiriQuestBox.CurrentTab.SelectedQuest = null;
                    GameScene.Game.MeiriQuestLog.Remove(item);
                    GameScene.Game.MeiriQuestRemove(item);
                    break;
                }
            }
        }
        public void Process(S.MeiriQuestHasDailyRandom p)
        {
            GameScene.Game.MeiriQuestBox.DailyRandomTab.DailyRandomButton.Enabled = !p.hasdaily;
        }
        public void Process(S.MeiRiDailyRandomQuestResets p)
        {
            GameScene.Game.MeiriQuestBox.DailyRandomTab.DailyRandomResetCounts = p.DailyCount;
            GameScene.Game.MeiriQuestBox.DailyRandomTab.DailyRandomResetButton.Enabled = false;
            GameScene.Game.MeiriQuestBox.DailyRandomTab.DailyRandomResetCount.Text = "你当前拥有 " + p.DailyCount.ToString() + " 次每日随机任务重置机会";

            if (p.DailyCount == 1)
                GameScene.Game.MeiriQuestBox.DailyRandomTab.DailyRandomResetButton.Enabled = true;
            else if (p.DailyCount == 2)
                GameScene.Game.MeiriQuestBox.DailyRandomTab.DailyRandomButton.Enabled = true;
        }

        public void Process(S.CompanionUnlock p)
        {
            GameScene.Game.NPCAdoptCompanionBox.UnlockButton.Enabled = true;
            if (p.Index == 0) return;

            GameScene.Game.NPCAdoptCompanionBox.AvailableCompanions.Add(CartoonGlobals.CompanionInfoList.Binding.First(x => x.Index == p.Index));

            GameScene.Game.NPCAdoptCompanionBox.RefreshUnlockButton();
        }
        public void Process(S.CompanionAdopt p)
        {
            GameScene.Game.NPCAdoptCompanionBox.AdoptAttempted = false;

            if (p.UserCompanion == null) return;

            GameScene.Game.NPCCompanionStorageBox.Companions.Add(p.UserCompanion);
            GameScene.Game.NPCCompanionStorageBox.UpdateScrollBar();
            GameScene.Game.NPCAdoptCompanionBox.CompanionNameTextBox.TextBox.Text = string.Empty;
        }
        public void Process(S.CompanionStore p)
        {
            if (GameScene.Game.Companion != null)
                GameScene.Game.Companion.CharacterName = null;

            GameScene.Game.Companion = null;
        }
        public void Process(S.CompanionRetrieve p)
        {
            GameScene.Game.Companion = GameScene.Game.NPCCompanionStorageBox.Companions.FirstOrDefault(x => x.Index == p.Index);
        }
        public void Process(S.CompanionWeightUpdate p)
        {
            GameScene.Game.CompanionBox.BagWeight = p.BagWeight;
            GameScene.Game.CompanionBox.MaxBagWeight = p.MaxBagWeight;
            GameScene.Game.CompanionBox.InventorySize = p.InventorySize;
            GameScene.Game.CompanionBox.HasSpace = p.CompanionBagSpace;

            GameScene.Game.CompanionBox.Refresh();
        }
        public void Process(S.CompanionShapeUpdate p)
        {
            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
            {
                if (ob.Race != ObjectType.Monster || ob.ObjectID != p.ObjectID) continue;

                MonsterObject monster = (MonsterObject)ob;

                if (monster.CompanionObject == null) continue;

                monster.CompanionObject.HeadShape = p.HeadShape;
                monster.CompanionObject.BackShape = p.BackShape;
                return;
            }
        }
        public void Process(S.CompanionUpdate p)
        {
            GameScene.Game.Companion.Rebirth = p.Rebirth;
            GameScene.Game.Companion.Hunger = p.Hunger;
            GameScene.Game.Companion.Level = p.Level;
            GameScene.Game.Companion.Experience = p.Experience;

            GameScene.Game.CompanionBox.Refresh();
        }
        public void Process(S.CompanionItemsGained p)
        {
            foreach (ClientUserItem item in p.Items)
            {
                ItemInfo displayInfo = item.Info;

                if (item.Info.Effect == ItemEffect.Gold)
                {
                    if (GameScene.Game.User.Gold + item.Count <= CartoonGlobals.MaxGold)
                        GameScene.Game.BigPatchBox.Helper.GainedGold(item.Count);
                }

                if (item.Info.Effect == ItemEffect.ItemPart)
                    displayInfo = CartoonGlobals.ItemInfoList.Binding.First(x => x.Index == item.AddedStats[Stat.ItemIndex]);
                
                item.New = true;
                string text = item.Count > 1 ? $"你的宠物捡取 {displayInfo.ItemName} x{item.Count}." : $"你的宠物捡取 {displayInfo.ItemName}.";

                if ((item.Flags & UserItemFlags.QuestItem) == UserItemFlags.QuestItem)
                    text += " (任务)";

                if (item.Info.Effect == ItemEffect.ItemPart)
                    text += " [碎片]";

                GameScene.Game.ReceiveChat(text, MessageType.Combat);
            }

            GameScene.Game.AddCompanionItems(p.Items);
        }
        public void Process(S.CompanionSkillUpdate p)
        {
            GameScene.Game.Companion.Level3 = p.Level3;
            GameScene.Game.Companion.Level5 = p.Level5;
            GameScene.Game.Companion.Level7 = p.Level7;
            GameScene.Game.Companion.Level10 = p.Level10;
            GameScene.Game.Companion.Level11 = p.Level11;
            GameScene.Game.Companion.Level13 = p.Level13;
            GameScene.Game.Companion.Level15 = p.Level15;
            GameScene.Game.Companion.Level17 = p.Level17;
            GameScene.Game.Companion.Level20 = p.Level20;
            GameScene.Game.Companion.Level23 = p.Level23;
            GameScene.Game.Companion.Level25 = p.Level25;
            GameScene.Game.Companion.Level27 = p.Level27;
            GameScene.Game.Companion.Level30 = p.Level30;
            GameScene.Game.Companion.Level33 = p.Level33;
            GameScene.Game.Companion.Level35 = p.Level35;
            GameScene.Game.Companion.Level37 = p.Level37;
            GameScene.Game.Companion.Level40 = p.Level40;

            GameScene.Game.Companion.ImgIndex3 = p.ImgIndex3;
            GameScene.Game.Companion.ImgIndex5 = p.ImgIndex5;
            GameScene.Game.Companion.ImgIndex7 = p.ImgIndex7;
            GameScene.Game.Companion.ImgIndex10 = p.ImgIndex10;
            GameScene.Game.Companion.ImgIndex11 = p.ImgIndex11;
            GameScene.Game.Companion.ImgIndex13 = p.ImgIndex13;
            GameScene.Game.Companion.ImgIndex15 = p.ImgIndex15;
            GameScene.Game.Companion.ImgIndex17 = p.ImgIndex17;
            GameScene.Game.Companion.ImgIndex20 = p.ImgIndex20;
            GameScene.Game.Companion.ImgIndex23 = p.ImgIndex23;
            GameScene.Game.Companion.ImgIndex25 = p.ImgIndex25;
            GameScene.Game.Companion.ImgIndex27 = p.ImgIndex27;
            GameScene.Game.Companion.ImgIndex30 = p.ImgIndex30;
            GameScene.Game.Companion.ImgIndex33 = p.ImgIndex33;
            GameScene.Game.Companion.ImgIndex35 = p.ImgIndex35;
            GameScene.Game.Companion.ImgIndex37 = p.ImgIndex37;
            GameScene.Game.Companion.ImgIndex40 = p.ImgIndex40;

            GameScene.Game.Companion.Maxzhi3 = p.Maxzhi3;
            GameScene.Game.Companion.Maxzhi5 = p.Maxzhi5;
            GameScene.Game.Companion.Maxzhi7 = p.Maxzhi7;
            GameScene.Game.Companion.Maxzhi10 = p.Maxzhi10;
            GameScene.Game.Companion.Maxzhi11 = p.Maxzhi11;
            GameScene.Game.Companion.Maxzhi13 = p.Maxzhi13;
            GameScene.Game.Companion.Maxzhi15 = p.Maxzhi15;

            GameScene.Game.CompanionBox.Refresh();
        }
        public void Process(S.HorseUnlock p)
        {
            GameScene.Game.NPCAdoptHorseBox.UnlockButton.Enabled = true;
            if (p.Index != 0)
            {
                GameScene.Game.NPCAdoptHorseBox.AvailableHorses.Add(CartoonGlobals.HorseInfoList.Binding.First((HorseInfo x) => x.Index == p.Index));
                GameScene.Game.NPCAdoptHorseBox.RefreshUnlockButton();
            }
        }

        public void Process(S.HorseAdopt p)
        {
            if (p.Index != 0)
            {
                ClientUserHorse clientUserHorse = new ClientUserHorse();
                clientUserHorse.HorseInfo = CartoonGlobals.HorseInfoList.Binding.FirstOrDefault((HorseInfo x) => x.Index == p.Index);
                clientUserHorse.HorseNum = p.Index;
                GameScene.Game.NPCHorseStorageBox.Horses.Add(clientUserHorse);
                GameScene.Game.NPCAdoptHorseBox.AdoptAttempted = false;
                GameScene.Game.NPCHorseStorageBox.UpdateScrollBar();
            }
        }

        public void Process(S.HorseStore p)
        {
            GameScene.Game.Horse = null;
        }

        public void Process(S.HorseRetrieve p)
        {
            GameScene.Game.Horse = GameScene.Game.NPCHorseStorageBox.Horses.FirstOrDefault((ClientUserHorse x) => x.HorseNum == p.Index);
        }
        public void Process(S.MarriageInvite p)
        {
            

            DXMessageBox messageBox = new DXMessageBox($"{p.Name} 向你求婚.\n你想和他(她)结婚吗? \n ", "婚姻请求", DXMessageBoxButtons.YesNo);

            messageBox.YesButton.MouseClick += (o, e) => CEnvir.Enqueue(new C.MarriageResponse { Accept = true });
            messageBox.NoButton.MouseClick += (o, e) => CEnvir.Enqueue(new C.MarriageResponse { Accept = false });
            messageBox.CloseButton.MouseClick += (o, e) => CEnvir.Enqueue(new C.MarriageResponse { Accept = false });
            messageBox.Modal = false;
            messageBox.CloseButton.Visible = false;
            
        }
        public void Process(S.MarriageInfo p)
        {
            ClientObjectData data;

            GameScene.Game.DataDictionary.TryGetValue(GameScene.Game.Partner?.ObjectID ?? p.Partner.ObjectID, out data);

            GameScene.Game.Partner = p.Partner;

            if (data == null) return;

            GameScene.Game.BigMapBox.Update(data);
            GameScene.Game.MiniMapBox.Update(data);
        }

        public void Process(S.MarriageRemoveRing p)
        {
            

            GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.RingL].Item.Flags &= ~UserItemFlags.Marriage;
        }
        public void Process(S.MarriageMakeRing p)
        {
            

            GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.RingL].Item.Flags |= UserItemFlags.Marriage;
        }
        public void Process(S.MarriageOnlineChanged p)
        {
            

            ClientObjectData data;

            GameScene.Game.DataDictionary.TryGetValue(GameScene.Game.Partner.ObjectID > 0 ? GameScene.Game.Partner.ObjectID : p.ObjectID, out data);

            GameScene.Game.Partner.ObjectID = p.ObjectID;

            if (data == null) return;

            GameScene.Game.BigMapBox.Update(data);
            GameScene.Game.MiniMapBox.Update(data);
        }

        public void Process(S.HuizhangRemoveRefine p)
        {

            GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Emblem].Item.Level = 1;
            GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Emblem].Item.Experience = 0;

            if ((GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Emblem].Item.Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable)
                GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Emblem].Item.Flags &= ~UserItemFlags.Refinable;

            if ((GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Emblem].Item.BaoshiMaEr & BaoshiMaEr.Youliang) == BaoshiMaEr.Youliang)
                GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Emblem].Item.BaoshiMaEr &= ~BaoshiMaEr.Youliang;
            else if ((GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Emblem].Item.BaoshiMaEr & BaoshiMaEr.Jingzhi) == BaoshiMaEr.Jingzhi)
                GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Emblem].Item.BaoshiMaEr &= ~BaoshiMaEr.Jingzhi;
            else if ((GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Emblem].Item.BaoshiMaEr & BaoshiMaEr.Chuanshuo) == BaoshiMaEr.Chuanshuo)
                GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Emblem].Item.BaoshiMaEr &= ~BaoshiMaEr.Chuanshuo;
            else if ((GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Emblem].Item.BaoshiMaEr & BaoshiMaEr.Shenhua) == BaoshiMaEr.Shenhua)
                GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Emblem].Item.BaoshiMaEr &= ~BaoshiMaEr.Shenhua;
        }
        public void Process(S.HuizhangMakeRefine p)
        {

            if ((GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Emblem].Item.Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable)
                GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Emblem].Item.Flags &= ~UserItemFlags.Refinable;

            GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Emblem].Item.Level = p.Level;
            GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Emblem].Item.Experience = p.Experience;

            if (p.Level >= 3 && p.Level <= 5)
                GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Emblem].Item.BaoshiMaEr |= BaoshiMaEr.Youliang;
            else if (p.Level > 5 && p.Level <= 8)
                GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Emblem].Item.BaoshiMaEr |= BaoshiMaEr.Jingzhi;
            else if (p.Level > 8 && p.Level <= 10)
                GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Emblem].Item.BaoshiMaEr |= BaoshiMaEr.Chuanshuo;
            else if (p.Level > 10)
                GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Emblem].Item.BaoshiMaEr |= BaoshiMaEr.Shenhua;
        }

        public void Process(S.DunpaiRemoveRefine p)
        {

            GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Shield].Item.Level = 1;
            GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Shield].Item.Experience = 0;

            if ((GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Shield].Item.Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable)
                GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Shield].Item.Flags &= ~UserItemFlags.Refinable;

            if ((GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Shield].Item.BaoshiMaEr & BaoshiMaEr.Youliang) == BaoshiMaEr.Youliang)
                GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Shield].Item.BaoshiMaEr &= ~BaoshiMaEr.Youliang;
            else if ((GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Shield].Item.BaoshiMaEr & BaoshiMaEr.Jingzhi) == BaoshiMaEr.Jingzhi)
                GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Shield].Item.BaoshiMaEr &= ~BaoshiMaEr.Jingzhi;
            else if ((GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Shield].Item.BaoshiMaEr & BaoshiMaEr.Chuanshuo) == BaoshiMaEr.Chuanshuo)
                GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Shield].Item.BaoshiMaEr &= ~BaoshiMaEr.Chuanshuo;
            else if ((GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Shield].Item.BaoshiMaEr & BaoshiMaEr.Shenhua) == BaoshiMaEr.Shenhua)
                GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Shield].Item.BaoshiMaEr &= ~BaoshiMaEr.Shenhua;

        }
        public void Process(S.DunpaiMakeRefine p)
        {
            if ((GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Shield].Item.Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable)
                GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Shield].Item.Flags &= ~UserItemFlags.Refinable;

            GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Shield].Item.Level = p.Level;
            GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Shield].Item.Experience = p.Experience;

            if (p.Level >= 3 && p.Level <= 5)
                GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Shield].Item.BaoshiMaEr |= BaoshiMaEr.Youliang;
            else if (p.Level > 5 && p.Level <= 8)
                GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Shield].Item.BaoshiMaEr |= BaoshiMaEr.Jingzhi;
            else if (p.Level > 8 && p.Level <= 10)
                GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Shield].Item.BaoshiMaEr |= BaoshiMaEr.Chuanshuo;
            else if (p.Level > 10)
                GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Shield].Item.BaoshiMaEr |= BaoshiMaEr.Shenhua;
        }

        public void Process(S.DataObjectPlayer p)
        {
            ClientObjectData data = new ClientObjectData
            {
                ObjectID = p.ObjectID,

                MapIndex = p.MapIndex,
                Location = p.CurrentLocation,

                Name = p.Name,

                Health = p.Health,
                MaxHealth = p.MaxHealth,
                Dead = p.Dead,

                Mana = p.Mana,
                MaxMana = p.MaxMana,

            };

            GameScene.Game.DataDictionary[p.ObjectID] = data;

            GameScene.Game.BigMapBox.Update(data);
            GameScene.Game.MiniMapBox.Update(data);
        }
        public void Process(S.DataObjectMonster p)
        {
            ClientObjectData data = new ClientObjectData
            {
                ObjectID = p.ObjectID,

                MapIndex = p.MapIndex,
                Location = p.CurrentLocation,

                MonsterInfo = p.MonsterInfo,

                Health = p.Health,
                MaxHealth = p.Stats[Stat.Health],
                Stats = p.Stats,
                Dead = p.Dead,

                PetOwner = p.PetOwner,
            };

            GameScene.Game.DataDictionary[p.ObjectID] = data;

            GameScene.Game.BigMapBox.Update(data);
            GameScene.Game.MiniMapBox.Update(data);
        }
        public void Process(S.DataObjectItem p)
        {
            ClientObjectData data = new ClientObjectData
            {
                ObjectID = p.ObjectID,

                MapIndex = p.MapIndex,
                Location = p.CurrentLocation,

                ItemInfo = p.ItemInfo,
                Name = p.ItemInfo.ItemName,
            };

            GameScene.Game.DataDictionary[p.ObjectID] = data;

            GameScene.Game.BigMapBox.Update(data);
            GameScene.Game.MiniMapBox.Update(data);
        }
        public void Process(S.DataObjectRemove p)
        {
            ClientObjectData data;

            if (!GameScene.Game.DataDictionary.TryGetValue(p.ObjectID, out data)) return;
            
            GameScene.Game.DataDictionary.Remove(p.ObjectID);

            GameScene.Game.BigMapBox.Remove(data);
            GameScene.Game.MiniMapBox.Remove(data);
        }
        public void Process(S.DataObjectLocation p)
        {
            ClientObjectData data;

            if (!GameScene.Game.DataDictionary.TryGetValue(p.ObjectID, out data)) return;
            
            data.Location = p.CurrentLocation;
            data.MapIndex = p.MapIndex;

            GameScene.Game.BigMapBox.Update(data);
            GameScene.Game.MiniMapBox.Update(data);
        }

        
        
        
        public void Process(S.DataObjectHealthMana p)
        {
            ClientObjectData data;

            if (!GameScene.Game.DataDictionary.TryGetValue(p.ObjectID, out data)) return;
            
            data.Health = p.Health;
            data.Mana = p.Mana;

            if (data.Health < 0)
                data.Health = 0;

            if (GameScene.Game.MonsterBox.Monster != null && GameScene.Game.MonsterBox.Monster.ObjectID == p.ObjectID)
                GameScene.Game.MonsterBox.RefreshHealth();

            if (data.Dead != p.Dead)
            {
                data.Dead = p.Dead;
                GameScene.Game.BigMapBox.Update(data);
                GameScene.Game.MiniMapBox.Update(data);
            }
        }
        public void Process(S.DataObjectMaxHealthMana p)
        {
            ClientObjectData data;

            if (!GameScene.Game.DataDictionary.TryGetValue(p.ObjectID, out data)) return;

            if (p.Stats != null)
            {
                data.MaxHealth = p.Stats[Stat.Health];
                data.MaxMana = p.Stats[Stat.Mana];
                data.Stats = p.Stats;
            }
            else
            {
                data.MaxHealth = p.MaxHealth;
                data.MaxMana = p.MaxMana;
            }
            if (GameScene.Game.MonsterBox.Monster != null && GameScene.Game.MonsterBox.Monster.ObjectID == p.ObjectID)
                GameScene.Game.MonsterBox.RefreshStats();
        }

        public void Process(S.BlockAdd p)
        {
            CEnvir.BlockList.Add(p.Info);

            GameScene.Game.BlockBox.RefreshList();
        }
        public void Process(S.BlockRemove p)
        {
            ClientBlockInfo block = CEnvir.BlockList.First(x => x.Index == p.Index);

            CEnvir.BlockList.Remove(block);

            GameScene.Game.BlockBox.RefreshList();
        }
        
        public void Process(S.ShizhuangToggle p)
        {
            GameScene.Game.CharacterBox.ShowShizhuangBox.Checked = !p.HideShizhuang;
        }
        
        public void Process(S.HelmetToggle p)
        {
            GameScene.Game.CharacterBox.ShowHelmetBox.Checked = !p.HideHelmet;
        }
        
        public void Process(S.DunToggle p)
        {
            GameScene.Game.CharacterBox.ShowDunBox.Checked = !p.Dun;
        }


        public void Process(S.StorageSize p)
        {
            GameScene.Game.StorageSize = p.Size;
        }

        public void Process(PatchGridSize p)
        {
            GameScene.Game.PatchGridSize = p.Size;
        }

        
        public void Process(BaoshiGridSize p)
        {
            GameScene.Game.BaoshiGridSize = p.Size;
        }

        public void Process(S.PlayerChangeUpdate p)
        {
            foreach (MapObject ob in GameScene.Game.MapControl.Objects)
            {
                if (ob.Race != ObjectType.Player || ob.ObjectID != p.ObjectID) continue;

                PlayerObject player = (PlayerObject)ob;

                player.Name = p.Name;
                player.Class = p.Class;
                player.Gender = p.Gender;
                player.HairType = p.HairType;
                player.HairColour = p.HairColour;
                player.ArmourColour = p.ArmourColour;

                player.UpdateLibraries();
                return;
            }
        }

        public void Process(S.FortuneUpdate p)
        {
            foreach (ClientFortuneInfo fortune in p.Fortunes)
            {
                ClientFortuneInfo info;
                if (!GameScene.Game.FortuneDictionary.TryGetValue(fortune.ItemInfo, out info))
                {
                    GameScene.Game.FortuneDictionary[fortune.ItemInfo] = fortune;
                    continue;
                }

                info.DropCount = fortune.DropCount;
                info.Progress = fortune.Progress;
                info.CheckDate = fortune.CheckDate;
            }

            if (!GameScene.Game.FortuneCheckerBox.Visible) return;

            GameScene.Game.FortuneCheckerBox.RefreshList();
        }

        public void Process(S.NPCWeaponCraft p)
        {
            #region Template

            DXItemCell[] grid;

            switch (p.Template.GridType)
            {
                case GridType.Inventory:
                    grid = GameScene.Game.InventoryBox.Grid.Grid;
                    break;
                case GridType.Equipment:
                    grid = GameScene.Game.CharacterBox.Grid;
                    break;
                case GridType.Storage:
                    grid = GameScene.Game.StorageBox.Grid.Grid;
                    break;
                case GridType.CompanionInventory:
                    grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                    break;
                case GridType.CompanionEquipment:
                    grid = GameScene.Game.CompanionBox.EquipmentGrid;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            DXItemCell fromCell = grid[p.Template.Slot];
            fromCell.Locked = false;

            if (p.Success)
            {
                if (p.Template.Count == fromCell.Item.Count)
                    fromCell.Item = null;
                else
                    fromCell.Item.Count -= p.Template.Count;

                fromCell.RefreshItem();
            }
            #endregion

            #region Yellow

            if (p.Yellow != null)
            {
                switch (p.Yellow.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                fromCell = grid[p.Yellow.Slot];
                fromCell.Locked = false;

                if (p.Success)
                {
                    if (p.Yellow.Count == fromCell.Item.Count)
                        fromCell.Item = null;
                    else
                        fromCell.Item.Count -= p.Yellow.Count;

                    fromCell.RefreshItem();
                }
            }

            #endregion

            #region Blue

            if (p.Blue != null)
            {
                switch (p.Blue.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                fromCell = grid[p.Blue.Slot];
                fromCell.Locked = false;

                if (p.Success)
                {
                    if (p.Blue.Count == fromCell.Item.Count)
                        fromCell.Item = null;
                    else
                        fromCell.Item.Count -= p.Blue.Count;

                    fromCell.RefreshItem();
                }
            }

            #endregion
            
            #region Red

            if (p.Red != null)
            {
                switch (p.Red.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                fromCell = grid[p.Red.Slot];
                fromCell.Locked = false;

                if (p.Success)
                {
                    if (p.Red.Count == fromCell.Item.Count)
                        fromCell.Item = null;
                    else
                        fromCell.Item.Count -= p.Red.Count;

                    fromCell.RefreshItem();
                }
            }

            #endregion

            #region Purple

            if (p.Purple != null)
            {
                switch (p.Purple.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                fromCell = grid[p.Purple.Slot];
                fromCell.Locked = false;

                if (p.Success)
                {
                    if (p.Purple.Count == fromCell.Item.Count)
                        fromCell.Item = null;
                    else
                        fromCell.Item.Count -= p.Purple.Count;

                    fromCell.RefreshItem();
                }
            }

            #endregion

            #region Green

            if (p.Green != null)
            {
                switch (p.Green.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                fromCell = grid[p.Green.Slot];
                fromCell.Locked = false;

                if (p.Success)
                {
                    if (p.Green.Count == fromCell.Item.Count)
                        fromCell.Item = null;
                    else
                        fromCell.Item.Count -= p.Green.Count;

                    fromCell.RefreshItem();
                }
            }

            #endregion

            #region Grey

            if (p.Grey != null)
            {
                switch (p.Grey.GridType)
                {
                    case GridType.Inventory:
                        grid = GameScene.Game.InventoryBox.Grid.Grid;
                        break;
                    case GridType.Equipment:
                        grid = GameScene.Game.CharacterBox.Grid;
                        break;
                    case GridType.Storage:
                        grid = GameScene.Game.StorageBox.Grid.Grid;
                        break;
                    case GridType.CompanionInventory:
                        grid = GameScene.Game.CompanionBox.InventoryGrid.Grid;
                        break;
                    case GridType.CompanionEquipment:
                        grid = GameScene.Game.CompanionBox.EquipmentGrid;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                fromCell = grid[p.Grey.Slot];
                fromCell.Locked = false;

                if (p.Success)
                {
                    if (p.Grey.Count == fromCell.Item.Count)
                        fromCell.Item = null;
                    else
                        fromCell.Item.Count -= p.Grey.Count;

                    fromCell.RefreshItem();
                }
            }

            #endregion
        }
        
        public void Process(Library.Network.ServerPackets.CraftInformation p)
        {
            foreach (MapObject @object in GameScene.Game.MapControl.Objects)
            {
                if (@object.Race == ObjectType.Player && @object.ObjectID == p.ObjectID)
                {
                    PlayerObject playerObject = (PlayerObject)@object;
                    playerObject.CraftInfo = p.CraftInfo;
                    GameScene.Game.CraftingBox.UpdateStats();
                }
            }
        }
        
        public void Process(CraftingFinished p)
        {
            foreach (CellLinkInfo link in p.Links)
            {
                GridType gridType = link.GridType;
                if (gridType != GridType.Inventory)
                {
                    throw new ArgumentOutOfRangeException();
                }
                DXItemCell[] grid = GameScene.Game.InventoryBox.Grid.Grid;
                DXItemCell dXItemCell = grid[link.Slot];
                dXItemCell.Link = null;
            }
            if (!GameScene.Game.Observer)
            {
                GameScene.Game.CraftingBox.updateCrafting();
            }
        }

        public void Process(UpdateMiniGames p)
        {
            CEnvir.MiniGamesList = p.games;
            GameScene.Game.MiniGamesBox.UpdateEvents();
        }

        public void Process(HasFlag p)
        {
            foreach (MapObject @object in GameScene.Game.MapControl.Objects)
            {
                if (@object.Race == ObjectType.Player && @object.ObjectID == p.ObjectID)
                {
                    PlayerObject playerObject = (PlayerObject)@object;
                    playerObject.hasFlag = p.hasFLag;
                }
            }
        }

        public void Process(SetTeam p)
        {
            foreach (MapObject @object in GameScene.Game.MapControl.Objects)
            {
                if (@object.Race == ObjectType.Player && @object.ObjectID == p.ObjectID)
                {
                    PlayerObject playerObject = (PlayerObject)@object;
                    playerObject.gameTeam = p.team;
                    playerObject.EventFlagShape = 50 + p.team;
                    playerObject.UpdateLibraries();
                }
            }
        }
    }
}

