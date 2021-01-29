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
  }
}