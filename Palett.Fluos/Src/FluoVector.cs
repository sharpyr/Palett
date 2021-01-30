using System;
using System.Drawing;
using Aryth.Bounds;
using Palett.Fluos.Utils;
using Palett.Projector;
using Palett.Types;
using Typen;
using Veho.Vector;

namespace Palett.Fluos {
  public static class FluoVector {
    
    public static string[] Fluo<T>(this T[] vec, Preset preset, params Effect[] effects) {
      var texts = vec.Map(Conv.ToStr);
      var (body, fac) = texts.MakeProjector(preset, effects);
      return body.Zip(texts, ProjectorMapperFactory.RenderMapper(fac));
    }
    public static Func<string, string>[] FluoMake<T>(this T[] vec, Preset preset, params Effect[] effects) {
      var (body, fac) = vec.MakeProjector(preset, effects);
      return body.Map(ProjectorMapperFactory.MakerMapper(fac));
    }
    public static Color?[] FluoColor<T>(this T[] vec, Preset preset, params Effect[] effects) {
      var (body, fac) = vec.MakeProjector(preset, effects);
      return body.Map(ProjectorMapperFactory.ColorMapper(fac));
    }
    
    public static string[] Fluo<T>(this T[] vec, (Preset, Preset) presets, params Effect[] effects) {
      var texts = vec.Map(Conv.ToStr);
      var ((vecX, facX), (vecY, facY)) = texts.MakeProjector(presets, effects);
      return ProjectorZipperFactory.RenderZipper(facX, facY).Zipper(vecX, vecY, texts);
    }
    public static Func<string, string>[] FluoMake<T>(this T[] vec, (Preset, Preset) presets, params Effect[] effects) {
      var ((vecX, facX), (vecY, facY)) = vec.MakeProjector(presets, effects);
      return ProjectorZipperFactory.MakerZipper(facX, facY).Zipper(vecX, vecY);
    }
    public static Color?[] FluoColor<T>(this T[] vec, (Preset, Preset) presets, params Effect[] effects) {
      var ((vecX, facX), (vecY, facY)) = vec.MakeProjector(presets, effects);
      return ProjectorZipperFactory.ColorZipper(facX, facY).Zipper(vecX, vecY);
    }

    private static ((double[], ProjectorFactory), (double[], ProjectorFactory)) MakeProjector<T>(
      this T[] vec,
      (Preset, Preset) presets,
      params Effect[] effects
    ) {
      var (preX, preY) = presets;
      var ((vecX, bdX), (vecY, bdY)) = vec.DuoBound();
      var facX = ProjectorFactory.Build(bdX, preX, effects);
      var facY = ProjectorFactory.Build(bdY, preY, effects);
      return ((vecX, facX), (vecY, facY));
    }

    public static (double[], ProjectorFactory) MakeProjector<T>(
      this T[] vec,
      Preset preset,
      params Effect[] effects
    ) {
      var (vector, bound) = vec.SoleBound();
      var projectorFactory = ProjectorFactory.Build(bound, preset, effects);
      return (vector, projectorFactory);
    }
  }
}