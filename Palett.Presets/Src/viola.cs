using Palett.Utils.Types;
using static Palett.Cards.CardCollection;

namespace Palett.Presets {
  public static partial class PresetCollection {
    public static Preset Viola = new Preset {
      Max = Pink.Lighten4,
      Min = DeepPurple.Accent2,
      Na = Amber.Darken2,
    };
  }
}