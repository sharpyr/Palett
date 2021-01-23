using System.Drawing;
using RGB = System.ValueTuple<byte, byte, byte>;
using HSL = System.ValueTuple<float, float, float>;

namespace Palett.Convert {
  public partial class ColorConverter {
    public static Color RgbToColor(RGB rgb) {
      var (r, g, b) = rgb;
      return Color.FromArgb(r, g, b);
    }

    public static RGB ColorToRgb(Color color) => (color.R, color.G, color.B);

    public static Color HslToColor(HSL hsl) {
      var (r, g, b) = hsl.HslToRgb();
      return Color.FromArgb(r, g, b);
    }

    public static HSL ColorToHsl(Color color) => (color.GetHue(), color.GetSaturation() * 100, color.GetBrightness() * 100);
  }
}