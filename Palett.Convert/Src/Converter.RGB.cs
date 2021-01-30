using System;
using System.Drawing;
using HSL = System.ValueTuple<float, float, float>;
using RGB = System.ValueTuple<byte, byte, byte>;

namespace Palett.Convert {
  public static partial class Converter {
    public static int RgbToInt(this (byte r, byte g, byte b) c) => ((c.r & 0xFF) << 16) + ((c.g & 0xFF) << 8) + (c.b & 0xFF);
    public static string RgbToHex(this RGB rgb) => "#" + RgbToInt(rgb).ToString("X6");
    public static (float h, float s, float l) RgbToHsl(this (byte r, byte g, byte b) c) {
      const float THOUSAND = 1000;
      var (r, g, b) = ((float) c.r / 255, (float) c.g / 255, (float) c.b / 255);
      var (sum, dif, pos) = Utils.SumDifPos(r, g, b);
      var h = Utils.Hue(r, g, b, dif, pos) * 60;
      var s = dif == 0 ? 0 : sum > 1 ? dif / (2 - sum) : dif / sum;
      var l = sum / 2;
      return ((float) Math.Round(h), (float) Math.Round(s * THOUSAND) / 10, (float) Math.Round(l * THOUSAND) / 10);
    }

    public static Color RgbToColor(this (byte r, byte g, byte b) c) => Color.FromArgb(c.r, c.g, c.b);
  }
}