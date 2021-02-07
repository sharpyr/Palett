using System.Drawing;
using System.Linq;
using Microsoft.VisualBasic;
using NUnit.Framework;
using Palett.Convert;
using Palett.Dye;
using Palett.Test.Assets;
using Spare.Deco;
using Spare.Logger;
using Veho.Matrix.Rows;
using Veho.Types;
using static Palett.Presets.PresetCollection;

namespace Palett.Test.Convert {
  public static class Funcs {
    public static int DarkenColor1(int oleColor, float sngRatio) {
      int R = oleColor & 0xFF;
      int G = (oleColor & 0xFF00) / 0x100;
      int B = (oleColor & 0xFF0000) / 0x10000;
      //return Information.RGB((int)(R / sngRatio), (int)(G / sngRatio), (int)(B / sngRatio)); 
      return ColorTranslator.ToOle(Color.FromArgb((int) (R / sngRatio), (int) (G / sngRatio), (int) (B / sngRatio)));
    }
    public static int RgbToVBInt(this (byte r, byte g, byte b) c) => c.r | c.g << 8 | c.b << 16;
  }

  [TestFixture]
  public class InformationVsRGB {
    [Test]
    public void Test() {
      var matrix = AssetCollection.ITermColorDict.Select(kv => {
          var dye = DyeFactory.Rgb();
          var rgb = kv.Value.ColorToRgb();
          var localInt = rgb.RgbToInt();
          var vbInt = Information.RGB(rgb.r, rgb.g, rgb.b);
          var localVbInt = rgb.RgbToVBInt();
          return new object[] {dye.Render(rgb, kv.Key), rgb, vbInt, localVbInt, localInt};
        }
      ).ToArray().RowsToMatrix();
      matrix.Deco(presets: (Subtle, Ocean), orient: Operated.Columnwise).Logger();
    }
  }
}