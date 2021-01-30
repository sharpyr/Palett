using Palett.Types;
using static Palett.Cards.CardCollection;

namespace Palett.Presets {
  public static partial class PresetCollection {
    public static Preset Lava = new Preset {
      Max = Amber.Accent3,
      Min = Red.Lighten1,
      Na = Grey.Accent2,
    };
  }
}