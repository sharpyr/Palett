using Microsoft.VisualBasic;
using NUnit.Framework;
using Palett.Convert;
using Palett.Dye;
using Palett.Test.Assets;
using Spare.Logger;

namespace Palett.Test.Convert {
  [TestFixture]
  public class InformationVsRGB {
    [Test]
    public void Test() {
      foreach (var kv in AssetCollection.ITermColorDict) {
        var dye = DyeFactory.Rgb();
        var rgb = kv.Value.ColorToRgb();
        $"{dye.Render(rgb, kv.Key)} Information.RGB {Information.RGB(rgb.r, rgb.g, rgb.b)} RGB {rgb.RgbToInt()}".Logger();
      }
    }
  }
}