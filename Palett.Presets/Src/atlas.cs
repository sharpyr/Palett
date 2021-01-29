using Palett.Utils.Types;
using static Palett.Cards.CardCollection;

namespace Palett.Presets {
  public static partial class PresetCollection {
    public static Preset Atlas = new Preset {
      Max = Cyan.Lighten3,
      Min = Orange.Lighten2,
      Na = Pink.Lighten4,
    };
  }
}