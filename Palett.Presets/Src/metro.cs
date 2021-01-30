using Palett.Types;
using static Palett.Cards.CardCollection;

namespace Palett.Presets {
  public static partial class PresetCollection {
    public static Preset Metro = new Preset {
      Max = Pink.Lighten2,
      Min = Blue.Lighten4,
      Na = Teal.Accent3,
    };
  }
}