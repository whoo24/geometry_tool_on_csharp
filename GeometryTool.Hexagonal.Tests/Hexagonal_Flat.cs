using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeometryTool.Hexagonal.Tests {
  [TestClass]
  public class Hexagonal_Flat {
    [TestMethod]
    public void TestLayout_Flat () {
      Hex h = new Hex(3, 4, -7);
      Layout flat = new Layout(Layout.flat, new Point(10, 15), new Point(35, 71));
      Assert.IsTrue(Hex.Equals(h, FractionalHex.HexRound(Layout.PixelToHex(flat, Layout.HexToPixel(flat, h)))));
    }
  }
}