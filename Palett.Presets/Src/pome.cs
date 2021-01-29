using Palett.Utils.Types;
using static Palett.Cards.CardCollection;

namespace Palett.Presets {
  public static partial class PresetCollection {
    public static Preset Pome = new Preset {
      Max = Red.Lighten2,
      Min = Yellow.Darken1,
      Na = Green.Lighten2,
    };
  }
}