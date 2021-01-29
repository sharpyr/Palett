using System;
using Aryth.Bounds;
using Palett.Fluos.Utils;
using Palett.Projector;
using Palett.Utils.Types;
using Typen;
using Veho.Vector;

namespace Palett.Fluos {
  public static class FluoVector {
    public static string[] Fluo<T>(this T[] vec, (Preset, Preset) presets, params Effect[] effects) {
      var texts = vec.Map(Conv.ToStr);
      var ((vecX, facX), (vecY, facY)) = texts.MakeProjector(presets, effects);
      return ZipperFactory.RenderZipper(facX, facY).Zipper(vecX, vecY, texts);
    }

    public static Func<string, string>[] FluoMake<T>(this T[] vec, (Preset, Preset) presets, params Effect[] effects) {
      var ((vecX, facX), (vecY, facY)) = vec.MakeProjector(presets, effects);
      return ZipperFactory.MakerZipper(facX, facY).Zipper(vecX, vecY);
    }

    public static ((double[], ProjectorFactory), (double[], ProjectorFactory)) MakeProjector<T>(
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
  }
}