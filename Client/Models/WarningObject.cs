using Client.Controls;
using Client.Envir;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class WarningObject
    {
        public string Text;

        public Color ForeColour;

        public Color OutlineColour;

        public DateTime StartTime;

        public TimeSpan Duration;

        public int OffsetX = 25;

        public int OffsetY = 50;

        public bool Shift;

        public DXLabel Label;

        public WarningObject(string text, Color textColour, DXControl par)
        {
            Text = text;
            ForeColour = textColour;
            StartTime = CEnvir.Now;
            Duration = TimeSpan.FromSeconds(3.0);
            OutlineColour = Color.Black;
            CreateLabel(par);
        }

        public void CreateLabel(DXControl par)
        {
            if (Label == null)
            {
                Label = new DXLabel
                {
                    Text = Text,
                    Parent = par,
                    ForeColour = ForeColour,
                    Outline = true,
                    OutlineColour = OutlineColour,
                    IsVisible = true,
                    
                    Font = new Font("黑体", 15f, FontStyle.Bold)
                };
            }
        }
    }

}
