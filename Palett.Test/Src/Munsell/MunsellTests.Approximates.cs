using System;
using System.Text.RegularExpressions;
using NUnit.Framework;
using Spare;
using Veho;

namespace Palett.Test.Munsell {
  [TestFixture]
  public partial class MunsellTests {
    [Test]
    public void RegexMatchTest() {
      var candidates = Vec.From("#000000", "Mineral Red #B35457", "Mineral Red", "");
      var regex = new Regex(@"#[0-9A-F]{3,6}");
      foreach (var candidate in candidates) {
        var match = regex.Match(candidate);
        Console.WriteLine($">> [{candidate}] ({match.Success}) {match}");
      }
    }
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