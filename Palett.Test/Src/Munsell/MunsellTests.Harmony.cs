using System.Diagnostics;
using NUnit.Framework;
using Spare;

namespace Palett.Test.Munsell {
  [TestFixture]
  public partial class MunsellTests{
    [Test]
    public void RhodoneaFoliosTest() {
      Debug.Print($">> [HSB] {Hsl}");
      var list = Hsl.RhodoneaFolios(5, Density, LightMinimum, SaturTolerance, Domain.Fashion);
      list
        .DecoPalett()
        .Says("RhodoneaFolios");
    }

    [Test]
    public void AnalogousTest() {
      Debug.Print($">> [HSB] {Hsl}");
      var list = Hsl.Analogous(-30, 12);
      list
        .DecoPalett()
        .Says("Analogous");
    }
  }
}