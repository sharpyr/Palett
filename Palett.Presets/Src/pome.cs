using Palett.Types; 
using static Palett.Cards;

namespace Palett {
  public static partial class Presets {
    public static Preset Pome = new Preset {
      Max = Red.Lighten2,
      Min = Yellow.Darken1,
      Na = Green.Lighten2,
    };
  }
}