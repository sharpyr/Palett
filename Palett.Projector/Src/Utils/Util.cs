using System;
using Palett.Convert;
using Palett.Dye;
using Palett.Utils.Types;
using HSL = System.ValueTuple<float, float, float>;

namespace Palett.Projector.Utils {
  public static class Util {
    public static (TO, TO, TO) Map<T, TO>(this (T x, T y, T z) t, Func<T, TO> f) => (f(t.x), f(t.y), f(t.z));
    public static (TO, TO) Map<T, TO>(this (T x, T y) t, Func<T, TO> f) => (f(t.x), f(t.y));

    public static Func<string, string> PresetToFlat(this Preset preset, params Effect[] effects) =>
      DyeFactory.Hex(effects).Make(preset.Na);

    public static (HSL min, HSL dif, HSL max) PresetToLeap(this Preset preset) {
      var max = Converter.HexToHsl(preset.Max);
      var min = Converter.HexToHsl(preset.Min);
      return (
        min,
        (max.Item1 - min.Item1, max.Item2 - min.Item2, max.Item3 - min.Item3),
        max
      );
    }
    public static float Scale(double value, double floor, float lever, float basis, float ceil) =>
      Math.Min((float) (Math.Max(value, floor) - floor) * lever + basis, ceil);

    public static HSL Div(this (float x, float y, float z) t, float other) => (t.x / other, t.y / other, t.z / other);
  }
}