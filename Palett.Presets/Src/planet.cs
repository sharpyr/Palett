using Palett.Types;
using static Palett.Cards.CardCollection;

namespace Palett.Presets {
  public static partial class PresetCollection {
    public static Preset Planet = new Preset {
      Max = Teal.Accent2,
      Min = Blue.Darken3,
      Na = Cyan.Lighten4,
    };
  }
}