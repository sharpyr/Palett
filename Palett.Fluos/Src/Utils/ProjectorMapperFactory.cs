using System;
using System.Drawing;
using Palett.Projector;

namespace Palett.Fluos.Utils {
  public static class ProjectorMapperFactory {
    public static Func<double, Color?> ColorMapper(ProjectorFactory facX) =>
      x => double.IsNaN(x) ? null : (Color?) facX.Project(x).HslToColor();
    public static Func<double, string, string> RenderMapper(ProjectorFactory facX) =>
      facX.Render;
    public static Func<double, Func<string, string>> MakerMapper(ProjectorFactory facX) =>
      x => double.IsNaN(x) ? facX.MakeDefault() : facX.Make(x);
  }
}