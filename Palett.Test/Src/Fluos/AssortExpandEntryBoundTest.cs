using NUnit.Framework;
using Palett.Fluos.Screener;
using Spare;

namespace Palett.Test.Fluos {
  [TestFixture]
  public class AssortExpandEntryBoundTest {
    [Test]
    public void Test() {
      (double, double)? bdX = null;
      (double, double)? bdY = null;
      ScreenerUtil.AssortExpandEntryBound(ref bdX, ref bdY, 1);
      ScreenerUtil.AssortExpandEntryBound(ref bdX, ref bdY, "some");
      ScreenerUtil.AssortExpandEntryBound(ref bdX, ref bdY, "ace");
      $"{bdX}, {bdY}".Logger();
      // $"{0} > {double.NaN} = {double.NaN > 0}".Logger();
    }
  }
}