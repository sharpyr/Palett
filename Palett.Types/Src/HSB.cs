using System;
using static Aryth.Pol;

namespace Palett.Types {
  public struct HSB : IEquatable<HSB> {
    public float H;
    public float S;
    public float B;
    public HSB(float h, float s, float b) {
      this.H = h;
      this.S = s;
      this.B = b;
    }
    public static HSB FromTuple((float h, float s, float l) hsl) {
      return new HSB(hsl.h, hsl.s, hsl.l);
    }

    public static HSB operator +(HSB a, HSB b) => new HSB(a.H + b.H, a.S + b.S, a.B + b.B);
    public static HSB operator -(HSB a, HSB b) => new HSB(Minus(a.H, b.H), a.S - b.S, a.B - b.B);
    public static HSB operator *(HSB a, float b) => new HSB(a.H * b, a.S * b, a.B * b);
    public static HSB operator /(HSB a, float b) => new HSB(a.H / b, a.S / b, a.B / b);

    public bool Equals(HSB other) => H.Equals(other.H) && S.Equals(other.S) && B.Equals(other.B);

    public override string ToString() => $"({this.H:000},{this.S:000},{this.B:000})";
  }
}