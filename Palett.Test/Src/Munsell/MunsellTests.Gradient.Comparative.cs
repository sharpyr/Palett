using System;
using Analys;
using NUnit.Framework;
using Palett.Dye;
using Palett.Types;
using HSL = System.ValueTuple<float, float, float>;

namespace Palett.Test.Munsell {
  [TestFixture]
  public class MunsellTests_Comparative {
    public static readonly Dye<HSL> HslDyer = DyeFactory.Hsl(Effect.Inverse);
    public static readonly Dye<string> HexDyer = DyeFactory.Hex(Effect.Inverse);
    public static readonly HSL HslA = (330, 50, 85); // Conv.HexToHsl("#BCE3DF"); // Bleached Aqua
    public static readonly HSL HSLB = (015, 95, 45); // Conv.HexToHsl("#379190"); // Latigo bay
    public static readonly Func<int, int, HSL, string> Stringify = (x, y, hsl) => {
      Console.WriteLine($">> [dealing] {x} {y} {hsl.Deco(false)}");
      var entry = hsl.Comparative();
      var _hsl = Conv.HexToHsl(entry.hex);
      return HslDyer.Render(_hsl, $"{entry.name} {entry.hex}");
      // return HslDyer.Render(_hsl, $"{entry.name} {_hsl.Deco(false)}");
    };

    [Test]
    public void GradientTestHueByLightness() {
      Console.WriteLine($">> [x] Hue [y] Lightness");
      Console.WriteLine($">> [a] {HslDyer.Render(HslA, HslA.Deco(false))} [b] {HslDyer.Render(HSLB, HSLB.Deco(false))}");
      var crostab = (HslA, HSLB).GradientCrostab(HSLAttr.H, HSLAttr.L, 4, 4);
      var stringCrostab = crostab.Map(Stringify);
      Console.WriteLine($">> [gradient crostab]\n{stringCrostab.Deco(hasAnsi: true)}");
    }
    [Test]
    public void GradientTestHueBySaturation() {
      Console.WriteLine($">> [x] Hue [y] Saturation");
      Console.WriteLine($">> [a] {HslDyer.Render(HslA, HslA.Deco(false))} [b] {HslDyer.Render(HSLB, HSLB.Deco(false))}");
      var crostab = (HslA, HSLB).GradientCrostab(HSLAttr.H, HSLAttr.S, 4, 4);
      var stringCrostab = crostab.Map(Stringify);
      Console.WriteLine($">> [gradient crostab]\n{stringCrostab.Deco(hasAnsi: true)}");
    }
    [Test]
    public void GradientTestSaturationByLightness() {
      Console.WriteLine($">> [x] Saturation [y] Lightness");
      Console.WriteLine($">> [a] {HslDyer.Render(HslA, HslA.Deco(false))} [b] {HslDyer.Render(HSLB, HSLB.Deco(false))}");
      var crostab = (HslA, HSLB).GradientCrostab(HSLAttr.S, HSLAttr.L, 4, 6);
      var stringCrostab = crostab.Map(Stringify);
      Console.WriteLine($">> [gradient crostab]\n{stringCrostab.Deco(hasAnsi: true)}");
      var size = crostab.Size;
      var hslA = crostab.Rows[0, 0];
      var hslB = crostab.Rows[size.height - 1, size.width - 1];
      Console.WriteLine($">> [a] {HslDyer.Render(hslA, hslA.Deco(false))} [b] {HslDyer.Render(hslB, hslB.Deco(false))}");
    }
    [Test]
    public void GradientTestSaturationByHue() {
      Console.WriteLine($">> [x] Saturation [y] Hue");
      Console.WriteLine($">> [a] {HslDyer.Render(HslA, HslA.Deco(false))} [b] {HslDyer.Render(HSLB, HSLB.Deco(false))}");
      var crostab = (HslA, HSLB).GradientCrostab(HSLAttr.S, HSLAttr.H, 4, 6);
      var stringCrostab = crostab.Map(Stringify);
      Console.WriteLine($">> [gradient crostab]\n{stringCrostab.Deco(hasAnsi: true)}");
    }
    [Test]
    public void GradientTestLightnessByHue() {
      Console.WriteLine($">> [x] Lightness [y] Hue");
      Console.WriteLine($">> [a] {HslDyer.Render(HslA, HslA.Deco(false))} [b] {HslDyer.Render(HSLB, HSLB.Deco(false))}");
      var crostab = (HslA, HSLB).GradientCrostab(HSLAttr.L, HSLAttr.H, 6, 4);
      var stringCrostab = crostab.Map(Stringify);
      Console.WriteLine($">> [gradient crostab]\n{stringCrostab.Deco(hasAnsi: true)}");
    }
    [Test]
    public void GradientTestLightnessBySaturation() {
      Console.WriteLine($">> [x] Lightness [y] Saturation");
      Console.WriteLine($">> [a] {HslDyer.Render(HslA, HslA.Deco(false))} [b] {HslDyer.Render(HSLB, HSLB.Deco(false))}");
      var crostab = (HslA, HSLB).GradientCrostab(HSLAttr.L, HSLAttr.S, 3, 3);
      var stringCrostab = crostab.Map(Stringify);
      Console.WriteLine($">> [gradient crostab]\n{stringCrostab.Deco(hasAnsi: true)}");
    }
  }
}