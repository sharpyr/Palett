using System;
using System.Drawing;
using Palett.Fluos.Matrix;
using Palett.Utils.Types;
using Veho.Matrix.Columns;
using Veho.Matrix.Rows;
using Veho.Types;

namespace Palett.Fluos {
  public static class FluoMatrix {
    public static string[,] Fluo<T>(this T[,] vec, Operated operated, (Preset, Preset) presets, params Effect[] effects) {
      switch (operated) {
        case Operated.Pointwise: return vec.FluoPoints(presets, effects);
        case Operated.Rowwise: return vec.FluoRows(presets, effects).RowsToMatrix();
        case Operated.Columnwise: return vec.FluoColumns(presets, effects).ColumnsToMatrix();
        default: return default;
      }
    }

    public static Func<string, string>[,] FluoMake<T>(this T[,] vec, Operated operated, (Preset, Preset) presets, params Effect[] effects) {
      switch (operated) {
        case Operated.Pointwise: return vec.FluoPointsMake(presets, effects);
        case Operated.Rowwise: return vec.FluoRowsMake(presets, effects).RowsToMatrix();
        case Operated.Columnwise: return vec.FluoColumnsMake(presets, effects).ColumnsToMatrix();
        default: return default;
      }
    }

    public static Color?[,] FluoColor<T>(this T[,] vec, Operated operated, (Preset, Preset) presets) {
      switch (operated) {
        case Operated.Pointwise: return vec.FluoPointsColor(presets);
        case Operated.Rowwise: return vec.FluoRowsColor(presets).RowsToMatrix();
        case Operated.Columnwise: return vec.FluoColumnsColor(presets).ColumnsToMatrix();
        default: return default;
      }
    }
  }
}