using System;
using System.Linq;
using NUnit.Framework;
using Palett.Convert;
using Palett.Dye;
using Palett.Test.Assets;
using Palett.Types;
using Spare.Deco;
using Spare.Logger;
using Veho.Matrix.Rows;
using Veho.Tuple;
using RGB = System.ValueTuple<byte, byte, byte>;
using HSL = System.ValueTuple<float, float, float>;

namespace Palett.Test.Convert {
  [TestFixture]
  public class ColorConverterTests {
    [Test]
    public void ColorConvertTestSplendid() {
      var dyeFac = DyeFactory.Rgb(Effect.Bold, Effect.Underline);
      var some = AssetCollection.SplendidColorDict.Select(kv => {
        var rgb = kv.Value.ColorToRgb();
        var key = dyeFac.Render(rgb, kv.Key);
        var colorToHsl = kv.Value.ColorToHsl();
        var hslToColor = colorToHsl.HslToColor();
        var rgbToHsl = rgb.RgbToHsl();
        var hslToRgb = rgbToHsl.HslToRgb();
        return new object[] {
          key,
          rgb,
          colorToHsl.Map(x => Math.Round(x)),
          hslToColor,
          rgbToHsl,
          hslToRgb
        };
      }).ToArray().RowsToMatrix();
      some.Deco(hasAnsi: true).Logger();
    }
  }
}