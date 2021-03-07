using Palett.Types; 
using static Palett.Cards;

namespace Palett {
  public static partial class Presets {
    public static Preset Subtle = new Preset {
      Max = Grey.Lighten5,
      Min = Grey.Darken1,
      Na = Indigo.Lighten3,
    };
  }
}