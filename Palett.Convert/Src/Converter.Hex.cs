using System.Drawing;
using HSL = System.ValueTuple<float, float, float>;
using RGB = System.ValueTuple<byte, byte, byte>;
using static System.Convert;

namespace Palett.Convert {
  public static partial class Converter {
    public static int HexToInt(string hex) => ToInt32(hex.TrimStart('#'), 16);
    public static (byte r, byte g, byte b) HexToRgb(string hex) {
      var num = HexToInt(hex);
      return ((byte) (num >> 16 & 0xFF), (byte) (num >> 8 & 0xFF), (byte) (num & 0xFF));
    }
    public static  (float h, float s, float l)  HexToHsl(string hex) => HexToRgb(hex).RgbToHsl();
    
    public static Color HexToColor(string hex) => IntToColor(HexToInt(hex));
  }
}