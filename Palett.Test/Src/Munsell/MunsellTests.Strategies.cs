using System;
using System.Diagnostics;
using Analys;
using NUnit.Framework;
using Spare;
using Veho;
using Veho.Types;
using System.Collections.Generic;

namespace Palett.Test.Munsell {


  [TestFixture]
  public partial class MunsellTests {
    [Test]
    public void Strategies() {
      Debug.Print($">> [HSL] {Hsl}");
      var list = Hsl.RhodoneaFolios(5, Density, LightMinimum, SaturTolerance, Domain.Fashion);

      list.DecoPalett().Logger();


      var (elapsed, result) = Valjoux.Strategies.Run(
        (int)1000,
        Seq.From<(string, Func<string, List<(string hex, string name)>>)>(
          ("alpha", hex => Conv.HexToHsl(hex).RhodoneaFolios(5, Density, LightMinimum, SaturTolerance, Domain.Fashion)),
          ("beta", hex => Conv.HexToHsl(hex).RhodoneaFolios(5, Density, LightMinimum, SaturTolerance, Domain.Fashion))
        ),
        Seq.From(
          ("pale-gold", "#BD8B69"),
          ("jade-lime", "#A1CA7B")
        )
      );
      elapsed.Deco(orient: Operated.Rowwise, presets: (Presets.Subtle, Presets.Fresh)).Says("Elapsed");
      result["pale-gold", "alpha"].Deco().Logger();
      // "\nResult".Logger();
      // result.Deco().Logger();
    }
  }
}