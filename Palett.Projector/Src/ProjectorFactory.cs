using System;
using Palett.Convert;
using Palett.Dye;
using Palett.Projector.Utils;
using Palett.Utils.Types;
using HSL = System.ValueTuple<float, float, float>;

namespace Palett.Projector {
  public class ProjectorFactory {
    public float Floor;
    public HSL Lever;
    public HSL Basis;
    public DyeFactory<HSL> Factory;
    public HSL Default;

    public static ProjectorFactory Build((float min, float max) bound, Preset preset, params Effect[] effects) {
      var colorLeap = preset.PresetToLeap();
      return new ProjectorFactory {
        Floor = bound.min,
        Lever = colorLeap.dif.Div(bound.max - bound.min),
        Basis = colorLeap.min,
        Factory = DyeFactory.Hsl(effects),
        Default = Converter.HexToHsl(preset.Na)
      };
    }

    public HSL Project(float val) {
      if (float.IsNaN(val)) { return this.Default; }
      var floor = this.Floor;
      var (leverH, leverS, leverL) = this.Lever;
      var (baseH, baseS, baseL) = this.Basis;
      return (
        Util.Scale(val, floor, leverH, baseH, 360),
        Util.Scale(val, floor, leverS, baseS, 100),
        Util.Scale(val, floor, leverL, baseL, 100)
      );
    }

    public string Render(float value, string text) => this.Factory.Render(this.Project(value), text);

    public Func<string, string> Make(float value) => this.Factory.Make(this.Project(value));

    public Func<string, string> MakeDefault() => this.Factory.Make(this.Default);
  }
}