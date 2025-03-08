





using System.Drawing;

namespace Client.Envir
{
  public class CGlobal
  {
    public static Font Font = new Font(Config.FontName, CEnvir.FontSize(9f), FontStyle.Regular);
    public static Font BlodFont = new Font(Config.FontName, CEnvir.FontSize(9f), FontStyle.Bold);
    public static Font BloadFontEng = new Font("SimSun", CEnvir.FontSize(9f), FontStyle.Bold);
    public static Color SysWhite = Color.FromArgb(223, (int) byte.MaxValue, 205);
  }
}
