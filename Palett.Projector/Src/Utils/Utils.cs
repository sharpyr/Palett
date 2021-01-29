using System;

namespace Palett.Projector.Utils {
  public static class Utils {
    public static (TO, TO, TO) Map<T, TO>(this (T x, T y, T z) xyz, Func<T, TO> f) => (f(xyz.x), f(xyz.y), f(xyz.z));
  }
}