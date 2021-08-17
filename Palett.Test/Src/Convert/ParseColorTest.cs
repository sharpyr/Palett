using System;
using NUnit.Framework;
using Palett.Types;

namespace Palett.Test.Convert {
  [TestFixture]
  public class ParseColorTest {
    [Test]
    public void AlphaTest() {
      var candidates = new[] {
        "(127,45,30)",
        "(127)",
        "()",
      };
      foreach (var text in candidates) {
        var result = Conv.ParseColor(text, Space.Hsl);
        Console.WriteLine($"[Color]: {result}");
      }
    }
  }
}