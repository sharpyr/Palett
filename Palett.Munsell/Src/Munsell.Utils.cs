using Aryth;
using static System.Math;
using HSL = System.ValueTuple<float, float, float>;
using RGB = System.ValueTuple<byte, byte, byte>;

namespace Palett {
  public static partial class Munsell {
    public static (byte r, byte g, byte b) Relative(this (byte r, byte g, byte b) rgb, (byte r, byte g, byte b) it) {
      return ((byte)Abs(rgb.r - it.r), (byte)Abs(rgb.g - it.g), (byte)Abs(rgb.b - it.b));
    }
    public static (float h, float s, float l) Relative(this (float h, float s, float l) hsl, (float h, float s, float l) it) {
      return (Pol.Distance(hsl.h, it.h), Abs(hsl.s - it.s), Abs(hsl.l - it.l));
    }

    public static int Distance(this RGB rgb, RGB sub) {
      var (r, g, b) = rgb.Relative(sub);
      return r + g + b;
    }
    public static float Distance(this HSL hsl, HSL sub) {
      var (h, s, l) = hsl.Relative(sub);
      return h + s + l;
    }
    public static bool AlmostEqual(this (byte r, byte g, byte b) rgb, (byte r, byte g, byte b) sub, (byte r, byte g, byte b) epsilon) {
      return Abs(rgb.r - sub.r) < epsilon.r && Abs(rgb.g - sub.g) < epsilon.g && Abs(rgb.b - sub.b) < epsilon.b;
    }
    public static bool AlmostEqual(this (float h, float s, float l) hsl, (float h, float s, float l) sub, (float h, float s, float l) epsilon) {
      return Pol.Distance(hsl.h, sub.h) < epsilon.h && Abs(hsl.s - sub.s) < epsilon.s && Abs(hsl.l - sub.l) < epsilon.l;
    }
    public static bool AlmostEqual(this (float h, float s, float l) hsl, (double r, double θ) polar, (double r, double θ) polarEpsilon, (double min, double max) saturationInterval) {
      return Math.AlmostEqual(hsl.h, polar.θ, polarEpsilon.θ) &&
             saturationInterval.Has(hsl.s) &&
             Math.AlmostEqual(hsl.l, polar.r, polarEpsilon.r);
    }
  }
}