using System;
using HSL = System.ValueTuple<float, float, float>;
using RGB = System.ValueTuple<int, int, int>;

namespace Palett.Convert {
  public static class Converter {
    public static HSL HexToHsl(string hex) {
      return HexToRgb(hex).RgbToHsl();
    }
    public static int HexToInt(string hex) {
      hex = hex.TrimStart('#');
      return System.Convert.ToInt32(hex, 16);
    }
    public static RGB HexToRgb(string hex) {
      var num = HexToInt(hex);
      return (num >> 16 & 0xFF, num >> 8 & 0xFF, num & 0xFF);
    }
    public static string HslToHex(this HSL hsl) {
      return hsl.HslToRgb().RgbToHex();
    }
    public static RGB HslToRgb(this HSL hsl) {
      var (h, os, ol) = hsl;
      var s = os / 100;
      var l = ol / 100;
      var a = s * Math.Min(l, 1 - l);
      var r = Utils.Hal(0, h, a, l);
      var g = Utils.Hal(8, h, a, l);
      var b = Utils.Hal(4, h, a, l);
      return ((int) (r * 0xFF), (int) (g * 0xFF), (int) (b * 0xFF));
    }
    public static string RgbToHex(this RGB rgb) {
      return "#" + RgbToInt(rgb).ToString("X6");
    }
    public static HSL RgbToHsl(this RGB rgb) {
      const float THOUSAND = 1000;
      var (r, g, b) = rgb.Map(v => (float) v / 255);
      var (sum, dif, pos) = Utils.SumDifPos(r, g, b);
      var h = Utils.Hue(r, g, b, dif, pos) * 60;
      var s = dif == 0 ? 0 : sum > 1 ? dif / (2 - sum) : dif / sum;
      var l = sum / 2;
      return ((float) Math.Round(h), (float) Math.Round(s * THOUSAND) / 10, (float) Math.Round(l * THOUSAND) / 10);
    }
    public static int RgbToInt(this RGB rgb) {
      var (r, g, b) = rgb;
      return ((r & 0xFF) << 16) + ((g & 0xFF) << 8) + (b & 0xFF);
    }
  }
}