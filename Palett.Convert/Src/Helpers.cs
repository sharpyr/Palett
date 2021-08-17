using System;

namespace Palett {
  internal static class Hp {
    const float EPSILON = (float) 0.001;

    // public static (P, P, P) Map<T, P>(this (T, T, T) xyz, Func<T, P> fn) {
    //   var (x, y, z) = xyz;
    //   return (fn(x), fn(y), fn(z));
    // }
    // public static (T, T, int) SumDifPos<T>(T x, T y, T z) where T : IComparable<T> {
    //   var (max, min, pos) = (x, x, 1);
    //   if (y.CompareTo(x) > 0) { (max, pos) = (y, 2); } else { min = y; }
    //   if (z.CompareTo(max) > 0) { (max, pos) = (z, 3); }
    //   if (min.CompareTo(z) > 0) { min = z; }
    //   if (min.CompareTo(max) == 0) { pos = 0; }
    //   return (GenericMath<T>.Add(max, min), GenericMath<T>.Subtract(max, min), pos);
    // }

    public static (float sum, float dif, int pos) SumDifPos(float x, float y, float z) {
      var (max, min, pos) = (x, x, 1);
      if (y > x) { (max, pos) = (y, 2); } else { min = y; }
      if (z > max) { (max, pos) = (z, 3); }
      if (z < min) { min = z; }
      float sum = max + min, dif = max - min;
      return (sum, dif, dif < EPSILON ? 0 : pos);
    }

    public static float Hue(float r, float g, float b, float dif, int pos) {
      switch (pos) {
        case 1: return ((g - b) / dif + (g < b ? 6 : 0)) % 6;
        case 2: return (b - r) / dif + 2;
        case 3: return (r - g) / dif + 4;
        default: return 0;
      }
    }

    public static float Hal(float n, float h, float a, float l) {
      var k = (n + h / 30) % 12;
      return l - a * Math.Max(Math.Min(Math.Min(k - 3, 9 - k), 1), -1);
    }
  }
}