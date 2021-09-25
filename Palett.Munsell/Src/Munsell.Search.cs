using System.Collections.Generic;
using System.Text.RegularExpressions;
using Veho.Sequence;
using RGB = System.ValueTuple<byte, byte, byte>;
using HSL = System.ValueTuple<float, float, float>;
using POLAR = System.ValueTuple<double, double>;
using HEX_RGB = System.ValueTuple<string, System.ValueTuple<byte, byte, byte>>;
using HEX_HSL = System.ValueTuple<string, System.ValueTuple<float, float, float>>;
using HEX_POLAR = System.ValueTuple<string, System.ValueTuple<double, double>>;

namespace Palett {
  public static partial class Munsell {
    public static (string hex, string name) Nearest(this HSL hsl, Domain domain = Domain.Fashion) {
      var cuvette = Munsell.SelectCuvette(domain);
      var (hex, _) = cuvette.HexToHsl.MinBy(kv => Distance(hsl, kv.hsl));
      return (hex, cuvette[hex]);
    }
    public static List<(string hex, string name)> Search(string name, Domain domain = Domain.Fashion) {
      var regex = new Regex(name, RegexOptions.IgnoreCase);
      var cuvette = Munsell.SelectCuvette(domain);
      return cuvette.List
                    .FindAll(kv => regex.IsMatch(kv.val));
    }
  }
}