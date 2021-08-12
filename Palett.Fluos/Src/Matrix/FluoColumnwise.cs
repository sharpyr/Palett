using System;
using System.Drawing;
using Palett.Types;
using Veho.Columns;

namespace Palett.Fluos.Matrix {
  public static class FluoColumnwise {
    public static string[][] FluoColumns<T>(this T[,] mat, Preset preset, params Effect[] effects) => mat
      .MapColumns(row => row.Fluo(preset, effects));

    public static Func<string, string>[][] FluoColumnsMake<T>(this T[,] mat, Preset preset, params Effect[] effects) => mat
      .MapColumns(row => row.FluoMake(preset, effects));

    public static Color?[][] FluoColumnsColor<T>(this T[,] mat, Preset preset) => mat
      .MapColumns(row => row.FluoColor(preset));

    public static string[][] FluoColumns<T>(this T[,] mat, (Preset str, Preset num) presets, params Effect[] effects) => mat
      .MapColumns(row => row.Fluo(presets, effects));

    public static Func<string, string>[][] FluoColumnsMake<T>(this T[,] mat, (Preset str, Preset num) presets, params Effect[] effects) => mat
      .MapColumns(row => row.FluoMake(presets, effects));

    public static Color?[][] FluoColumnsColor<T>(this T[,] mat, (Preset str, Preset num) presets) => mat
      .MapColumns(row => row.FluoColor(presets));
  }
}