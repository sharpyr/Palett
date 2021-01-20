using System;
using MiscUtil;

namespace Palett.Convert {
  public struct ColorBound<T> where T : IComparable<T> {
    public T Max { get; set; }
    public T Sum { get; set; }
    public T Dif { get; set; }

    public static ColorBound<T> From((T, T, T) xyz) {
      var (x, y, z) = xyz;
      var va = x;
      var vi = x;
      if (y.CompareTo(x) > 0) { va = y; } else { vi = y; }
      if (z.CompareTo(va) > 0) { va = z; }
      if (vi.CompareTo(z) > 0) { vi = z; }
      return new ColorBound<T>() {
        Max = va,
        Sum = Operator.Add(va, vi),
        Dif = Operator.Subtract(va, vi)
      };
    }

    public (T, T, T) ToMaxSumDif() => (this.Max, this.Sum, this.Dif);
  }
}