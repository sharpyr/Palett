using System.Collections.Generic;
using System.Linq;
using Veho.Enumerable;
using Veho.Sequence;
using RGB = System.ValueTuple<byte, byte, byte>;
using HSL = System.ValueTuple<float, float, float>;
using POLAR = System.ValueTuple<double, double>;
using HEX_RGB = System.ValueTuple<string, System.ValueTuple<byte, byte, byte>>;
using HEX_HSL = System.ValueTuple<string, System.ValueTuple<float, float, float>>;
using HEX_POLAR = System.ValueTuple<string, System.ValueTuple<double, double>>;

namespace Palett {
  public class Cuvette {
    public Dictionary<string, string> Dict;
    private List<(string key, string val)> _list = null;
    private List<HEX_RGB> _hexToRgb = null;
    private List<HEX_HSL> _hexToHsl = null;
    private List<HEX_POLAR> _hexToPolar = null;
    public static Cuvette Build(Dictionary<string, string> raw) => new Cuvette { Dict = raw };
    public string this[string key] => this.Dict[key];
    public List<(string key, string val)> List => _list != null && _list.Any()
      ? _list
      : _list = Dict.Select(kv => (kv.Key, kv.Value)).ToList();
    public List<(string hex, (byte r, byte g, byte b) rgb)> HexToRgb => _hexToRgb != null && _hexToRgb.Any()
      ? _hexToRgb
      : _hexToRgb = Dict.Map(kv => (kv.Key, Conv.HexToRgb(kv.Key))).ToList();
    public List<(string hex, (float h, float s, float l) hsl)> HexToHsl => _hexToHsl != null && _hexToHsl.Any()
      ? _hexToHsl
      : _hexToHsl = HexToRgb.Map(kv => (kv.hex, kv.rgb.RgbToHsl())).ToList();
    public List<(string hex, (double r, double θ) polar)> HexToPolar => _hexToPolar != null && _hexToPolar.Any()
      ? _hexToPolar
      : _hexToPolar = HexToHsl.Map(kv => (kv.hex, kv.hsl.HslToPolar())).ToList();

    public (string hex, string name) Nearest(HSL hsl) {
      var (hex, _) = this.HexToHsl.MinBy(kv => Munsell.Distance(hsl, kv.hsl));
      return (hex, this[hex]);
    }
    public (string hex, string name) Nearest(POLAR polar, float s) {
      var hsl = polar.PolarToHsl(s);
      var (hex, _) = this.HexToHsl.MinBy(kv => Munsell.Distance(hsl, kv.hsl));
      return (hex, this[hex]);
    }
  }

  public static partial class Munsell {
    private static Cuvette _fashion = null;
    private static Cuvette _product = null;
    private static Cuvette SelectCuvette(Domain domain) {
      switch (domain) {
        case Domain.Fashion: return _fashion ?? (_fashion = Cuvette.Build(Domain.Fashion.ToPalett()));
        case Domain.Product: return _product ?? (_product = Cuvette.Build(Domain.Product.ToPalett()));
        default: return new Cuvette();
      }
    }
  }
}