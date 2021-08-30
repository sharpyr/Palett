using System;
using NUnit.Framework;
using Spare;
using Veho.Sequence;

namespace Palett.Test.Munsell {
  [TestFixture]
  public partial class MunsellTests {
    [Test]
    public void RhodoneaFoliosTest() {
      Console.WriteLine(Hsl);
      var list = Hsl.RhodoneaFolios(SaturationDeviation, 3, 100);
      list
        .Map(x => $"\n{x.hex}: {Dyer.Render(x.hex, x.name)} ({Conv.HexToHsl(x.hex)})")
        .Deco()
        .Logger();
    }

    [Test]
    public void AnalogousTest() {
      Console.WriteLine(Hsl);
      var list = Hsl.Analogous(-30, 12);
      list
        .Map(x => $"\n{x.hex}: {Dyer.Render(x.hex, x.name)} ({Conv.HexToHsl(x.hex)})")
        .Deco()
        .Logger();
    }
  }
}