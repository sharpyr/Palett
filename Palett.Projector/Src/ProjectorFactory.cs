using Palett.Types;
using Veho.Tuple;
using HSL = System.ValueTuple<float, float, float>;

namespace Palett {
  public static class ProjectorFactory {
    public static Projector Build<T>((T min, T max) bound, Preset preset, params Effect[] effects) {
      return ProjectorFactory.Build(bound.Map(Typen.Conv.Cast<T, double>), preset, effects);
    }
    public static Projector Build((double min, double max)? bound, Preset preset, params Effect[] effects) =>
      ProjectorFactory.Build(bound ?? (default, default), preset, effects);

    public static Projector Build((double min, double max) bound, Preset preset, params Effect[] effects) {
      var max = HSB.FromTuple(Conv.HexToHsl(preset.Max));
      var min = HSB.FromTuple(Conv.HexToHsl(preset.Min));
      return new Projector(bound, (min, max), effects) { Na = Conv.HexToHsl(preset.Na) };
    }

    public static Projector Build((double min, double max) bound, (HSL min, HSL max) preset, params Effect[] effects) {
      var max = HSB.FromTuple(preset.max);
      var min = HSB.FromTuple(preset.min);
      return new Projector(bound, (min, max), effects);
    }
  }
}