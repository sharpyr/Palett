﻿using System;
using System.Collections.Generic;
using Palett.Utils.Ansi;
using Palett.Utils.Types;
using static Palett.Utils.Ansi.ControlCodes;
using HSL = System.ValueTuple<float, float, float>;
using RGB = System.ValueTuple<byte, byte, byte>;

namespace Palett.Dye {
  public static class DyeFactory {
    public static DyeFactory<RGB> Rgb(params Effect[] effects) => DyeFactory<RGB>.Build(ColorToAnsi.RgbToAnsi, effects);
    public static DyeFactory<HSL> Hsl(params Effect[] effects) => DyeFactory<HSL>.Build(ColorToAnsi.HslToAnsi, effects);
    public static DyeFactory<string> Hex(params Effect[] effects) => DyeFactory<string>.Build(ColorToAnsi.HexToAnsi, effects);
  }

  public class DyeFactory<T> {
    private string head = "";
    private string tail = "";
    private Func<T, string> ansi;

    public static DyeFactory<T> Build(Func<T, string> ansi, params Effect[] effects) =>
      new DyeFactory<T> {ansi = ansi}.AssignEffects(effects);

    private DyeFactory<T> AssignEffects(IEnumerable<Effect> effects) {
      foreach (var effect in effects) {
        var (h, t) = effect.EffectToAnsi();
        head += SC + h;
        tail += SC + t;
      }
      return this;
    }

    public (string, string) Toning(T color) {
      var c = ansi(color);
      var h = L + head + SC + c + R;
      var t = L + tail + R;
      return (h, t);
    }

    public string Render(T color, string text) {
      var (h, t) = Toning(color);
      return h + text + t;
    }

    public Func<string, string> Make(T color) {
      var (h, t) = Toning(color);
      return text => h + text + t;
    }
  }
}