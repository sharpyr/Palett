using System;
using System.Collections.Generic;
using System.Drawing;

namespace Palett.Test.Assets {
  public static class ColorDictCollection {
    public static Dictionary<String, Color> ConsoleColorDict = new Dictionary<String, Color> {
      {"BLACK", Color.FromArgb(0, 0, 0)},
      {"RED", Color.FromArgb(255, 0, 0)},
      {"GREEN", Color.FromArgb(0, 255, 0)},
      {"BLUE", Color.FromArgb(0, 0, 255)},
      {"YELLOW", Color.FromArgb(255, 255, 0)},
      {"MAGENTA", Color.FromArgb(255, 0, 255)},
      {"CYAN", Color.FromArgb(0, 255, 255)},
      {"WHITE", Color.FromArgb(255, 255, 255)},
    };
    public static Dictionary<String, Color> SplendidColorDict = new Dictionary<String, Color> {
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