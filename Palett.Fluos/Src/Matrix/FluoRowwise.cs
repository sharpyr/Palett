using System;
using Palett.Utils.Types;
using Veho.Matrix.Rows;

namespace Palett.Fluos.Matrix {
  public static class FluoRowwise {
    public static string[][] FluoRows<T>(this T[,] mat, (Preset, Preset) presets, params Effect[] effects) {
      return mat.MapRows(row => row.Fluo(presets, effects));
    }

    public static Func<string, string>[][] FluoRowsMake<T>(this T[,] mat, (Preset, Preset) presets, params Effect[] effects) {
      return mat.MapRows(row => row.FluoMake(presets, effects));
    }
  }
}