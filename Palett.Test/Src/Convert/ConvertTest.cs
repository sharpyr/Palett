using System;
using NUnit.Framework;
using Palett.Convert;
using Palett.Dye;
using Palett.Test.Assets;
using Palett.Utils.Ansi;
using RGB = System.ValueTuple<byte, byte, byte>;

namespace Palett.Test.Convert {
  [TestFixture]
  public class PalettConvertTests {
    [Test]
    public void ColorConvertTest() {
      var dyeFac = DyeFactory<RGB>.Rgb(Effect.Bold, Effect.Underline);
      foreach (var kv in ColorDictCollection.ConsoleColorDict) {
        // rgb -> hsl -> hex -> rgb -> int
        var rgb = kv.Value.ColorToRgb();
        var dye = dyeFac.Make(rgb);
        var rgbToHsl = rgb.RgbToHsl();
        var hslToHex = rgbToHsl.HslToHex();
        var hexToRgb = Converter.HexToRgb(hslToHex);
        var rgbToInt = hexToRgb.RgbToInt();
        Console.WriteLine($"{dye(kv.Key)}: {rgb} {rgbToHsl} {hslToHex} {hexToRgb} {rgbToInt}");
      }
    }
  }
}