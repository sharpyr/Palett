using System.Collections.Generic;

namespace Palett {
  public enum Domain {
    Fashion = 1,
    Product = 2,
  }

  public static class DomainUtil {
    public static Dictionary<string, string> ToPalett(this Domain domain) {
      switch (domain) {
        case Domain.Fashion: return Pavtone.Fashions;
        case Domain.Product: return Pavtone.Products;
        default: return new Dictionary<string, string>();
      }
    }
  }
}