using System.Collections.Generic;
using Palett.Dye;
using Veho.Sequence;

// using Spare;
// using Veho.Sequence;
// using System.Collections.Generic;
// using System.Linq;
// using Palett.Fluos;
// using Palett.Types;
// using Spare.Padder;
// using Texting.Enums;
// using Texting.Joiner;
// using Typen;
// using Veho;
// using Veho.Vector;

namespace Palett {
  public static class Decos {
    public static readonly Dye<string> Dyer = DyeFactory.Hex();
    public static string DecoPalett(this IReadOnlyList<(string hex, string name)> palett) {
      return palett
             .Map(x => {
               return $"\n{x.hex}: {Dyer.Render(x.hex, x.name)} ({Conv.HexToHsl(x.hex)})";
             })
             .ToString();
    }
  }
}