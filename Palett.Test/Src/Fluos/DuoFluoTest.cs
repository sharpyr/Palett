﻿using NUnit.Framework;
using Palett.Fluos;
using Palett.Fluos.Matrix;
using Palett.Fluos.Screener;
using Spare;
using Veho.Types;
using static Palett.Presets;

namespace Palett.Test.Fluos {
  [TestFixture]
  public class DuoFluoTests {
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
      var result = samples.FluoPoints(preset);
      result.Deco().Logger();
    }

    [Test]
    public void FluoRowwiseAndColumnwiseTest() {
      var samples = new[,] {
        {"1", "2", "3", "4"},
        {"8", "9", "10", "11"},
        {"0", "0", "0", "0"},
        {"1", "1", "1", "1"},
      };
      var preset = (Planet, Fresh);

      samples.Fluo(Operated.Columnwise, preset).Deco().Logger();
      samples.Fluo(Operated.Rowwise, preset).Deco().Logger();
    }
  }
}