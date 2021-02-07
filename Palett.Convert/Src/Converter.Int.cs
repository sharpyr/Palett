using System.Drawing;
using RGB = System.ValueTuple<byte, byte, byte>;
using HSL = System.ValueTuple<float, float, float>;

namespace Palett.Convert {
  public static partial class Converter {
    public static string IntToHex(int n) => "#" + n.ToString("X6");
    public static (byte r, byte g, byte b) IntToRgb(int n) => ((byte) (n >> 16), (byte) (n >> 8), (byte) (n & 0xFF));
    public static (float h, float s, float l) IntToHSL(int n) => IntToRgb(n).RgbToHsl();
    public static Color IntToColor(int n) => Color.FromArgb((byte) (n >> 16), (byte) (n >> 8), (byte) (n & 0xFF));
  }
}

// ((byte) (n >> 16 & 0xFF), (byte) (n >> 8 & 0xFF), (byte) (n & 0xFF))