using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Controls;
using Client.Envir;
using Client.Scenes;
using Client.Scenes.Views;
using Library;
using Library.SystemModels;
using S = Library.Network.ServerPackets;

namespace Client.Models
{
    public sealed class ItemObject : MapObject
    {
        public override ObjectType Race => ObjectType.Item;

        public DXLabel FocusLabel;

        public override bool Blocking => false;

        public ClientUserItem Item;
        public MirLibrary BodyLibrary;
        public Color LabelBackColour = Color.FromArgb(30, 0, 24, 48);

        public ItemObject(S.ObjectItem info)
        {
            ObjectID = info.ObjectID;

            Item = info.Item;

            ItemInfo itemInfo = info.Item.Info;
            int itemIdx = info.Item.Info.Index;
        

            if (info.Item.Info.Effect == ItemEffect.ItemPart)
            {
                itemInfo = CartoonGlobals.ItemInfoList.Binding.First(x => x.Index == Item.AddedStats[Stat.ItemIndex]);
                Title = "[碎片]";
            }

            Name = Item.Count > 1 ? $"{itemInfo.ItemName} ({Item.Count})" : itemInfo.ItemName;

            if ((Item.Flags & UserItemFlags.QuestItem) == UserItemFlags.QuestItem)
                Title = "(任务)";


            switch (itemInfo.Rarity)
            {
                case Rarity.Common:
                    if (this.Item.AddedStats.Values.Count > 0 && this.Item.Info.Effect != ItemEffect.ItemPart)
                    {
                        this.NameColour = Color.Cyan;
                        this.Effects.Add(new MirEffect(100, 10, TimeSpan.FromMilliseconds(100.0), LibraryFile.ProgUse, 60, 60, CartoonGlobals.PoorColour)
                        {
                            Target = (MapObject)this,
                            Loop = true,
                            Blend = true,
                            BlendRate = 0.5f
                        });
                        break;
                    }
                    this.NameColour = Color.FromArgb((int)byte.MaxValue, (int)byte.MaxValue, 175);
                    break;
                case Rarity.Superior:
                    this.NameColour = Color.Lime;
                    if (this.Item.AddedStats.Values.Count > 0 && this.Item.Info.Effect != ItemEffect.ItemPart)
                    {
                        this.Effects.Add(new MirEffect(100, 10, TimeSpan.FromMilliseconds(100.0), LibraryFile.ProgUse, 60, 60, Color.White)
                        {
                            Target = (MapObject)this,
                            Loop = true,
                            Blend = true,
                            BlendRate = 0.5f
                        });
                        break;
                    }
                    break;
                case Rarity.Elite:
                    this.NameColour = Color.Orange;
                    this.Effects.Add(new MirEffect(110, 10, TimeSpan.FromMilliseconds(100.0), LibraryFile.ProgUse, 60, 60, CartoonGlobals.RareColour)
                    {
                        Target = (MapObject)this,
                        Loop = true,
                        Blend = true,
                        BlendRate = 0.5f
                    });
                    break;
            }
            BigPatchDialog.CItemFilterSet filterItem = GameScene.Game?.BigPatchBox?.GetFilterItem(itemInfo.ItemId - 1);
            if (filterItem != null)
            {
                if (filterItem.hint)
                {
                    GameScene game = GameScene.Game;
                    string[] strArray = new string[8];
                    strArray[0] = ">>>>   极品   [ ";
                    strArray[1] = itemInfo.ItemName;
                    strArray[2] = " ";
                    int index1 = 3;
                    Point location = info.Location;
                    string str1 = location.X.ToString();
                    strArray[index1] = str1;
                    strArray[4] = ",";
                    int index2 = 5;
                    location = info.Location;
                    string str2 = location.Y.ToString();
                    strArray[index2] = str2;
                    strArray[6] = "]   在   ";
                    strArray[7] = CEnvir.GetDirName(MapObject.User.CurrentLocation, info.Location);
                    string message = string.Concat(strArray);
                    int num = 16;
                    game.ReceiveChat(message, (MessageType)num);
                }

                if (!filterItem.show)
                {
                    if (NameLabel != null)
                        NameLabel.Visible = false;
                    if (TitleNameLabel != null)
                        TitleNameLabel.Visible = false;
                }
            }

            CurrentLocation = info.Location;

            UpdateLibraries();

            SetFrame(new ObjectAction(MirAction.Standing, Direction, CurrentLocation));

            GameScene.Game.MapControl.AddObject(this);
        }
        public void UpdateLibraries()
        {
            Frames = FrameSet.DefaultItem;

            CEnvir.LibraryList.TryGetValue(LibraryFile.Ground, out BodyLibrary);
        }

        public override void SetAnimation(ObjectAction action)
        {

            CurrentAnimation = MirAnimation.Standing;
            if (!Frames.TryGetValue(CurrentAnimation, out CurrentFrame))
                CurrentFrame = Frame.EmptyFrame;
        }

        public override void Draw()
        {
            if (BodyLibrary == null) return;

            int drawIndex;

            if (Item.Info.Effect == ItemEffect.Gold)
            {
                if (Item.Count < 100)
                    drawIndex = 120;
                else if (Item.Count < 200)
                    drawIndex = 121;
                else if (Item.Count < 500)
                    drawIndex = 122;
                else if (Item.Count < 1000)
                    drawIndex = 123;
                else if (Item.Count < 1000000) 
                    drawIndex = 124;
                else if (Item.Count < 5000000) 
                    drawIndex = 125;
                else if (Item.Count < 10000000) 
                    drawIndex = 126;
                else
                    drawIndex = 127;
            }
            else
            {
                ItemInfo info = Item.Info;

                if (info.Effect == ItemEffect.ItemPart)
                    info = CartoonGlobals.ItemInfoList.Binding.First(x => x.Index == Item.AddedStats[Stat.ItemIndex]);

                drawIndex = info.Image;
            }

            Size size = BodyLibrary.GetSize(drawIndex);

            BodyLibrary.Draw(drawIndex, DrawX + (CellWidth - size.Width) / 2, DrawY + (CellHeight - size.Height) / 2, DrawColour, false, 1F, ImageType.Image);

        }

        public override bool MouseOver(Point p)
        {
            return false;
        }

        public override void OnRemoved()
        {
        }

        public override void NameChanged()
        {
            base.NameChanged();

            if (string.IsNullOrEmpty(Name))
            {
                FocusLabel = null;
            }
            else
            {
                if (!NameLabels.TryGetValue(Name, out List<DXLabel> focused))
                    NameLabels[Name] = focused = new List<DXLabel>();

                FocusLabel = focused.FirstOrDefault(x => x.ForeColour == NameColour && x.BackColour == LabelBackColour);

                if (FocusLabel != null) return;

                FocusLabel = new DXLabel
                {
                    BackColour = LabelBackColour,
                    ForeColour = NameColour,
                    Outline = true,
                    OutlineColour = Color.Black,
                    Text = Name,
                    Border = true,
                    BorderColour = Color.Black,
                    IsVisible = true,
                };

                FocusLabel.Disposing += (o, e) => focused.Remove(FocusLabel);
                focused.Add(FocusLabel);
            }
        }

        public void DrawFocus(int layer)
        {
            FocusLabel.Location = new Point(DrawX + (48 - FocusLabel.Size.Width) / 2, DrawY - (32 - FocusLabel.Size.Height / 2) + 8 - layer * 16);
            FocusLabel.Draw();
        }
    }

}
