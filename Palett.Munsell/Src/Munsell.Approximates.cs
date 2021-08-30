using System.Collections.Generic;
using System.Linq;
using Veho.Enumerable;
using RGB = System.ValueTuple<byte, byte, byte>;
using HSL = System.ValueTuple<float, float, float>;
using POLAR = System.ValueTuple<double, double>;
using HEX_RGB = System.ValueTuple<string, System.ValueTuple<byte, byte, byte>>;
using HEX_HSL = System.ValueTuple<string, System.ValueTuple<float, float, float>>;
using HEX_POLAR = System.ValueTuple<string, System.ValueTuple<double, double>>;

namespace Palett {
  public static partial class Munsell {
    public static List<(string hex, string name)> Approximates(this RGB rgb, int top, Domain domain = Domain.Product) {
      var cuvette = Munsell.SelectCuvette(domain);
      List<(string hex, int len)> distances = cuvette
                                              .HexToRgb
                                              .Map(kvp => (kvp.hex, kvp.rgb.Distance(rgb)))
                                              .ToList();
      distances.Sort((a, b) => a.len - b.len);
      return distances
             .Take(top)
             .Map(x => (x.hex, cuvette[x.hex]))
             .ToList();
    }
    public static List<(string hex, string name)> Approximates(this HSL hsl, int top, Domain domain = Domain.Product) {
      var cuvette = Munsell.SelectCuvette(domain);
      List<(string hex, float len)> distances = cuvette
                                                .HexToHsl
                                                .Map(kvp => (kvp.hex, kvp.hsl.Distance(hsl)))
                                                .ToList();
      distances.Sort((a, b) => a.len >= b.len ? 1 : -1);
      return distances
             .Take(top)
             .Map(x => (x.hex, cuvette[x.hex]))
             .ToList();
    }
    public static List<(string hex, string name)> Approximates(this RGB rgb, RGB epsilon, Domain domain = Domain.Product) {
      var cuvette = Munsell.SelectCuvette(domain);
      var distances = cuvette
                      .HexToRgb
                      .FindAll(entry => entry.rgb.AlmostEqual(rgb, epsilon));
      return distances
             .Map(x => (x.hex, cuvette[x.hex]))
             .ToList();
    }
    public static List<(string hex, string name)> Approximates(this HSL hsl, HSL epsilon, Domain domain = Domain.Product) {
      var cuvette = Munsell.SelectCuvette(domain);
      var distances = cuvette
                      .HexToHsl
                      .FindAll(entry => entry.hsl.AlmostEqual(hsl, epsilon));
      return distances
             .Map(x => (x.hex, cuvette[x.hex]))
             .ToList();
    }
  }
}