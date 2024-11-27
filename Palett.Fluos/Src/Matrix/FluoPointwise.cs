using System;
using System.Drawing;
using Palett.Fluos.Screener;
using Palett.Fluos.Utils;
using Palett.Types;
using Veho.Matrix;

namespace Palett.Fluos.Matrix {
  public static class FluoPointwise {
    public static string[,] FluoPoints<T>(this T[,] mat, Preset preset, params Effect[] effects) {
      var texts = mat.Map(Typen.Conv.ToStr);
      var (body, fac) = texts.MakeProjector(preset, effects);
      return body.Zip(texts, ProjectorMapperFactory.RenderMapper(fac));
    }
    public static Func<string, string>[,] FluoPointsMake<T>(this T[,] mat, Preset preset, params Effect[] effects) {
      var (body, fac) = mat.MakeProjector(preset, effects);
      return body.Map(ProjectorMapperFactory.MakerMapper(fac));
    }
    public static Color[,] FluoPointsColor<T>(this T[,] mat, Preset preset, params Effect[] effects) {
      var (body, fac) = mat.MakeProjector(preset, effects);
      return body.Map(ProjectorMapperFactory.ColorMapper(fac));
    }

    public static string[,] FluoPoints<T>(this T[,] mat, (Preset str, Preset num) presets, params Effect[] effects) {
      var texts = mat.Map(Typen.Conv.ToStr);
      var ((matX, facX), (matY, facY)) = texts.MakeProjector(presets, effects);
      return ProjectorZipperFactory.RenderZipper(facX, facY).Zipper(matX, matY, texts);
    }
    public static Func<string, string>[,] FluoPointsMake<T>(this T[,] mat, (Preset str, Preset num) presets, params Effect[] effects) {
      var ((matX, facX), (matY, facY)) = mat.MakeProjector(presets, effects);
      return ProjectorZipperFactory.MakerZipper(facX, facY).Zipper(matX, matY);
    }
    public static Color[,] FluoPointsColor<T>(this T[,] mat, (Preset str, Preset num) presets) {
      var ((matX, facX), (matY, facY)) = mat.MakeProjector(presets);
      return ProjectorZipperFactory.ColorZipper(facX, facY).Zipper(matX, matY);
    }

    public static ((double[,], Projector), (double[,], Projector)) MakeProjector<T>(
      this T[,] mat,
      (Preset str, Preset num) presets,
      params Effect[] effects
    ) {
      var (preX, preY) = presets;
      var ((matX, bdX), (matY, bdY)) = mat.DuoBound();
      var facX = ProjectorFactory.Build(bdX, preX, effects);
      var facY = ProjectorFactory.Build(bdY, preY, effects);
      return ((matX, facX), (matY, facY));
    }

    public static (double[,], Projector) MakeProjector<T>(
      this T[,] vec,
      Preset preset,
      params Effect[] effects
    ) {
      var (vector, bound) = vec.SoleBound();
      var projector = ProjectorFactory.Build(bound, preset, effects);
      return (vector, projector);
    }
  }
}