using System.Drawing;
using RGB = System.ValueTuple<byte, byte, byte>;
using HSL = System.ValueTuple<float, float, float>;

namespace Palett.Convert {
  public static partial class Converter {
    public static string IntToHex(int num) => "#" + num.ToString("X6");
    public static (byte r, byte g, byte b) IntToRgb(int num) => ((byte) (num >> 16 & 0xFF), (byte) (num >> 8 & 0xFF), (byte) (num & 0xFF));
    public static  (float h, float s, float l)  IntToHSL(int num) => IntToRgb(num).RgbToHsl();
    public static Color IntToColor(int num) => Color.FromArgb((byte) (num >> 16 & 0xFF), (byte) (num >> 8 & 0xFF), (byte) (num & 0xFF));
  }
}