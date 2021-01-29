using Palett.Utils.Types;
using static Palett.Cards.CardCollection;

namespace Palett.Presets {
  public static partial class PresetCollection {
    public static Preset Fresh = new Preset {
      Max = LightGreen.Accent3,
      Min = DeepOrange.Accent3,
      Na = Blue.Lighten3,
    };
  }
}