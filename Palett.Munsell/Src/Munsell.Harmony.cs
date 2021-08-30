using System;
using System.Collections.Generic;
using System.Linq;
using Aryth.Polar;
using Veho.Sequence;
using RGB = System.ValueTuple<byte, byte, byte>;
using HSL = System.ValueTuple<float, float, float>;
using POLAR = System.ValueTuple<double, double>;
using HEX_RGB = System.ValueTuple<string, System.ValueTuple<byte, byte, byte>>;
using HEX_HSL = System.ValueTuple<string, System.ValueTuple<float, float, float>>;
using HEX_POLAR = System.ValueTuple<string, System.ValueTuple<double, double>>;

namespace Palett {
  public static partial class Munsell {
    public static IEnumerable<T> DistinctBy<T, TK>
      (this IEnumerable<T> source, Func<T, TK> keySelector) {
      var seenKeys = new HashSet<TK>();
      foreach (var element in source) {
        if (seenKeys.Add(keySelector(element))) {
          yield return element;
        }
      }
    }
    public static List<(string hex, string name)> Analogous(this HSL hsl, double delta, int count, Domain domain = Domain.Product) {
      var cuvette = Munsell.SelectCuvette(domain);
      var (_, s, _) = hsl;
      var analogous = hsl
                      .HslToPolar()
                      .Analogous(delta, count)
                      .Map(polar => cuvette.Nearest(polar, s))
                      .DistinctBy(kv => kv.hex).ToList();
      return analogous;
    }
    public static List<(string hex, string name)> RhodoneaFolios(this (float h, float s, float l) hsl, double saturationDeviation, int pedals, double density, Domain domain = Domain.Product) {
      var cuvette = Munsell.SelectCuvette(domain);
      var polar = hsl.HslToPolar();
      var list = cuvette.HexToPolar.Map(x => x.polar); // create shallow copy
      var rhodoneas = list.RhodoneaFolios(polar, pedals, density);
      var saturationInterval = (hsl.s - saturationDeviation, hsl.s + saturationDeviation);
      var polarEpsilon = (0.1, 0.1);
      return cuvette
             .HexToHsl
             .FindAll(kv => rhodoneas.Exists(x => kv.hsl.AlmostEqual(x, polarEpsilon, saturationInterval)))
             .Map(x => (x.hex, cuvette[x.hex]));
    }
  }
}