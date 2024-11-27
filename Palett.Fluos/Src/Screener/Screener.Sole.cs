using System.Collections.Generic;
using Veho.Columns;
using Veho.Matrix;
using Veho.Rows;
using Veho.Vector;

namespace Palett.Fluos.Screener {
  public static partial class Screener {
    
    public static (double[] vec, (double min, double max)? bound) SoleBound<T>(this IReadOnlyList<T> vector) {
      (double min, double max)? bound = null;
      var vec = vector.Map(x => ScreenerUtil.AssortExpandBound(ref bound, x));
      return (vec, bound);
    }
    public static (double[,] mat, (double min, double max)? bound) SoleBound<T>(this T[,] matrix) {
      (double min, double max)? bound = null;
      var vec = matrix.Map(x => ScreenerUtil.AssortExpandBound(ref bound, x));
      return (vec, bound);
    }

    public static (double[] vec, (double min, double max)? bound) SoleBoundRow<T>(this T[,] matrix, int x, int w = 0) {
      (double min, double max)? bound = null;
      var vec = matrix.Row(x, v => ScreenerUtil.AssortExpandBound(ref bound, v), w);
      return (vec, bound);
    }

    public static (double[] vec, (double min, double max)? bound) SoleBoundColumn<T>(this T[,] matrix, int y, int h = 0) {
      (double min, double max)? bound = null;
      var vec = matrix.Column(y, v => ScreenerUtil.AssortExpandBound(ref bound, v), h);
      return (vec, bound);
    }
    
    
  }
}