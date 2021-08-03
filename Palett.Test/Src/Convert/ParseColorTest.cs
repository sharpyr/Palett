using System;
using NUnit.Framework;
using Palett.Types;
using Palett.Convert;

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
        var result = Converter.ParseColor(text, Space.Hsl);
        Console.WriteLine($"[Color]: {result}");
      }
    }
  }
}