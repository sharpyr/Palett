using System;
using System.Collections.Generic;
using NUnit.Framework;
using Palett.Convert;

namespace Palett.Test.Convert {
  [TestFixture]
  public class PalettConvertTests {
    [Test]
    public void ColorConvertTest() {
      var tuples = new Dictionary<String, (byte, byte, byte)> {
        {"BLACK", (0, 0, 0)},
        {"RED", (255, 0, 0)},
        {"GREEN", (0, 255, 0)},
        {"BLUE", (0, 0, 255)},
        {"YELLOW", (255, 255, 0)},
        {"MAGENTA", (255, 0, 255)},
        {"CYAN", (0, 255, 255)},
        {"WHITE", (255, 255, 255)},
      };
      foreach (var kv in tuples) {
        // rgb -> hsl -> hex -> rgb -> int
        var rgb = kv.Value;
        var rgbToHsl = rgb.RgbToHsl();
        var hslToHex = rgbToHsl.HslToHex();
        var hexToRgb = Converter.HexToRgb(hslToHex);
        var rgbToInt = hexToRgb.RgbToInt();
        Console.WriteLine($"{kv.Key}: {rgb} {rgbToHsl} {hslToHex} {hexToRgb} {rgbToInt}");
      }
    }
  }
}