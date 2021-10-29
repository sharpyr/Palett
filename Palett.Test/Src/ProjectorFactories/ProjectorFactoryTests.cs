using System;
using NUnit.Framework;
using Palett.Types;
using Veho;
using static System.Linq.Enumerable;

namespace Palett.Test.ProjectorFactories {
  [TestFixture]
  public class ProjectorFactoryTests {
    [Test]
    public void Test() {
      var bound = (0, 5);
      var collection = Seq.From(
        ("aqua", Presets.Aqua),
        ("atlas", Presets.Atlas),
        ("aurora", Presets.Aurora),
        ("azure", Presets.Azure),
        ("fresh", Presets.Fresh),
        ("insta", Presets.Insta),
        ("jungle", Presets.Jungle),
        ("lava", Presets.Lava),
        ("metro", Presets.Metro),
        ("moss", Presets.Moss),
        ("ocean", Presets.Ocean),
        ("planet", Presets.Planet),
        ("pome", Presets.Pome),
        ("subtle", Presets.Subtle),
        ("viola", Presets.Viola)
      );
      foreach (var (key, preset) in collection) {
        var factory = ProjectorFactory.Build(bound, preset);
        foreach (var i in Range(0, 6)) {
          var dye = factory.Make(i);
          Console.WriteLine($"[{i}] {dye($"{key,6}")} ");
        }
        Console.WriteLine();
      }
    }

    [Test]
    public void Test2() {
      var bound = (0, 5);
      var preset = ((325F, 75F, 45F), (15F, 85F, 70F));
      var effects = new Effect[] { };
      var factory = ProjectorFactory.Build(bound, preset, effects);
      foreach (var i in Range(0, 6)) {
        var dye = factory.Make(i);
        Console.WriteLine($"[{i}]: {dye("some")}");
      }
    }
  }
}