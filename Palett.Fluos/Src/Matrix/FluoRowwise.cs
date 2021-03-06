using System;
using System.Drawing;
using Palett.Types;
using Veho.Matrix.Rows;

namespace Palett.Fluos.Matrix {
  public static class FluoRowwise {
    
    public static string[][] FluoRows<T>(this T[,] mat, Preset preset, params Effect[] effects) => mat
      .MapRows(row => row.Fluo(preset, effects));

    public static Func<string, string>[][] FluoRowsMake<T>(this T[,] mat, Preset preset, params Effect[] effects) => mat
      .MapRows(row => row.FluoMake(preset, effects));

    public static Color?[][] FluoRowsColor<T>(this T[,] mat, Preset preset) => mat
      .MapRows(row => row.FluoColor(preset));
    
    public static string[][] FluoRows<T>(this T[,] mat, (Preset str, Preset num) presets, params Effect[] effects) => mat
      .MapRows(row => row.Fluo(presets, effects));

    public static Func<string, string>[][] FluoRowsMake<T>(this T[,] mat, (Preset str, Preset num) presets, params Effect[] effects) => mat
      .MapRows(row => row.FluoMake(presets, effects));

    public static Color?[][] FluoRowsColor<T>(this T[,] mat, (Preset str, Preset num) presets) => mat
      .MapRows(row => row.FluoColor(presets));
  }
}