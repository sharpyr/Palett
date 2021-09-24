using System;
using Analys;
using Palett.Types;
using Veho;
using static System.Math;
using HSL = System.ValueTuple<float, float, float>;

namespace Palett {
  public partial class Munsell {
    public static Crostab<HSL> GradientCrostab(
      this ((float, float, float) aHSL, (float, float, float) bHSL) hslPair,
      HSLDimension xDm, HSLDimension yDm,
      int xCn, int yCn
    ) {
      var ((aH, aS, aL), (bH, bS, bL)) = hslPair;
      var xdH = (bH - aH) / (xCn - 1);
      var xdS = (bS - aS) / (xCn - 1);
      var xdL = (bL - aL) / (xCn - 1);
      var ydH = (bH - aH) / (yCn - 1);
      var ydS = (bS - aS) / (yCn - 1);
      var ydL = (bL - aL) / (yCn - 1);

      var fnX =
        xDm == HSLDimension.H ? x => aH + x * xdH :
        xDm == HSLDimension.S ? x => aS + x * xdS :
        (Func<int, float>)(x => aL + x * xdL);
      var fnY =
        yDm == HSLDimension.H ? y => aH + y * ydH :
        yDm == HSLDimension.S ? y => aS + y * ydS :
        (Func<int, float>)(y => aL + y * ydL);

      var fnH =
        xDm == HSLDimension.H ? (x, y) => aH + x * xdH :
        yDm == HSLDimension.H ? (x, y) => aH + y * ydH :
        (Func<int, int, float>)((x, y) => (float)Sqrt((aH + x * xdH) * (aH + y * ydH)));

      var fnS =
        xDm == HSLDimension.S ? (x, y) => aS + x * xdS :
        yDm == HSLDimension.S ? (x, y) => aS + y * ydS :
        (Func<int, int, float>)((x, y) => (float)Sqrt((aS + x * xdS) * (aS + y * ydS)));

      var fnL =
        xDm == HSLDimension.L ? (x, y) => aL + x * xdL :
        yDm == HSLDimension.L ? (x, y) => aL + y * ydL :
        (Func<int, int, float>)((x, y) => (float)Sqrt((aL + x * xdL) * (aL + y * ydL)));

      var side = Vec.Init(xCn, x => fnX(x).ToString("F1"));
      var head = Vec.Init(yCn, y => fnY(y).ToString("F1"));
      var rows = (xCn, yCn).Init((x, y) => (fnH(x, y), fnS(x, y), fnL(x, y)));

      return Crostab<HSL>.Build(side, head, rows);
    }
  }
}