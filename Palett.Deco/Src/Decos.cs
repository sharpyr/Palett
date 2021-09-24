using System.Collections.Generic;
using Palett.Dye;
using Veho;
using Veho.Vector;
using Spare.Padder;
using Texting.Enums;
using Texting.Joiner;
using Texting.Slices;

namespace Palett {
  public static class Decos {
    public static readonly Dye<string> HexDye = DyeFactory.Hex();
    public static readonly Dye<(byte, byte, byte)> RgbDye = DyeFactory.Rgb();
    public static readonly Dye<(float, float, float)> HslDye = DyeFactory.Hsl();

    public static string Deco(string hex) {
      var (r, g, b) = Conv.HexToRgb(hex);
      var txR = RgbDye.Render((r, (byte)(r * g / 255), (byte)(r * b / 255)), $"{hex.Slice(1, 2)}");
      var txG = RgbDye.Render(((byte)(g * r / 255), g, (byte)(g * b / 255)), $"{hex.Slice(3, 2)}");
      var txB = RgbDye.Render(((byte)(b * r / 255), (byte)(b * g / 255), b), $"{hex.Slice(5, 2)}");
      return "#" + txR + txG + txB;
    }
    public static string Deco(this (byte r, byte g, byte b) rgb, bool dye = true) {
      var (r, g, b) = rgb;
      var text = $"({r:000},{g:000},{b:000})";
      return dye ? RgbDye.Render(rgb, text) : text;
    }
    public static string Deco(this (float h, float s, float l) hsl, bool dye = true) {
      var (h, s, l) = hsl;
      var text = $"({h:000},{s:000},{l:000})";
      return dye ? HslDye.Render(hsl, text) : text;
      // var txH = HslDye.Render((h, 75, 50), $"{h:000}");
      // var txS = HslDye.Render((h, 0, s), $"{s:000}");
      // var txL = HslDye.Render((h, s, l), $"{l:000}");
      // return "(" + txH + " " + txS + " " + txL + ")";
    }
    public static string DecoPalett(this IReadOnlyList<(string hex, string name)> palett) {
      var (hexes, names) = palett.Unwind();
      Vec.MutaZip(ref names, hexes, (name, hex) => HexDye.Render(hex, name));
      names = names.RPadder(true);
      var textEntries = hexes.Zip(names, (hex, name) => Decos.Deco(hex) + ": " + name + ", " + Conv.HexToHsl(hex).Deco());
      return textEntries.ContingentLines(delim: Strings.COLF, level: 1, Brac.BRK);
    }
  }
}