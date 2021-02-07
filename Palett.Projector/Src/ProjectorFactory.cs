using System;
using Palett.Convert;
using Palett.Dye;
using Palett.Projector.Utils;
using Palett.Types;
using Typen;
using Veho.Tuple;
using HSL = System.ValueTuple<float, float, float>;

namespace Palett.Projector {
  public class ProjectorFactory {
    public double Floor;
    public HSL Lever;
    public HSL Basis;
    public DyeFactory<HSL> Factory;
    public HSL Default;
    public bool Spaceless;
    public static ProjectorFactory Build<T>((T min, T max)? bound, Preset preset, params Effect[] effects) =>
      Build(bound ?? (default, default), preset, effects);

    public static ProjectorFactory Build<T>((T min, T max) bound, Preset preset, params Effect[] effects) {
      var colorLeap = preset.PresetToLeap();
      var (min, max) = bound.Map(Conv.Cast<T, double>);
      var dif = max - min;
      return new ProjectorFactory {
        Floor = min,
        Lever = colorLeap.dif.Div((float) dif),
        Basis = colorLeap.min,
        Factory = DyeFactory.Hsl(effects),
        Default = Converter.HexToHsl(preset.Na),
        Spaceless = dif == 0
      };
    }

    public string Render(double num, string text) => this.Factory.Render(this.Project(num), text);
    public Func<string, string> Make(double num) => this.Factory.Make(this.Project(num));

    public string Render<T>(T num, string text) => this.Factory.Render(this.Project(num.Cast<T, double>()), text);
    public Func<string, string> Make<T>(T num) => this.Factory.Make(this.Project(num.Cast<T, double>()));

    public HSL Project(double num) {
      if (double.IsNaN(num)) return this.Default;
      if (Spaceless) return this.Basis;
      var floor = this.Floor;
      var (leverH, leverS, leverL) = this.Lever;
      var (basisH, basisS, basisL) = this.Basis;
      return (
        Util.Scale(num, floor, leverH, basisH, 360),
        Util.Scale(num, floor, leverS, basisS, 100),
        Util.Scale(num, floor, leverL, basisL, 100)
      );
    }

    public HSL Project<T>(T num) => this.Project(num.Cast<T, double>());

    public Func<string, string> MakeDefault() => this.Factory.Make(this.Default);
  }
}