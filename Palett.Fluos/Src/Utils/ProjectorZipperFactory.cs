using System;
using System.Drawing;

namespace Palett.Fluos.Utils {
  public static class ProjectorZipperFactory {
    public static Func<double, double, Color> ColorZipper(Projector projectorX, Projector projectorY) =>
      (x, y) => {
        if (!double.IsNaN(x)) return projectorX.Project(x).HslToColor();
        if (!double.IsNaN(y)) return projectorY.Project(y).HslToColor();
        return Color.Empty;
      };
    public static Func<double, double, string, string> RenderZipper(Projector projectorX, Projector projectorY) =>
      (x, y, tx) => {
        if (!double.IsNaN(x)) return projectorX.Render(x, tx);
        if (!double.IsNaN(y)) return projectorY.Render(y, tx);
        return projectorX.Render(double.NaN, tx);
      };

    public static Func<double, double, Func<string, string>> MakerZipper(Projector projectorX, Projector projectorY) =>
      (x, y) => {
        if (!double.IsNaN(x)) return projectorX.Make(x);
        if (!double.IsNaN(y)) return projectorY.Make(y);
        return projectorX.MakeDefault();
      };
  }
}