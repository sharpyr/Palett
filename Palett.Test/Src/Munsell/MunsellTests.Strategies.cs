using System;
using Analys;
using NUnit.Framework;
using Spare;
using Veho;
using Veho.Types;
using System.Collections.Generic;
using System.Diagnostics;
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
using Mun = Palett.Munsell;

namespace Palett.Test.Munsell {
  public static class MunsellFunctions {
    public static List<(string hex, string name)> RhodoneaFoliosArch(this (float h, float s, float l) rimMark,
                                                                     int petals,
                                                                     double density = 0.01,
                                                                     double lightMinimum = 0,
                                                                     double saturTolerance = 18,
                                                                     Domain domain = Domain.Product) {
      var cuvette = Palett.Munsell.SelectCuvette(domain);
      var polarMark = rimMark.HslToPolar();
      var hexToHsl = cuvette.HexToHsl.Map(x => x); // create shallow copy

      var saturInterval = (rimMark.s - saturTolerance, rimMark.s + saturTolerance);
      var minL = (float)lightMinimum;

      var area = PI * Pow(polarMark.r, 2) * (petals % 2 == 0 ? 0.5 : 0.25);
      var maximum = (int)Round(density * area);
      var thresholdPerPhase = maximum / petals;
      // Console.WriteLine($">> [petals] {petals} [area] {area:N1} [maximum] {maximum} [threshold/phase] {thresholdPerPhase:00}");
      var petalNote = PetalNote.Build(polarMark.θ, petals);
      // var petalCacheNote = Enumerable.Range(0, petals).ToDictionary(i => i, i => new SortedList());
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
    public static List<(string hex, string name)> RhodoneaFoliosBaha(this (float h, float s, float l) rimMark,
                                                                     int petals,
                                                                     double density = 0.01,
                                                                     double lightMinimum = 0,
                                                                     double saturTolerance = 18,
                                                                     Domain domain = Domain.Product) {
      var cuvette = Mun.SelectCuvette(domain);
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
        } else {
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


  public partial class MunsellTests {
    [Test]
    [Ignore("ignore strategies")]
    public void Strategies() {
      var density = 0.02;
      var saturTolerance = 5;
      Debug.Print($">> [MunsellTests strategies]");
      var (elapsed, result) = Valjoux.Strategies.Run(
        (int)1000,
        Seq.From<(string, Func<string, List<(string hex, string name)>>)>(
          ("arch", hex => Conv.HexToHsl(hex).RhodoneaFoliosArch(5, density, LightMinimum, saturTolerance, Domain.Fashion)),
          ("baha", hex => Conv.HexToHsl(hex).RhodoneaFoliosBaha(5, density, LightMinimum, saturTolerance, Domain.Fashion))
        ),
        Seq.From(
          ("pale-gold", "#BD8B69"),
          ("jade-lime", "#A1CA7B"),
          ("mineral-red", "#AE5459")
        )
      );
      elapsed.Deco(orient: Operated.Rowwise, presets: (Presets.Subtle, Presets.Fresh)).Says("Elapsed");
      result["mineral-red", "arch"].DecoPalett().Logger();
      // "\nResult".Logger();
      // result.Deco().Logger();
    }

    [Test]
    public void ComparativeStrategies() {
      (string hex, string name) ComparativeArch(HSL hsl, Domain domain = Domain.Fashion) {
        var cuvette = Palett.Munsell.SelectCuvette(domain);
        var (hex, _) = cuvette.HexToHsl.MinOfListBy(kv => kv.hsl.Distance(hsl));
        return (hex, cuvette[hex]);
      }
      Debug.Print($">> [Comparative strategies]");
      var (elapsed, result) = Valjoux.Strategies.Run(
        (int)1000,
        Seq.From<(string, Func<HSL, (string hex, string name)>)>(
          ("arch", hsl => ComparativeArch(hsl)),
          ("edge", hsl => hsl.Comparative())
        ),
        Seq.From(
          ("pale-gold", Conv.HexToHsl("#BD8B69")),
          ("jade-lime", Conv.HexToHsl("#A1CA7B")),
          ("mineral-red", Conv.HexToHsl("#AE5459")),
          ("like-mineral-red", Conv.HexToHsl("#AF5357"))
        )
      );
      elapsed.Deco(orient: Operated.Rowwise, presets: (Presets.Subtle, Presets.Fresh)).Says("Elapsed");
      result.Deco().Says("Result");
      // result["mineral-red", "arch"].DecoPalett().Logger();
      // "\nResult".Logger();
      // result.Deco().Logger();
    }
  }
}