using System.Drawing;

namespace Palett {
  public static class Reverso {
    public static (float h, float s, float l) Reverse(this (float h, float s, float l) hsl) {
      float SegH(float h) =>
        h < 30 ? 0 :
        h < 90 ? 60 :
        h < 150 ? 120 :
        h < 210 ? 180 :
        h < 270 ? 240 :
        h < 330 ? 300 :
        360;
      float SegS(float s) =>
        s < 10 ? 0 :
        s < 40 ? 25 :
        s < 60 ? 50 :
        s < 90 ? 75 :
        100;
      float SegL(float s) =>
        s < 5 ? 80 :
        s < 20 ? 90 :
        s < 40 ? 94 :
        s < 50 ? 100 :
        s < 60 ? 0 :
        s < 80 ? 10 :
        s < 95 ? 15 :
        25;
      return (SegH(hsl.h), SegS(hsl.s), SegL(hsl.l));
    }
    public static (byte, byte, byte) Reverse(this (byte, byte, byte) rgb) {
      return rgb.RgbToHsl().Reverse().HslToRgb();
    }
    public static Color Reverse(this Color rgb) {
      return rgb.ColorToHsl().Reverse().HslToColor();
    }
    public static string Reverse(string hex) {
      return Conv.HexToHsl(hex).Reverse().HslToHex();
    }
    public static int IntToReverse(int num) {
      return Conv.IntToHsl(num).Reverse().HslToInt();
    }
    public static int InfoToReverse(int num) {
      return Conv.InfoToHsl(num).Reverse().HslToInfo();
    }
  }
}