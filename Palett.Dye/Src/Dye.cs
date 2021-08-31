using System;
using System.Collections.Generic;
using Palett.Types;
using Palett.Utils.Ansi;
using static Palett.Utils.Ansi.ControlCodes;
using HSL = System.ValueTuple<float, float, float>;
using RGB = System.ValueTuple<byte, byte, byte>;

namespace Palett.Dye {


  public class Dye<T> {
    private string _head = "";
    private string _tail = "";
    private Func<T, string> _ansi;

    public static Dye<T> Build(Func<T, string> ansi, params Effect[] effects) =>
      new Dye<T> { _ansi = ansi }.AssignEffects(effects);

    private Dye<T> AssignEffects(IEnumerable<Effect> effects) {
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