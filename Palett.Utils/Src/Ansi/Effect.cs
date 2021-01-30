using System;
using Palett.Types;

namespace Palett.Utils.Ansi {
  public static class EffectCodes {
    public static (string, string) EffectToAnsi(this Effect effect) {
      switch (effect) {
        case Effect.Bold: return (BOLD, CLR_BOLD);
        case Effect.Italic: return (ITALIC, CLR_ITALIC);
        case Effect.Underline: return (UNDERLINE, CLR_UNDERLINE);
        case Effect.Inverse: return (INVERSE, CLR_INVERSE);
        default: throw new ArgumentOutOfRangeException(nameof(effect), effect, null);
      }
    }

    public const string BOLD = "1";
    public const string ITALIC = "3";
    public const string UNDERLINE = "4";
    public const string INVERSE = "7";
    public const string CLR_BOLD = "22";
    public const string CLR_ITALIC = "23";
    public const string CLR_UNDERLINE = "24";
    public const string CLR_INVERSE = "27";
  }
}