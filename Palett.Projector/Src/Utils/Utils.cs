using System;
using Palett.Convert;
using Palett.Dye;
using Palett.Utils.Types;
using HSL = System.ValueTuple<float, float, float>;

namespace Palett.Projector.Utils {
  public static class Utils {
    public static (TO, TO, TO) Map<T, TO>(this (T x, T y, T z) t, Func<T, TO> f) => (f(t.x), f(t.y), f(t.z));

    public static Func<string, string> preset_to_flat(this Preset preset, params Effect[] effects) =>
      DyeFactory.Hex(effects).Make(preset.Na);

    public static (HSL min, HSL dif, HSL max) preset_to_leap(this Preset preset) {
      var max = Converter.HexToHsl(preset.Max);
      var min = Converter.HexToHsl(preset.Min);
      return (
        min,
        (max.Item1 - min.Item1, max.Item2 - min.Item2, max.Item3 - min.Item3),
        max
      );
    }
    public static double Scale(double value, double floor, double lever, double basis, double ceil) =>
      Math.Min((Math.Max(value, floor) - floor) * lever + basis, ceil);
  }
}