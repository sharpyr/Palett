using Aryth.Bounds;
using NUnit.Framework;
using Palett.Fluos;
using Spare.Deco;
using Spare.Logger;
using static Palett.Presets.PresetCollection;

namespace Palett.Test.Fluos {
  [TestFixture]
  public class FluosTests {
    [Test]
    public void FluoVectorTest() {
      var samples = new[] {"a", "foo", "bar", "zene", "1", "2", "3"};
      var ((veX, bdX), (veY, bdY)) = samples.DuoBound();
      $"X [vec] {veX.Deco()} [bound] {bdX}".Logger();
      $"Y [vec] {veY.Deco()} [bound] {bdY}".Logger();
      var preset = (Planet, Fresh);
      var result = samples.Fluo(preset);
      result.Deco().Logger();
    }

    [Test]
    public void FluoMatrixTest() {
      var samples = new[,] {
        {"foo", "bar", "zen",},
        {"USA", "CHN", "DEU",},
        {"1", "2", "3"},
        {"8", "9", "10"},
      };
      var ((veX, bdX), (veY, bdY)) = samples.DuoBound();
      $"X [vec] {veX.Deco()} [bound] {bdX}".Logger();
      $"Y [vec] {veY.Deco()} [bound] {bdY}".Logger();
      var preset = (Planet, Fresh);
      var result = samples.Fluo(preset);
      result.Deco().Logger();
    }
  }
}