using RGB = System.ValueTuple<byte, byte, byte>;
using HSL = System.ValueTuple<float, float, float>;

namespace Palett.Types {
  public class Preset {
    public string Min { get; set; }
    public string Max { get; set; }
    public string Na { get; set; }

    // public static Preset Build(RGB min, RGB max, RGB na) { return new Preset {Min=min,Max=max,Na=na}; }
    // public static Preset Build(HSL min, HSL max, HSL na) { return new Preset {Min=min,Max=max,Na=na}; }
    public static Preset Build(string min, string max, string na = "#FFFFFF") => new Preset {Min = min, Max = max, Na = na};
    // public static Preset Build(int min, int max, int na = 0) { return new Preset {Min=min,Max=max,Na=na}; }
  }
}