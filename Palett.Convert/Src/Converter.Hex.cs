﻿using System.Drawing;
using static System.Convert;

namespace Palett {
  public static partial class Conv {
    public static int HexToInt(string hex) => ToInt32(hex.TrimStart('#'), 16);
    public static (byte r, byte g, byte b) HexToRgb(string hex) {
      var n = HexToInt(hex);
      return ((byte) (n >> 16), (byte) (n >> 8), (byte) (n & 0xFF));
    }
    public static  (float h, float s, float l)  HexToHsl(string hex) => HexToRgb(hex).RgbToHsl();
    
    public static Color HexToColor(string hex) => IntToColor(HexToInt(hex));
  }
}