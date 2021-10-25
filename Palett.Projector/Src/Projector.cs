using System;
using Palett.Dye;
using Palett.Types;
using static Aryth.Math;

namespace Palett {
  public class Projector {
    private readonly double floor;
    private readonly HSB basis;
    private readonly HSB lever;
    private readonly Dye<(float h, float s, float l)> factory;
    public (float h, float s, float l) Na { get; set; } = (0, 0, 0);

    public Projector((double min, double max) bound, (HSB min, HSB max) preset, params Effect[] effects) {
      // Console.WriteLine($">> [preset] ({preset.min}, {preset.max})");
      this.floor = bound.min;
      this.lever = (preset.max - preset.min) / (float)(bound.max - bound.min);
      this.basis = preset.min;
      this.factory = DyeFactory.Hsl(effects);
    }

    public string Render(double num, string text) => this.factory.Render(this.Project(num), text);
    public Func<string, string> Make(double num) => this.factory.Make(this.Project(num));
    public (float h, float s, float l) Project(double value) {
      return double.IsNaN(value) ?
        this.Na :
        (
          Restrict(Projector.Scale(value, this.floor, this.lever.H, this.basis.H), 360),
          Limit(Projector.Scale(value, this.floor, this.lever.S, this.basis.S), 100),
          Limit(Projector.Scale(value, this.floor, this.lever.B, this.basis.B), 100)
        );
    }

    public Func<string, string> MakeDefault() => this.factory.Make(this.Na);

    private static float Scale(double value, double floor, double lever, float basis) {
      return (float)(basis + (value - floor) * lever);
    }
  }
}