using System;
using Palett.Projector;

namespace Palett.Fluos.Utils {
  public static class ZipperFactory {
    public static Func<double, double, string, string> RenderZipper(ProjectorFactory facX, ProjectorFactory facY) =>
      (x, y, tx) => {
        if (!double.IsNaN(x)) return facX.Render(x, tx);
        if (!double.IsNaN(y)) return facY.Render(y, tx);
        return facX.Render(double.NaN, tx);
      };

    public static Func<double, double, Func<string, string>> MakerZipper(ProjectorFactory facX, ProjectorFactory facY) =>
      (x, y) => {
        if (!double.IsNaN(x)) return facX.Make(x);
        if (!double.IsNaN(y)) return facY.Make(y);
        return facX.MakeDefault();
      };
  }
}