using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Client.Controls;
using Client.Envir;
using Client.Scenes;
using Library;
using SlimDX.Windows;

namespace Client
{
    static class Program
    {
        
        
        
        [STAThread]
        static void Main()
        {
            
            
            string HlsjZircon = Process.GetCurrentProcess().MainModule.ModuleName;
            
            string hlsjzirconprocessName = Path.GetFileNameWithoutExtension(HlsjZircon);
            
            Process[] zirconProcesses = Process.GetProcessesByName(hlsjzirconprocessName);
            
            if (zirconProcesses.Length > 2)
            {
                MessageBox.Show("游戏只能限制双开，不允许多开！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CEnvir.Target.Close();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!Directory.Exists(".\\ChatLogs\\"))
                Directory.CreateDirectory(".\\ChatLogs\\");
            if (!Directory.Exists(".\\SysLogs\\"))
                Directory.CreateDirectory(".\\SysLogs\\");

            foreach (KeyValuePair<LibraryFile, string> pair in Libraries.LibraryList)
            {
                if (!File.Exists(@".\" + pair.Value)) continue;

                CEnvir.LibraryList[pair.Key] = new MirLibrary(@".\" + pair.Value);
            }


            ConfigReader.Load();

            CEnvir.LoadDatabase();

            CEnvir.Target = new TargetForm();
            DXManager.Create();
            DXSoundManager.Create();
            
            DXControl.ActiveScene = new LoginScene(Config.IntroSceneSize);

            MessagePump.Run(CEnvir.Target, CEnvir.GameLoop);

            ConfigReader.Save();

            CEnvir.Session?.Save(true);
            CEnvir.Unload();
            DXManager.Unload();
            DXSoundManager.Unload();
        }
    }
}
