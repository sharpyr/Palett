using NUnit.Framework;
using Palett.Fluos;
using Spare.Deco;
using Spare.Logger;
using static Palett.Presets.PresetCollection;

namespace Palett.Test.Fluos {
  [TestFixture]
  public class FluosTests {
    [Test]
    public void Test() {
      var samples = new[] {"foo", "bar", "zene", "-", "1", "2", "3"};
      var preset = (Planet, Fresh);
      var result = samples.Fluo(preset);
      result.Deco().Logger();
    }
  }
}