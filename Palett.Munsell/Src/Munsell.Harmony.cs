using System;
using System.Collections.Generic;
using System.Linq;
using Aryth;
using Aryth.Polar;
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

    public static List<(string hex, string name)> RhodoneaFolios(this (float h, float s, float l) rimMark,
                                                                 int petals,
                                                                 double density = 0.01,
                                                                 double lightMinimum = 0,
                                                                 double saturTolerance = 18,
                                                                 Domain domain = Domain.Product) {
      var cuvette = Munsell.SelectCuvette(domain);
      var polarMark = rimMark.HslToPolar();
      var hexToHsl = cuvette.HexToHsl.Map(x => x); // create shallow copy

      var saturInterval = (rimMark.s - saturTolerance, rimMark.s + saturTolerance);
      var minL = (float)lightMinimum;

      var area = PI * Pow(polarMark.r, 2) * (petals % 2 == 0 ? 0.5 : 0.25);
      var maximum = (int)Round(density * area);
      var thresholdPerPhase = maximum / petals;
      // Console.WriteLine($">> [petals] {petals} [area] {area:N1} [maximum] {maximum} [threshold/phase] {thresholdPerPhase:00}");
      var petalNote = PetalNote.Build(polarMark.θ, petals);
      var target = new List<(string hex, float θ)>(maximum);
      foreach (var (hex, (θ, s, r)) in hexToHsl.FiniteFlopper()) {
        if (r < minL) continue;
        if (!saturInterval.Has(s)) continue;
        if (polarMark.FoliateRadius(θ, petals) < r) continue;
        var phase = petalNote.Phase(θ);
        if (thresholdPerPhase <= petalNote.Counter[phase]) continue;
        petalNote.NotePhase(phase);
        target.Add((hex, θ));
        if (maximum <= petalNote.Sum) break;
      }
      return target
             .OrderBy(x => x.θ)
             .Select(x => (x.hex, cuvette[x.hex]))
             .ToList();
    }
  }
}