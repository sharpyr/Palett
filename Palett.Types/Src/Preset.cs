using RGB = System.ValueTuple<byte, byte, byte>;
using HSL = System.ValueTuple<float, float, float>;

namespace Palett.Types {
  public struct Preset {
    public string Min { get; set; }
    public string Max { get; set; }
    public string Na { get; set; }

    public static Preset Build(string min, string max, string na = "#FFFFFF") {
      return new Preset {
                          Min = min,
                          Max = max,
                          Na = na
                        };
    }
  }
}