using System.Collections.Generic;
using System.Linq;
using Aryth;
using Aryth.Polar;
using Veho.Enumerable;
using Veho.Sequence;
using static System.Math;
using RGB = System.ValueTuple<byte, byte, byte>;
using HSL = System.ValueTuple<float, float, float>;
using POLAR = System.ValueTuple<double, double>;
using HEX_RGB = System.ValueTuple<string, System.ValueTuple<byte, byte, byte>>;
using HEX_HSL = System.ValueTuple<string, System.ValueTuple<float, float, float>>;
using HEX_POLAR = System.ValueTuple<string, System.ValueTuple<double, double>>;

namespace Palett {
  public static partial class Munsell {
    // public static IEnumerable<T> DistinctBy<T, TK>
    //   (this IEnumerable<T> source, Func<T, TK> keySelector) {
    //   var seenKeys = new HashSet<TK>();
    //   foreach (var element in source) {
    //     if (seenKeys.Add(keySelector(element))) {
    //       yield return element;
    //     }
    //   }
    // }
    public static List<(string hex, string name)> Analogous(this HSL hsl, double delta, int count, Domain domain = Domain.Fashion) {
      var cuvette = Munsell.SelectCuvette(domain);
      var (_, s, _) = hsl;
      var analogous = hsl
                      .HslToPolar()
                      .Analogous(delta, count)
                      .Map(polar => cuvette.Comparative(polar, s))
                      .DistinctBy(kv => kv.hex).ToList();
      return analogous;
    }

    public static List<(string hex, string name)> RhodoneaFolios(this (float h, float s, float l) rimMark,
                                                                 int petals,
                                                                 double density = 0.01,
                                                                 double lightMinimum = 0,
                                                                 double saturTolerance = 18,
                                                                 Domain domain = Domain.Fashion) {
      var cuvette = SelectCuvette(domain);
      var polarMark = rimMark.HslToPolar();
      var hexToHsl = cuvette.HexToHsl.Map(x => x); // create shallow copy
      var saturInterval = (rimMark.s - saturTolerance, rimMark.s + saturTolerance);
      var minL = (float)lightMinimum;
      var area = PI * Pow(polarMark.r, 2) * (petals % 2 == 0 ? 0.5 : 0.25);
      var maximum = (int)Round(density * area);
      var thresholdPerPhase = maximum / petals;
      var petalNote = PetalNote.Build(polarMark.θ, petals);
      // Console.WriteLine($">> [petalNote marks] {petalNote.Marks.Deco()}");
      var petalCache = Enumerable.Range(1, petals).ToDictionary(i => i, i => new SortedList<float, string>());
      var sortedList = new SortedList<int, string>(maximum);
      int HslIndicator((float h, float s, float l) hsl) => (int)hsl.h * 10000 + (int)hsl.s * 100 + (int)hsl.l;
      foreach (var (hex, hsl) in hexToHsl.FiniteFlopper()) {
        var (θ, s, r) = hsl;
        if (r < minL) continue;
        if (polarMark.FoliateRadius(θ, petals) < r) continue;
        var phase = petalNote.Phase(θ);
        if (thresholdPerPhase <= petalNote.Counter[phase]) continue;
        if (saturInterval.Has(s)) {
          petalNote.NotePhase(phase);
          sortedList.Add(HslIndicator(hsl), hex);
        }
        else {
          var dS = Abs(rimMark.s - s);
          var dR = Abs(rimMark.l - r);
          var dθ = Pol.Distance(rimMark.h, θ);
          petalCache[phase].Add(dS * 100 + dR + dθ / 360, hex);
        }
        if (maximum <= petalNote.Sum) break;
      }
      // Console.WriteLine($">> [sortedList.Count] {sortedList.Count}");
      petalNote.Counter.Iterate(kv => {
        var phase = kv.Key;
        var count = kv.Value;
        if (count < thresholdPerPhase) {
          var cache = petalCache[phase];
          if (cache?.Any() ?? false) {
            foreach (var hex in cache.Values.Take(thresholdPerPhase - count)) {
              sortedList.Add(HslIndicator(Conv.HexToHsl(hex)), hex);
            }
          }
        }
      });
      // Console.WriteLine($">> [sortedList.Count] {sortedList.Count}");
      // Console.WriteLine($">> [thresholdPerPhase] {thresholdPerPhase}");
      // petalNote.Counter.Entries().DecoEntries().Says("petalNote");
      // petalCache.Map((k, v) => (k, v.Count)).ToList().DecoEntries().Says("petalCacheNote");
      sortedList.TrimExcess();
      return sortedList
             .Values
             .Select(hex => (hex, cuvette[hex]))
             .ToList();
    }
  }
}