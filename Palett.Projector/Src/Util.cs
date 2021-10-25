using System;
using Palett.Dye;
using Palett.Types;
using HSL = System.ValueTuple<float, float, float>;

namespace Palett {
  public static class Util {
    public static Func<string, string> PresetToFlat(this Preset preset, params Effect[] effects) =>
      DyeFactory.Hex(effects).Make(preset.Na);

    public static (HSL min, HSL max, HSL dif) PresetToLeap(this Preset preset) {
      var max = Conv.HexToHsl(preset.Max);
      var min = Conv.HexToHsl(preset.Min);
      return (
        min,
        max,
        (max.Item1 - min.Item1, max.Item2 - min.Item2, max.Item3 - min.Item3)
      );
    }


    public static HSL DivideBy(this (float x, float y, float z) t, float other) => (t.x / other, t.y / other, t.z / other);
  }
}