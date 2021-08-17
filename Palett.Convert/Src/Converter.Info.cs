using System.Drawing;

namespace Palett {
  public static partial class Conv {
    public static int ColorToInfo(this Color c) => c.R | c.G << 8 | c.B << 16; //Information.RGB(color.R, color.G, color.B);
    public static int RgbToInfo(this (byte r, byte g, byte b) rgb) => rgb.r | rgb.g << 8 | rgb.b << 16;
    public static int HslToInfo(this (float h, float s, float l) hsl) => hsl.HslToRgb().RgbToInfo();
    public static int HexToInfo(string hex) => Conv.HexToRgb(hex).RgbToInfo();

    public static (byte r, byte g, byte b) InfoToRgb(int n) => ((byte) (n & 0xFF), (byte) (n >> 8), (byte) (n >> 16));
    public static (float h, float s, float l) InfoToHsl(int n) => Conv.InfoToRgb(n).RgbToHsl();
    public static string InfoToHex(int n) => Conv.InfoToRgb(n).RgbToHex();
    public static Color InfoToColor(int n) => Conv.InfoToRgb(n).RgbToColor();


    public static (byte r, byte g, byte b) InfoToRgb(object excelColor) => InfoToRgb(int.Parse(excelColor?.ToString() ?? "0"));
  }
}