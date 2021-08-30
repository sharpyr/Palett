using NUnit.Framework;
using Palett.Dye;

namespace Palett.Test.Munsell {
  [TestFixture]
  public partial class MunsellTests {
    public (byte, byte, byte) Rgb = ((byte)203, (byte)52, (byte)65);
    public (float, float, float) Hsl => (45, 72, 72); //Rgb.RgbToHsl();
    public (byte, byte, byte) EpsilonRgb = ((byte)12, (byte)12, (byte)12);
    public (float, float, float) EpsilonHsl = ((float)10, (float)8, (float)5);
    public double SaturTolerance = 18;
    public double LightMinimum = 20;
    public double Density = 0.005;
    // public double SaturationDeviation = 1;
    public readonly DyeFactory<string> Dyer = DyeFactory.Hex();
    public int Top = 15;
    public string SearchText = "\\slilac";
  }
}