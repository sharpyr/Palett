using System;
using System.Collections.Generic;
using System.Drawing;
using Aryth.Bounds;
using Palett.Fluos.Utils;
using Palett.Types;
using Veho.Vector;

namespace Palett.Fluos {
  public static class FluoVector {
    public static string[] Fluo<T>(this IReadOnlyList<T> vec, Preset preset, params Effect[] effects) {
      var texts = vec.Map(Typen.Conv.ToStr);
      var (body, projector) = texts.MakeProjector(preset, effects);
      return body.Zip(texts, ProjectorMapperFactory.RenderMapper(projector));
    }
    public static Func<string, string>[] FluoMake<T>(this IReadOnlyList<T> vec, Preset preset, params Effect[] effects) {
      var (body, projector) = vec.MakeProjector(preset, effects);
      return body.Map(ProjectorMapperFactory.MakerMapper(projector));
    }
    public static Color[] FluoColor<T>(this IReadOnlyList<T> vec, Preset preset, params Effect[] effects) {
      var (body, projector) = vec.MakeProjector(preset, effects);
      return body.Map(ProjectorMapperFactory.ColorMapper(projector));
    }

    public static string[] Fluo<T>(this IReadOnlyList<T> vec, (Preset str, Preset num) presets, params Effect[] effects) {
      var texts = vec.Map(Typen.Conv.ToStr);
      var ((vecX, projectorX), (vecY, projectorY)) = texts.MakeProjector(presets, effects);
      return ProjectorZipperFactory.RenderZipper(projectorX, projectorY).Zipper(vecX, vecY, texts);
    }
    public static Func<string, string>[] FluoMake<T>(this IReadOnlyList<T> vec, (Preset str, Preset num) presets, params Effect[] effects) {
      var ((vecX, projectorX), (vecY, projectorY)) = vec.MakeProjector(presets, effects);
      return ProjectorZipperFactory.MakerZipper(projectorX, projectorY).Zipper(vecX, vecY);
    }
    public static Color[] FluoColor<T>(this IReadOnlyList<T> vec, (Preset str, Preset num) presets, params Effect[] effects) {
      var ((vecX, projectorX), (vecY, projectorY)) = vec.MakeProjector(presets, effects);
      return ProjectorZipperFactory.ColorZipper(projectorX, projectorY).Zipper(vecX, vecY);
    }

    private static ((double[], Projector), (double[], Projector)) MakeProjector<T>(
      this IReadOnlyList<T> vec,
      (Preset str, Preset num) presets,
      params Effect[] effects
    ) {
      var (preX, preY) = presets;
      var ((vecX, bdX), (vecY, bdY)) = vec.DuoBound();
      var projectorX = ProjectorFactory.Build(bdX, preX, effects);
      var projectorY = ProjectorFactory.Build(bdY, preY, effects);
      return ((vecX, projectorX), (vecY, projectorY));
    }

    public static (double[], Projector) MakeProjector<T>(
      this IReadOnlyList<T> vec,
      Preset preset,
      params Effect[] effects
    ) {
      var (vector, bound) = vec.SoleBound();
      var projectorFactory = ProjectorFactory.Build(bound, preset, effects);
      return (vector, projectorFactory);
    }
  }
}