using System;
using NUnit.Framework;
using Palett.Convert;
using Palett.Dye;
using Palett.Test.Assets;
using Palett.Utils.Types;
using RGB = System.ValueTuple<byte, byte, byte>;
using HSL = System.ValueTuple<float, float, float>;

namespace Palett.Test.Convert {
  [TestFixture]
  public class ColorConverterTests {
    [Test]
    public void ColorConvertTestSplendid() {
      var dyeFac = DyeFactory.Rgb(Effect.Bold, Effect.Underline);
      foreach (var kv in ColorDictCollection.SplendidColorDict) {
        var rgb = kv.Value.ColorToRgb();
        var key = dyeFac.Render(rgb, kv.Key);
        var colorToHsl = kv.Value.ColorToHsl();
        var hslToColor = colorToHsl.HslToColor();
        var rgbToHsl = rgb.RgbToHsl();
        var hslToRgb = rgbToHsl.HslToRgb();
        Console.WriteLine($"{key}: {rgb} color {colorToHsl} {hslToColor} rgb {rgbToHsl} {hslToRgb}");
      }
    }
  }
}