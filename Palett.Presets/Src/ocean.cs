using Palett.Utils.Types;
using static Palett.Cards.CardCollection;

namespace Palett.Presets {
  public static partial class PresetCollection {
    public static Preset Ocean = new Preset {
      Max = LightBlue.Accent2,
      Min = Indigo.Basis,
      Na = Pink.Lighten3,
    };
  }
}