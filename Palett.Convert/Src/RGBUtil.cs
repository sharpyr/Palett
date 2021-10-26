namespace Palett {
  internal static class RGBUtil {
    private const float EPSILON = (float)0.001;

    public static float Hue(float r, float g, float b, float dif, int pos) {
      switch (pos) {
        case 1:  return ((g - b) / dif + (g < b ? 6 : 0)) % 6;
        case 2:  return (b - r) / dif + 2;
        case 3:  return (r - g) / dif + 4;
        default: return 0;
      }
    }
    public static (float sum, float dif, int pos) Interim(float r, float g, float b) {
      var (max, min, pos) = (r, r, 1);
      if (g > r) { (max, pos) = (g, 2); }
      else { min = g; }
      if (b > max) { (max, pos) = (b, 3); }
      if (b < min) { min = b; }
      float sum = max + min, dif = max - min;
      return (sum, dif, dif < EPSILON ? 0 : pos);
    }
  }
}