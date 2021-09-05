using System;
using NUnit.Framework;
using Spare;

namespace Palett.Test.Munsell {
  [TestFixture]
  public partial class MunsellTests {
    [Test]
    public void SearchTest() {
      var list = Palett.Munsell.Search(SearchText);
      Console.WriteLine(Rgb);
      list
        .DecoPalett()
        .Logger();
    }

    [Test]
    public void ApproximatesRgbTest() {
      var list = Rgb.Approximates(Top);
      Console.WriteLine(Rgb);
      list
        .DecoPalett()
        .Logger();
    }

    [Test]
    public void ApproximatesHslTest() {
      Console.WriteLine(Hsl);
      var list = Hsl.Approximates(Top);
      list
        .DecoPalett()
        .Logger();
    }
    [Test]
    public void ApproximatesRgbTestByEpsilon() {
      Console.WriteLine(Rgb);
      var list = Rgb.Approximates(EpsilonRgb, Domain.Fashion);
      list
        .DecoPalett()
        .Logger();
    }
    [Test]
    public void ApproximatesHslTestByEpsilon() {
      Console.WriteLine(Hsl);
      var list = Hsl.Approximates(EpsilonHsl);
      list
        .DecoPalett()
        .Logger();
    }
  }
}