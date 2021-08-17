using System;
using NUnit.Framework;
using Palett.Dye;
using Palett.Test.Assets;
using Palett.Types;
using Spare;
using RGB = System.ValueTuple<byte, byte, byte>;

namespace Palett.Test.Convert {
  [TestFixture]
  public class PalettConvertTests {
    [Test]
    public void RgbToHslToHexToRgbToIntTest() {
      var dyeFac = DyeFactory.Rgb(Effect.Bold, Effect.Underline);
      foreach (var kv in AssetCollection.ConsoleColorDict) {
        // rgb -> hsl -> hex -> rgb -> int
        var rgb = kv.Value.ColorToRgb();
        var dye = dyeFac.Make(rgb);
        var rgbToHsl = rgb.RgbToHsl();
        var hslToHex = rgbToHsl.HslToHex();
        var hexToRgb = Conv.HexToRgb(hslToHex);
        var rgbToInt = hexToRgb.RgbToInt();
        Console.WriteLine($"{dye(kv.Key)}: {rgb} {rgbToHsl} {hslToHex} {hexToRgb} {rgbToInt}");
      }
    }

    [Test]
    public void RgbToIntToRgbTest() {
      var dyeFac = DyeFactory.Rgb(Effect.Bold, Effect.Underline);
      foreach (var kv in AssetCollection.ITermColorDict) {
        var rgb = kv.Value.ColorToRgb();
        var dye = dyeFac.Make(rgb);
        var val = rgb.RgbToInt();
        var rgb2 = Conv.IntToRgb(val);
        Console.WriteLine($"[{dye(kv.Key)}] {rgb} : {val} : {rgb2}");
      }
    }

    [Test]
    public void ByteAndIntPropertiesTest() {
      int intVal = 255;
      {
        byte byteVal = (byte) intVal;
        $"[int] {intVal} to [byte] {byteVal}".Logger();
      }
      {
        byte byteVal = (byte) intVal;
        $"[int] {intVal} to [byte+1] {++byteVal}".Logger();
      }
      {
        byte byteVal = (byte) (intVal & 0xFF);
        $"[int] {intVal} to [byte] {byteVal}".Logger();
      }
    }
  }
}