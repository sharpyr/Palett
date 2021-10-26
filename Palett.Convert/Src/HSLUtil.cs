using System;

namespace Palett {
  internal static class HSLUtil {
    public static float Hal(float n, float h, float a, float l) {
      var k = (n + h / 30) % 12;
      return l - a * Math.Max(Math.Min(Math.Min(k - 3, 9 - k), 1), -1);
    }
  }
}