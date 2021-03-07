using NUnit.Framework;
using Palett.Convert;
using Palett.Fluos;
using Palett.Fluos.Matrix;
using Spare.Deco;
using Spare.Logger;
using Veho.Matrix;
using Veho.Types;
using static Palett.Presets;

namespace Palett.Test.Fluos {
  [TestFixture]
  public class SoleFluoTests {
    [Test]
    public void FluoVectorTest() {
      var samples = new[] {"a", "foo", "bar", "zene", "1", "2", "3"};
      // var ((veX, bdX), (veY, bdY)) = samples.DuoBound();
      // $"X [vec] {veX.Deco()} [bound] {bdX}".Logger();
      // $"Y [vec] {veY.Deco()} [bound] {bdY}".Logger();
      var result = samples.Fluo(Planet);
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
      // var ((veX, bdX), (veY, bdY)) = samples.DuoBound();
      // $"X [vec] {veX.Deco()} [bound] {bdX}".Logger();
      // $"Y [vec] {veY.Deco()} [bound] {bdY}".Logger();
      samples.FluoPoints(Planet).Deco().Logger();
      samples.FluoPointsColor(Planet).Map(x => x?.ColorToHsl().ToString() ?? "null").Deco().Logger();
    }

    [Test]
    public void FluoRowwiseAndColumnwiseTest() {
      var samples = new[,] {
        {"1", "2", "3", "4"},
        {"8", "9", "10", "11"},
        {"0", "0", "0", "0"},
        {"1", "1", "1", "1"},
      };
      samples.Fluo(Operated.Columnwise, Planet).Deco().Logger();
      samples.Fluo(Operated.Rowwise, Planet).Deco().Logger();
    }
  }
}