using System;
using Aryth.Bounds;
using Palett.Projector;
using Palett.Utils.Types;
using Typen;
using Veho.Vector;

namespace Palett.Fluos {
  public static class FluoCollection {
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
    public static string[] Fluo<T>(this T[] vec, (Preset, Preset) presets, params Effect[] effects) {
      var texts = vec.Map(Conv.ToStr);
      var ((vecX, facX), (vecY, facY)) = texts.MakeProjector(presets, effects);
      Func<double, double, string, string> zipperFunc = (x, y, tx) => {
        if (!double.IsNaN(x)) return facX.Render(x, tx);
        if (!double.IsNaN(y)) return facY.Render(y, tx);
        return facX.Render(double.NaN, tx);
      };
      return zipperFunc.Zipper(vecX, vecY, texts);
    }

    public static Func<string, string>[] FluoMake<T>(this T[] vec, (Preset, Preset) presets, params Effect[] effects) {
      var texts = vec.Map(Conv.ToStr);
      var ((vecX, facX), (vecY, facY)) = texts.MakeProjector(presets, effects);
      Func<double, double, Func<string, string>> zipperFunc = (x, y) => {
        if (!double.IsNaN(x)) return facX.Make(x);
        if (!double.IsNaN(y)) return facY.Make(y);
        return facX.Make(double.NaN);
      };
      return zipperFunc.Zipper(vecX, vecY);
    }
  }
}