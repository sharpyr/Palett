using System;
using NUnit.Framework;
using Palett.Dye;
using Spare;
using Veho.Sequence;

namespace Palett.Test.Munsell {
  [TestFixture]
  public class CuvetteTest {
    public (byte, byte, byte) Rgb = ((byte) 203, (byte) 52, (byte) 65);
    public (float, float, float) Hsl => Rgb.RgbToHsl();
    public (byte, byte, byte) EpsilonRgb = ((byte) 10, (byte) 10, (byte) 10);
    public (float, float, float) EpsilonHsl = ((float) 10, (float) 8, (float) 5);
    public readonly DyeFactory<string> Dyer = DyeFactory.Hex();
    public int Top = 15;
    public string SearchText = "\\slilac";

    [Test]
    public void SearchTest() {
      var list = Cuvette.Search(SearchText);
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
      var list = Rgb.Approximates(EpsilonRgb);
      list
        .Map(x => $"\n{x.hex}: {Dyer.Render(x.hex, x.name)}")
        .Deco()
        .Logger();
    }
    [Test]
    public void ApproximatesHslTestByEpsilon() {
      Console.WriteLine(Hsl);
      var list = Cuvette.Approximates(Hsl, EpsilonHsl);
      list
        .Map(x => $"\n{x.hex}: {Dyer.Render(x.hex, x.name)} ({Conv.HexToHsl(x.hex)})")
        .Deco()
        .Logger();
    }
  }
}