using System;
using Analys;
using Aryth;
using Palett.Types;
using Veho;
using static System.Math;
using static Aryth.Math;
using HSL = System.ValueTuple<float, float, float>;

namespace Palett {
  public class HSBGrad {
    public HSB Basis;
    public HSB Delta;
    public HSBGrad(HSB basis, HSB delta) {
      this.Basis = basis;
      this.Delta = delta;
    }

    public float GradH(int i) => Restrict(this.Basis.H + i * this.Delta.H, 360);
    public float GradS(int i) => Limit(this.Basis.S + i * this.Delta.S, 100);
    public float GradB(int i) => Limit(this.Basis.B + i * this.Delta.B, 100);

    public Func<int, float> MakeGrad(HSLAttr attr) {
      switch (attr) {
        case HSLAttr.H: return this.GradH;
        case HSLAttr.S: return this.GradS;
        case HSLAttr.L: return this.GradB;
        default:        return null;
      }
    }
  }

  public static class HSBGrad2D {
    public static Func<int, int, (float, float, float)> MakeGrad(this (HSBGrad gradX, HSBGrad gradY) gradPair, HSLAttr attrX, HSLAttr attrY) {
      var (gradX, gradY) = gradPair;
      Func<int, int, float> fnH = null, fnS = null, fnB = null;
      switch (attrX) {
        case HSLAttr.H:
          fnH = (x, y) => gradX.GradH(x);
          break;
        case HSLAttr.S:
          fnS = (x, y) => gradX.GradS(x);
          break;
        case HSLAttr.L:
          fnB = (x, y) => gradX.GradB(x);
          break;
      }
      switch (attrY) {
        case HSLAttr.H:
          fnH = (x, y) => gradY.GradH(y);
          break;
        case HSLAttr.S:
          fnS = (x, y) => gradY.GradS(y);
          break;
        case HSLAttr.L:
          fnB = (x, y) => gradY.GradB(y);
          break;
      }
      // Console.WriteLine($">> (x, y) = ({x}, {y}) [grad] (x, y) = ({gradX.GradH(x)}, {gradY.GradH(y)})");
      if (fnH == null) fnH = (x, y) => (float)Sqrt(gradX.GradH(x) * gradY.GradH(y));
      if (fnS == null) fnS = (x, y) => (float)Sqrt(gradX.GradS(x) * gradY.GradS(y));
      if (fnB == null) fnB = (x, y) => (float)Sqrt(gradX.GradB(x) * gradY.GradB(y));
      return (x, y) => (fnH(x, y), fnS(x, y), fnB(x, y));
    }
  }

  public partial class Munsell {
    public static Crostab<HSL> GradientCrostab(
      this ((float, float, float) a, (float, float, float) b) hslPair,
      HSLAttr attrX, HSLAttr attrY,
      int lenX, int lenY
    ) {
      var hsbA = HSB.FromTuple(hslPair.a);
      var hsbB = HSB.FromTuple(hslPair.b);
      var delta = hsbB - hsbA;

      var gradX = new HSBGrad(hsbA, delta / (lenX - 1));
      var gradY = new HSBGrad(hsbA, delta / (lenY - 1));

      var fnSide = gradX.MakeGrad(attrX);
      var fnHead = gradY.MakeGrad(attrY);
      var fnRows = (gradX, gradY).MakeGrad(attrX, attrY);

      var side = Vec.Init(lenX, x => fnSide(x).ToString("F1"));
      var head = Vec.Init(lenY, y => fnHead(y).ToString("F1"));
      var rows = Mat.Init((lenX, lenY), fnRows);

      return Crostab<HSL>.Build(side, head, rows);
    }
  }
}