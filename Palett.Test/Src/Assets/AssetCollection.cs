using System.Collections.Generic;
using System.Drawing;

namespace Palett.Test.Assets {
  public static class AssetCollection {
    public static Dictionary<string, Color> ITermColorDict = new Dictionary<string, Color> {
      {"background", Conv.HexToColor("#101421")},
      {"foreground", Conv.HexToColor("#fffbf6")},
      {"normal-black", Conv.HexToColor("#2e2e2e")},
      {"normal-red", Conv.HexToColor("#eb4129")},
      {"normal-green", Conv.HexToColor("#abe047")},
      {"normal-yellow", Conv.HexToColor("#f6c744")},
      {"normal-blue", Conv.HexToColor("#47a0f3")},
      {"normal-magenta", Conv.HexToColor("#7b5cb0")},
      {"normal-cyan", Conv.HexToColor("#64dbed")},
      {"normal-white", Conv.HexToColor("#e5e9f0")},
      {"bright-black", Conv.HexToColor("#565656")},
      {"bright-red", Conv.HexToColor("#ec5357")},
      {"bright-green", Conv.HexToColor("#c0e17d")},
      {"bright-yellow", Conv.HexToColor("#f9da6a")},
      {"bright-blue", Conv.HexToColor("#49a4f8")},
      {"bright-magenta", Conv.HexToColor("#a47de9")},
      {"bright-cyan", Conv.HexToColor("#99faf2")},
      {"bright-white", Conv.HexToColor("#ffffff")},
    };
    public static Dictionary<string, Color> ConsoleColorDict = new Dictionary<string, Color> {
      {"Black", Color.FromArgb(0, 0, 0)},
      {"Red", Color.FromArgb(255, 0, 0)},
      {"Green", Color.FromArgb(0, 255, 0)},
      {"Blue", Color.FromArgb(0, 0, 255)},
      {"Yellow", Color.FromArgb(255, 255, 0)},
      {"Magenta", Color.FromArgb(255, 0, 255)},
      {"Cyan", Color.FromArgb(0, 255, 255)},
      {"White", Color.FromArgb(255, 255, 255)},
    };
    public static Dictionary<string, Color> SplendidColorDict = new Dictionary<string, Color> {
      {"Empty", Color.Empty},
      {"Transparent", Color.Transparent},
      {"White", Color.White},
      {"Black", Color.Black},
      {"Red", Color.FromArgb(197, 0, 23)},
      {"Pink", Color.FromArgb(233, 30, 99)},
      {"DarkOrchid", Color.DarkOrchid},
      {"Purple", Color.Purple},
      {"Navy", Color.Navy},
      {"RoyalBlue", Color.RoyalBlue},
      {"CornflowerBlue", Color.CornflowerBlue},
      {"DarkTurquoise", Color.DarkTurquoise},
      {"Teal", Color.Teal},
      {"LimeGreen", Color.LimeGreen},
      {"LawnGreen", Color.LawnGreen},
      {"GreenYellow", Color.GreenYellow},
      {"Yellow", Color.Yellow},
      {"Gold", Color.Gold},
      {"Orange", Color.Orange},
      {"DarkOrange", Color.DarkOrange},
      {"SaddleBrown", Color.SaddleBrown},
      {"LightSlateGray", Color.LightSlateGray},
    };
  }
}