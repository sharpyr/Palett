using System.Drawing;
using RGB = System.ValueTuple<byte, byte, byte>;
using HSL = System.ValueTuple<float, float, float>;

namespace Palett.Convert {
  public static partial class Converter {
    public static int ColorToInt(this Color color) => color.R << 16 | color.G << 8 | color.B;
    public static string ColorToHex(this Color color) => "#" + ColorToInt(color).ToString("X6");
    public static (byte r, byte g, byte b) ColorToRgb(this Color color) => (color.R, color.G, color.B);
    public static (float h, float s, float l) ColorToHsl(this Color color) => (color.GetHue(), color.GetSaturation() * 100, color.GetBrightness() * 100);
  }
}