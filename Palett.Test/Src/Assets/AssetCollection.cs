using System;
using System.Collections.Generic;
using System.Drawing;
using Palett.Convert;

namespace Palett.Test.Assets {
  public static class AssetCollection {
    public static Dictionary<string, Color> ITermColorDict = new Dictionary<string, Color> {
      {"background", Converter.HexToColor("#101421")},
      {"foreground", Converter.HexToColor("#fffbf6")},
      {"normal-black", Converter.HexToColor("#2e2e2e")},
      {"normal-red", Converter.HexToColor("#eb4129")},
      {"normal-green", Converter.HexToColor("#abe047")},
      {"normal-yellow", Converter.HexToColor("#f6c744")},
      {"normal-blue", Converter.HexToColor("#47a0f3")},
      {"normal-magenta", Converter.HexToColor("#7b5cb0")},
      {"normal-cyan", Converter.HexToColor("#64dbed")},
      {"normal-white", Converter.HexToColor("#e5e9f0")},
      {"bright-black", Converter.HexToColor("#565656")},
      {"bright-red", Converter.HexToColor("#ec5357")},
      {"bright-green", Converter.HexToColor("#c0e17d")},
      {"bright-yellow", Converter.HexToColor("#f9da6a")},
      {"bright-blue", Converter.HexToColor("#49a4f8")},
      {"bright-magenta", Converter.HexToColor("#a47de9")},
      {"bright-cyan", Converter.HexToColor("#99faf2")},
      {"bright-white", Converter.HexToColor("#ffffff")},
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