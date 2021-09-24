using System;
using System.Drawing;
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
    public static readonly HSL HslA = Color.FromArgb(166, 241, 195).ColorToHsl(); // Ambrosia
    public static readonly HSL HSLB = Color.FromArgb(179, 084, 087).ColorToHsl(); // Mineral Red
    public static readonly Func<HSL, string> Stringify = hsl => {
      var entry = hsl.Comparative();
      var _hsl = Conv.HexToHsl(entry.hex);
      return HslDyer.Render(_hsl, $"{entry.name} {_hsl.Deco(false)}");
    };

    [Test]
    public void GradientTestHueByLightness() {
      Console.WriteLine($">> [x] Hue [y] Lightness");
      Console.WriteLine($">> [a] {HslDyer.Render(HslA, HslA.Deco(false))} [b] {HslDyer.Render(HSLB, HSLB.Deco(false))}");
      var crostab = (HslA, HSLB).GradientCrostab(HSLDimension.H, HSLDimension.L, 4, 4);
      var stringCrostab = crostab.Map(Stringify);
      Console.WriteLine($">> [gradient crostab]\n{stringCrostab.Deco(hasAnsi: true)}");
    }
    [Test]
    public void GradientTestHueBySaturation() {
      Console.WriteLine($">> [x] Hue [y] Saturation");
      Console.WriteLine($">> [a] {HslDyer.Render(HslA, HslA.Deco(false))} [b] {HslDyer.Render(HSLB, HSLB.Deco(false))}");
      var crostab = (HslA, HSLB).GradientCrostab(HSLDimension.H, HSLDimension.S, 4, 4);
      var stringCrostab = crostab.Map(Stringify);
      Console.WriteLine($">> [gradient crostab]\n{stringCrostab.Deco(hasAnsi: true)}");
    }
    [Test]
    public void GradientTestSaturationByLightness() {
      Console.WriteLine($">> [x] Saturation [y] Lightness");
      Console.WriteLine($">> [a] {HslDyer.Render(HslA, HslA.Deco(false))} [b] {HslDyer.Render(HSLB, HSLB.Deco(false))}");
      var crostab = (HslA, HSLB).GradientCrostab(HSLDimension.S, HSLDimension.L, 4, 6);
      var stringCrostab = crostab.Map(Stringify);
      Console.WriteLine($">> [gradient crostab]\n{stringCrostab.Deco(hasAnsi: true)}");
    }
    [Test]
    public void GradientTestSaturationByHue() {
      Console.WriteLine($">> [x] Saturation [y] Hue");
      Console.WriteLine($">> [a] {HslDyer.Render(HslA, HslA.Deco(false))} [b] {HslDyer.Render(HSLB, HSLB.Deco(false))}");
      var crostab = (HslA, HSLB).GradientCrostab(HSLDimension.S, HSLDimension.H, 4, 6);
      var stringCrostab = crostab.Map(Stringify);
      Console.WriteLine($">> [gradient crostab]\n{stringCrostab.Deco(hasAnsi: true)}");
    }
    [Test]
    public void GradientTestLightnessByHue() {
      Console.WriteLine($">> [x] Lightness [y] Hue");
      Console.WriteLine($">> [a] {HslDyer.Render(HslA, HslA.Deco(false))} [b] {HslDyer.Render(HSLB, HSLB.Deco(false))}");
      var crostab = (HslA, HSLB).GradientCrostab(HSLDimension.L, HSLDimension.H, 6, 4);
      var stringCrostab = crostab.Map(Stringify);
      Console.WriteLine($">> [gradient crostab]\n{stringCrostab.Deco(hasAnsi: true)}");
    }
    [Test]
    public void GradientTestLightnessBySaturation() {
      Console.WriteLine($">> [x] Lightness [y] Saturation");
      Console.WriteLine($">> [a] {HslDyer.Render(HslA, HslA.Deco(false))} [b] {HslDyer.Render(HSLB, HSLB.Deco(false))}");
      var crostab = (HslA, HSLB).GradientCrostab(HSLDimension.L, HSLDimension.S, 6, 4);
      var stringCrostab = crostab.Map(Stringify);
      Console.WriteLine($">> [gradient crostab]\n{stringCrostab.Deco(hasAnsi: true)}");
    }
  }
}