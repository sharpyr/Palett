using Palett.Types; 
using static Palett.Cards;

namespace Palett {
  public static partial class Presets {
    public static Preset Metro = new Preset {
      Max = Pink.Lighten2,
      Min = Blue.Lighten4,
      Na = Teal.Accent3,
    };
  }
}