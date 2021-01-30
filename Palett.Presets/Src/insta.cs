using Palett.Types;
using static Palett.Cards.CardCollection;

namespace Palett.Presets {
  public static partial class PresetCollection {
    public static Preset Insta = new Preset {
      Max = Orange.Accent2,
      Min = Purple.Accent1,
      Na = Grey.Lighten2,
    };
  }
}