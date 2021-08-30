using System;
using System.Drawing;
using HSL = System.ValueTuple<float, float, float>;

namespace Palett {
  public static partial class Conv {
    public static int HslToInt(this HSL hsl) => hsl.HslToRgb().RgbToInt();
    public static string HslToHex(this HSL hsl) => hsl.HslToRgb().RgbToHex();
    public static (byte r, byte g, byte b) HslToRgb(this HSL hsl) {
      var (h, os, ol) = hsl;
      float s = os / 100, l = ol / 100, a = s * Math.Min(l, 1 - l);
      float
        r = Hp.Hal(0, h, a, l),
        g = Hp.Hal(8, h, a, l),
        b = Hp.Hal(4, h, a, l);
      return ((byte)(r * 0xFF), (byte)(g * 0xFF), (byte)(b * 0xFF));
    }
    public static Color HslToColor(this HSL hsl) => hsl.HslToRgb().RgbToColor();
    public static (double r, double θ) HslToPolar(this (float h, float s, float l) hsl) => (hsl.l, hsl.h);
    public static (float h, float s, float l) PolarToHsl(this (double r, double θ) polar, float s) => ((float)polar.θ, s, (float)polar.r);
  }
}