using Palett.Utils.Types;
using static Palett.Cards.CardCollection;

namespace Palett.Presets {
  public static partial class PresetCollection {
    public static Preset Subtle = new Preset {
      Max = Grey.Lighten5,
      Min = Grey.Darken1,
      Na = Indigo.Lighten3,
    };
  }
}