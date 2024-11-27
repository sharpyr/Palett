using Texting;
using Typen;
using static System.Double;

namespace Palett.Fluos.Screener {
  public static class ScreenerUtil {
    public static (double x, double y) Assort<T>(T x) {
      if (x == null) return (NaN, NaN);
      var s = x.ToString();
      return TryParse(s, out var n)
        ? (NaN, n)
        : (s.StringValue(), NaN);
    }

    public static double AssortExpandBound<T>(ref (double min, double max)? boundX, T value) {
      var assorted = value.CastDouble();
      ExpandBound(ref boundX, assorted);
      return assorted;
    }

    public static (double x, double y) AssortExpandEntryBound<T>(
      ref (double min, double max)? boundX,
      ref (double min, double max)? boundY,
      T value
    ) {
      var assorted = Assort(value);
      ExpandBound(ref boundX, assorted.x);
      ExpandBound(ref boundY, assorted.y);
      return assorted;
    }

    public static void ExpandBound(ref (double min, double max)? bound, double n) {
      if (IsNaN(n)) return;
      if (bound == null) bound = (n, n);
      else {
        var pair = bound.Value;
        if (n > pair.max) {
          pair.max = n;
        }
        else if (n < pair.min) {
          pair.min = n;
        }
        bound = pair;
      }
    }
  }
}