using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Palett.Convert;
using Veho.Enumerable;
using Veho.List;
using RGB = System.ValueTuple<byte, byte, byte>;
using HSL = System.ValueTuple<float, float, float>;
using HEX_RGB = System.ValueTuple<string, System.ValueTuple<byte, byte, byte>>;
using HEX_HSL = System.ValueTuple<string, System.ValueTuple<float, float, float>>;

namespace Palett {
  public static class Cuvette {
    private static List<HEX_RGB> _hexToRgb = null;
    private static List<HEX_HSL> _hexToHsl = null;
    public static List<(string hex, RGB rgb)> HexToRgb => _hexToRgb != null && _hexToRgb.Any()
      ? _hexToRgb
      : _hexToRgb = Pavtone.HexToName.Map(kv => (kv.Key, Converter.HexToRgb(kv.Key))).ToList();
    public static List<(string hex, HSL hsl)> HexToHsl => _hexToHsl != null && _hexToHsl.Any()
      ? _hexToHsl
      : _hexToHsl = HexToRgb.Map(kv => (kv.hex, kv.rgb.RgbToHsl())).ToList();

    public static List<(string hex, string name)> Search(string name) {
      var regex = new Regex(name, RegexOptions.IgnoreCase);

      var selected = Pavtone.HexToName
                            .ToList()
                            .FindAll(kv => regex.IsMatch(kv.Value));
      return selected
             .Map(kv => (kv.Key, kv.Value))
             .ToList();
    }

    public static List<(string hex, string name)> Approximates(this RGB rgb, int top) {
      List<(string hex, int len)> distances = HexToRgb.Map(kvp => (kvp.hex, kvp.rgb.Distance(rgb)))
                                                      .ToList();
      distances.Sort((a, b) => a.len - b.len);
      return distances
             .Take(top)
             .Map(x => (x.hex, Pavtone.HexToName[x.hex]))
             .ToList();
    }
    public static List<(string hex, string name)> Approximates(this HSL hsl, int top) {
      List<(string hex, float len)> distances = HexToHsl.Map(kvp => (kvp.hex, (kvp.hsl.Distance(hsl))))
                                                        .ToList();
      distances.Sort((a, b) => a.len >= b.len ? 1 : -1);
      return distances
             .Take(top)
             .Map(x => (x.hex, Pavtone.HexToName[x.hex]))
             .ToList();
    }

    public static List<(string hex, string name)> Approximates(this RGB rgb, RGB epsilon) {
      var distances = HexToRgb.FindAll(entry => entry.rgb.AlmostEqual(rgb, epsilon));
      return distances
             .Map(x => (x.hex, Pavtone.HexToName[x.hex]))
             .ToList();
    }
    public static List<(string hex, string name)> Approximates(this HSL hsl, HSL epsilon) {
      var distances = HexToHsl.FindAll(entry => entry.hsl.AlmostEqual(hsl, epsilon));
      return distances
             .Map(x => (x.hex, Pavtone.HexToName[x.hex]))
             .ToList();
    }
  }
}