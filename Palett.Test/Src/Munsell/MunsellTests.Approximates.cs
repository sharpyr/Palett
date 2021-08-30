using System;
using NUnit.Framework;
using Spare;
using Veho.Sequence;

namespace Palett.Test.Munsell {
  [TestFixture]
  public partial class MunsellTests {
    [Test]
    public void SearchTest() {
      var list = Palett.Munsell.Search(SearchText);
      Console.WriteLine(Rgb);
      list
        .Map(x => $"\n{x.hex}: {Dyer.Render(x.hex, x.name)}")
        .Deco()
        .Logger();
    }

    [Test]
    public void ApproximatesRgbTest() {
      var list = Rgb.Approximates(Top);
      Console.WriteLine(Rgb);
      list
        .Map(x => $"\n{x.hex}: {Dyer.Render(x.hex, x.name)}")
        .Deco()
        .Logger();
    }

    [Test]
    public void ApproximatesHslTest() {
      Console.WriteLine(Hsl);
      var list = Hsl.Approximates(Top);
      list
        .Map(x => $"\n{x.hex}: {Dyer.Render(x.hex, x.name)} ({Conv.HexToHsl(x.hex)})")
        .Deco()
        .Logger();
    }
    [Test]
    public void ApproximatesRgbTestByEpsilon() {
      Console.WriteLine(Rgb);
      var list = Rgb.Approximates(EpsilonRgb, Domain.Fashion);
      list
        .Map(x => $"\n{x.hex}: {Dyer.Render(x.hex, x.name)}")
        .Deco()
        .Logger();
    }
    [Test]
    public void ApproximatesHslTestByEpsilon() {
      Console.WriteLine(Hsl);
      var list = Hsl.Approximates(EpsilonHsl);
      list
        .Map(x => $"\n{x.hex}: {Dyer.Render(x.hex, x.name)} ({Conv.HexToHsl(x.hex)})")
        .Deco()
        .Logger();
    }
  }
}