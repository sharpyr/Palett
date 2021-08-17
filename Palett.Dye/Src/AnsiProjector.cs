using System.Drawing;
using static Palett.Utils.Ansi.ColorModes;
using static Palett.Utils.Ansi.ControlCodes;

namespace Palett.Dye {
  using HSL = System.ValueTuple<float, float, float>;
  using RGB = System.ValueTuple<byte, byte, byte>;

  public static class AnsiProjector {
    public static string ColorToAnsi(Color color) {
      return $"{FORE}{SC}{color.R}{SC}{color.G}{SC}{color.B}";
    }
    public static string RgbToAnsi(RGB rgb) {
      var (r, g, b) = rgb;
      return $"{FORE}{SC}{r}{SC}{g}{SC}{b}";
    }
    public static string HexToAnsi(string hex) {
      var n = Conv.HexToInt(hex);
      return $"{FORE}{SC}{n >> 16 & 0xFF}{SC}{n >> 8 & 0xFF}{SC}{n & 0xFF}";
    }
    public static string HslToAnsi(HSL hsl) {
      var (r, g, b) = hsl.HslToRgb();
      return $"{FORE}{SC}{r}{SC}{g}{SC}{b}";
    }
  }
}