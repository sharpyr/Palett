using System.Drawing;

namespace Palett {
  public static partial class Conv {
    public static string IntToHex(int n) => "#" + n.ToString("X6");
    public static (byte r, byte g, byte b) IntToRgb(int n) => ((byte) (n >> 16), (byte) (n >> 8), (byte) (n & 0xFF));
    public static (float h, float s, float l) IntToHsl(int n) => IntToRgb(n).RgbToHsl();
    public static Color IntToColor(int n) => Color.FromArgb((n >> 16) & 0xFF, (n >> 8) & 0xFF, n & 0xFF);
  }
}

// ((byte) (n >> 16 & 0xFF), (byte) (n >> 8 & 0xFF), (byte) (n & 0xFF))