using System;
using System.Drawing;

namespace Palett.Fluos.Utils {
  public static class ProjectorMapperFactory {
    public static Func<double, Color> ColorMapper(Projector projectorX) =>
      x => double.IsNaN(x) ? Color.Empty : projectorX.Project(x).HslToColor();
    public static Func<double, string, string> RenderMapper(Projector projectorX) =>
      projectorX.Render;
    public static Func<double, Func<string, string>> MakerMapper(Projector projectorX) =>
      x => double.IsNaN(x) ? projectorX.MakeDefault() : projectorX.Make(x);
  }
}