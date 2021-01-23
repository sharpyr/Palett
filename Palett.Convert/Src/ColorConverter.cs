using System.Drawing;
using RGB = System.ValueTuple<byte, byte, byte>;
using HSL = System.ValueTuple<float, float, float>;

namespace Palett.Convert {
  public static class ColorConverter {
    public static Color RgbToColor(this RGB rgb) {
      var (r, g, b) = rgb;
      return Color.FromArgb(r, g, b);
    }

    public static RGB ColorToRgb(this Color color) => (color.R, color.G, color.B);

    public static Color HslToColor(this HSL hsl) {
      var (r, g, b) = hsl.HslToRgb();
      return Color.FromArgb(r, g, b);
    }

    public static HSL ColorToHsl(this Color color) => (color.GetHue(), color.GetSaturation() * 100, color.GetBrightness() * 100);
  }
}