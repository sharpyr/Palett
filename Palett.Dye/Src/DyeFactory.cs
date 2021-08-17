using System;
using System.Collections.Generic;
using System.Drawing;
using Palett.Types;
using Palett.Utils.Ansi;
using static Palett.Utils.Ansi.ControlCodes;
using HSL = System.ValueTuple<float, float, float>;
using RGB = System.ValueTuple<byte, byte, byte>;

namespace Palett.Dye {
  public static class DyeFactory {
    public static DyeFactory<RGB> Rgb(params Effect[] effects) => DyeFactory<RGB>.Build(AnsiProjector.RgbToAnsi, effects);
    public static DyeFactory<HSL> Hsl(params Effect[] effects) => DyeFactory<HSL>.Build(AnsiProjector.HslToAnsi, effects);
    public static DyeFactory<string> Hex(params Effect[] effects) => DyeFactory<string>.Build(AnsiProjector.HexToAnsi, effects);

    public static DyeFactory<Color> Color(params Effect[] effects) => DyeFactory<Color>.Build(AnsiProjector.ColorToAnsi, effects);
  }

  public class DyeFactory<T> {
    private string _head = "";
    private string _tail = "";
    private Func<T, string> _ansi;

    public static DyeFactory<T> Build(Func<T, string> ansi, params Effect[] effects) =>
      new DyeFactory<T> {_ansi = ansi}.AssignEffects(effects);

    private DyeFactory<T> AssignEffects(IEnumerable<Effect> effects) {
      foreach (var effect in effects) {
        var (h, t) = effect.EffectToAnsi();
        _head += SC + h;
        _tail += SC + t;
      }
      return this;
    }

    public (string, string) Toning(T color) {
      var c = _ansi(color);
      var h = L + _head + SC + c + R;
      var t = L + _tail + R;
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