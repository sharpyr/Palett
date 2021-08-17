using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using Palett.Types;
using Veho.Enumerable;

namespace Palett {
  public static partial class Conv {
    public static int ColorToInt(this Color color) => color.R << 16 | color.G << 8 | color.B;
    public static string ColorToHex(this Color color) => "#" + ColorToInt(color).ToString("X6");
    public static (byte r, byte g, byte b) ColorToRgb(this Color color) => (color.R, color.G, color.B);
    public static (float h, float s, float l) ColorToHsl(this Color color) => (color.GetHue(), color.GetSaturation() * 100, color.GetBrightness() * 100);
    
    public static Regex D3 => new Regex(
      @"\d{1,3}", RegexOptions.Compiled | RegexOptions.IgnoreCase
    );

    public static Color? ParseColor(string hex, Space space = Space.Rgb) {
      if (hex == null) return null;
      if (space == Space.Hex) return Conv.HexToColor(hex);
      var vec = D3.Matches(hex).Cast<Match>().Map(x => x.Value);
      if (vec.Length == 0) return null;
      switch (space) {
        case Space.Rgb:
          return vec.Length < 3
            ? (byte.Parse(vec[0]), byte.Parse(vec[0]), byte.Parse(vec[0])).RgbToColor()
            : (byte.Parse(vec[0]), byte.Parse(vec[1]), byte.Parse(vec[2])).RgbToColor();
        case Space.Hsl:
          return vec.Length < 3
            ? (float.Parse(vec[0]), (float) 100, (float) 50).HslToColor()
            : (float.Parse(vec[0]), float.Parse(vec[1]), float.Parse(vec[2])).HslToColor();
        default: return null;
      }
    }
  }
}