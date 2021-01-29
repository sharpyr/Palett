using System;
using Aryth.Bounds;
using Palett.Fluos.Utils;
using Palett.Projector;
using Palett.Utils.Types;
using Typen;
using Veho.Matrix;
using Veho.Matrix.Columns;
using Veho.Matrix.Rows;

namespace Palett.Fluos {
  public static class FluoColumnwise {
    public static string[][] FluoColumns<T>(this T[,] mat, (Preset, Preset) presets, params Effect[] effects) {
      return mat.MapColumns(row => row.Fluo(presets, effects));
    }

    public static Func<string, string>[][] FluoColumnsMake<T>(this T[,] mat, (Preset, Preset) presets, params Effect[] effects) {
      return mat.MapColumns(row => row.FluoMake(presets, effects));
    }
  }
}