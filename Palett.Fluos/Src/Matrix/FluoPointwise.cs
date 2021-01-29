using System;
using System.Drawing;
using Aryth.Bounds;
using Palett.Fluos.Utils;
using Palett.Projector;
using Palett.Utils.Types;
using Typen;
using Veho.Matrix;

namespace Palett.Fluos.Matrix {
  public static class FluoPointwise {
    public static string[,] FluoPoints<T>(this T[,] mat, (Preset, Preset) presets, params Effect[] effects) {
      var texts = mat.Map(Conv.ToStr);
      var ((matX, facX), (matY, facY)) = texts.MakeProjector(presets, effects);
      return ProjectorUtils.RenderZipper(facX, facY).Zipper(matX, matY, texts);
    }

    public static Func<string, string>[,] FluoPointsMake<T>(this T[,] mat, (Preset, Preset) presets, params Effect[] effects) {
      var ((matX, facX), (matY, facY)) = mat.MakeProjector(presets, effects);
      return ProjectorUtils.MakerZipper(facX, facY).Zipper(matX, matY);
    }

    public static Color?[,] FluoPointsColor<T>(this T[,] mat, (Preset, Preset) presets) {
      var ((matX, facX), (matY, facY)) = mat.MakeProjector(presets);
      return ProjectorUtils.ColorZipper(facX, facY).Zipper(matX, matY);
    }

    public static ((double[,], ProjectorFactory), (double[,], ProjectorFactory)) MakeProjector<T>(
      this T[,] mat,
      (Preset, Preset) presets,
      params Effect[] effects
    ) {
      var (preX, preY) = presets;
      var ((matX, bdX), (matY, bdY)) = mat.DuoBound();
      var facX = ProjectorFactory.Build(bdX, preX, effects);
      var facY = ProjectorFactory.Build(bdY, preY, effects);
      return ((matX, facX), (matY, facY));
    }
  }
}