using System;
using Palett.Utils.Types;
using Veho.Matrix.Columns;

namespace Palett.Fluos.Matrix {
  public static class FluoColumnwise {
    public static string[][] FluoColumns<T>(this T[,] mat, (Preset, Preset) presets, params Effect[] effects) {
      return mat.MapColumns(row => row.Fluo(presets, effects));
    }

    public static Func<string, string>[][] FluoColumnsMake<T>(this T[,] mat, (Preset, Preset) presets, params Effect[] effects) {
      return mat.MapColumns(row => row.FluoMake(presets, effects));
    }
  }
}