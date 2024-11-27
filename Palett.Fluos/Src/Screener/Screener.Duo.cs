using System.Collections.Generic;
using Veho;
using Veho.Columns;
using Veho.Matrix;
using Veho.Rows;
using Veho.Vector;

namespace Palett.Fluos.Screener {
  public static partial class Screener {
    public static ((double[] vec, (double min, double max)?) x, (double[] vec, (double min, double max)?) y) DuoBound<T>(this IReadOnlyList<T> vector) {
      (double min, double max)? bdX = null;
      (double min, double max)? bdY = null;
      var entries = vector.Map(x => ScreenerUtil.AssortExpandEntryBound(ref bdX, ref bdY, x));
      var (veX, veY) = Ent.Unwind(entries);
      return ((veX, bdX), (veY, bdY));
    }

    public static ((double[,] mat, (double min, double max)?) x, (double[,] mat, (double min, double max)?) y) DuoBound<T>(this T[,] matrix) {
      (double min, double max)? bdX = null;
      (double min, double max)? bdY = null;
      var (veX, veY) = matrix
                       .Map(x => ScreenerUtil.AssortExpandEntryBound(ref bdX, ref bdY, x))
                       .Unwind();
      return ((veX, bdX), (veY, bdY));
    }

    public static ((double[] vec, (double min, double max)?) x, (double[] vec, (double min, double max)?) y) DuoBoundRow<T>(this T[,] matrix, int x, int w = 0) {
      (double min, double max)? bdX = null;
      (double min, double max)? bdY = null;
      var entries = matrix.Row(x, v => ScreenerUtil.AssortExpandEntryBound(ref bdX, ref bdY, v), w);
      
      var (veX, veY) = Ent.Unwind(entries);
      return ((veX, bdX), (veY, bdY));
    }

    public static ((double[] vec, (double min, double max)?) x, (double[] vec, (double min, double max)?) y) DuoBoundColumn<T>(this T[,] matrix, int y, int h = 0) {
      (double min, double max)? bdX = null;
      (double min, double max)? bdY = null;
      var entries = matrix.Column(y, v => ScreenerUtil.AssortExpandEntryBound(ref bdX, ref bdY, v), h);
      var (veX, veY) = Ent.Unwind(entries);
      return ((veX, bdX), (veY, bdY));
    }
  }
}