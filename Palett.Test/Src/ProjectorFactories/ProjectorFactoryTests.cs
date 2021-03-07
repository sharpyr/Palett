using System;
using System.Linq;
using NUnit.Framework;
using Palett.Projector;
using Palett.Types;

namespace Palett.Test.ProjectorFactories {
  [TestFixture]
  public class ProjectorFactoryTests {
    [Test]
    public void Test() {
      var bound = (0, 5);
      var preset = Presets.Fresh;
      var effects = new Effect[] { };
      var factory = ProjectorFactory.Build(bound, preset, effects);
      foreach (var i in Enumerable.Range(0, 5)) {
        var dye = factory.Make(i);
        Console.WriteLine($"[{i}]: {dye("some")}");
      }
    }
  }
}