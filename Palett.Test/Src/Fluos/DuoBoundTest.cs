using System.Collections.Generic;
using NUnit.Framework;
using Palett.Fluos.Screener;
using Spare;
using Veho.Sequence;

namespace Palett.Test.Fluos {
  [TestFixture]
  public class DuoBoundTest {
    [Test]
    public void VectorDuoboundTest() {
      var candidates = new List<string[]> {
        new[] {"a", "b", "c", null, "1", "2", "3"},
        new[] {"a", "b", "c", null,},
        new[] {"1", "2", "3", null}
      };
      candidates.IterateList(vec => {
        var ((veX, bdX), (veY, bdY)) = vec.DuoBound();
        $"X: [vector] ({veX.Deco()}) [bound] ({bdX})".Logger();
        $"Y: [vector] ({veY.Deco()}) [bound] ({bdY})".Logger();
      });
    }

    [Test]
    public void MatrixDuoboundTest() {
      var candidates = new List<string[,]> {
        new[,] {
          {"a", "b", "c", "1", "2", "3"},
          {"b", "c", "d", "2", "3", "4"},
          {"c", "d", "e", "3", "4", "5"},
          {"d", "e", "f", "4", "5", "6"}
        },
        new[,] {
          {"a", "b", "c"},
          {"b", "c", "d"},
          {"c", "d", "e"},
          {"d", "e", "f"}
        },
        new[,] {
          {"1", "2", "3"},
          {"2", "3", "4"},
          {"3", "4", "5"},
          {"4", "5", "6"}
        },
      };
      candidates.IterateList(vec => {
        var ((veX, bdX), (veY, bdY)) = vec.DuoBound();
        $"X: [vector] ({veX.Deco()}) [bound] ({bdX})".Logger();
        $"Y: [vector] ({veY.Deco()}) [bound] ({bdY})".LogNext();
      });
    }
  }
}