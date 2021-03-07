using Palett.Types; 
using static Palett.Cards;

namespace Palett {
  public static partial class Presets {
    public static Preset Atlas = new Preset {
      Max = Cyan.Lighten3,
      Min = Orange.Lighten2,
      Na = Pink.Lighten4,
    };
  }
}