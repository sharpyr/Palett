using System.Drawing;
using Palett.Types;
using HSL = System.ValueTuple<float, float, float>;
using RGB = System.ValueTuple<byte, byte, byte>;

namespace Palett.Dye {
  public static class DyeFactory {
    public static Dye<RGB> Rgb(params Effect[] effects) => Dye<RGB>.Build(AnsiProjector.RgbToAnsi, effects);
    public static Dye<HSL> Hsl(params Effect[] effects) => Dye<HSL>.Build(AnsiProjector.HslToAnsi, effects);
    public static Dye<string> Hex(params Effect[] effects) => Dye<string>.Build(AnsiProjector.HexToAnsi, effects);

    public static Dye<Color> Color(params Effect[] effects) => Dye<Color>.Build(AnsiProjector.ColorToAnsi, effects);
  }
}