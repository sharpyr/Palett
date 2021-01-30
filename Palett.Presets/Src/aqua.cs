using Palett.Types;
using static Palett.Cards.CardCollection;

namespace Palett.Presets {
  public static partial class PresetCollection {
    public static Preset Aqua = new Preset {
      Max = Cyan.Accent2,
      Min = Green.Darken1,
      Na = Grey.Lighten4,
    };
  }
}