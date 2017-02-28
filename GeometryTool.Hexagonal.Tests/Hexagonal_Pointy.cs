using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeometryTool.Hexagonal.Tests {
  [TestClass]
  public class Hexagonal_Pointy {
    [TestMethod]
    public void TestLayout_Pointy () {
      Layout pointy = new Layout(Layout.pointy_, new Point(10, 15), new Point(35, 71));
      Assert.AreEqual(new Hex(3, 4, -7), FractionalHex.HexRound(Layout.PixelToHex(pointy, Layout.HexToPixel(pointy, new Hex(3, 4, -7)))));
    }

    [TestMethod]
    public void TestLayout_Pointy_0_0 () {
      Layout pointy = new Layout(Layout.pointy_, new Point(60, 70), new Point(0, 0));
      Assert.AreEqual(new Hex(0, 0, 0), FractionalHex.HexRound(Layout.PixelToHex(pointy, Layout.HexToPixel(pointy, new Hex(0, 0, 0)))));
    }

    [TestMethod]
    public void TestLayout_Pointy_HexToPixel_1_0 () {
      Layout pointy = new Layout(Layout.pointy_, new Point(60, 70), new Point(0, 0));
      var p = Layout.HexToPixel(pointy, new Hex(1, 0, -1));
      Assert.AreEqual(120, p.x);
      Assert.AreEqual(0, p.y);
    }

    [TestMethod]
    public void TestLayout_Pointy_HexToPixel_0_1 () {
      Layout pointy = new Layout(Layout.pointy_, Layout.MakeSize(120, 140), new Point(0, 0));
      var p = Layout.HexToPixel(pointy, new Hex(0, 1, -1));
      Assert.AreEqual(60, p.x);
      Assert.AreEqual(-105, p.y);
    }

    [TestMethod]
    public void TestLayout_Pointy_HexToPixel_1_1 () {
      Layout pointy = new Layout(Layout.pointy_, new Point(60, 70), new Point(0, 0));
      var p = Layout.HexToPixel(pointy, new Hex(1, 1, -2));
      Assert.AreEqual(180, p.x);
      Assert.AreEqual(-105, p.y);
    }

    [TestMethod]
    public void TestLayout_Pointy_PixelToHex_0_0 () {
      Layout pointy = new Layout(Layout.pointy_, new Point(60, 70), new Point(0, 0));
      var fhex = Layout.PixelToHex(pointy, new Point(0, 0));
      Assert.AreEqual(new FractionalHex(0, 0, 0), fhex);
    }

    [TestMethod]
    public void TestLayout_Pointy_PixelToHex_1_0 () {
      Layout pointy = new Layout(Layout.pointy_, new Point(60, 70), new Point(0, 0));
      var fhex = Layout.PixelToHex(pointy, new Point(60, 0));
      Assert.AreEqual(new FractionalHex(0.5, 0, -0.5), fhex);
    }

    [TestMethod]
    public void TestLayout_Pointy_PixelToHex_2_0 () {
      Layout pointy = new Layout(Layout.pointy_, new Point(60, 70), new Point(0, 0));
      var fhex = Layout.PixelToHex(pointy, new Point(120, 0));
      Assert.AreEqual(new FractionalHex(1.0, 0, -1.0), fhex);
    }

    [TestMethod]
    public void TestLayout_Pointy_PixelToHex_3_0 () {
      Layout pointy = new Layout(Layout.pointy_, new Point(60, 70), new Point(0, 0));
      var fhex = Layout.PixelToHex(pointy, new Point(180, 0));
      Assert.AreEqual(new FractionalHex(1.5, 0, -1.5), fhex);
    }

    [TestMethod]
    public void TestLayout_Pointy_1_1 () {
      Layout pointy = new Layout(Layout.pointy_, new Point(60, 70), new Point(0, 0));
      var p = Layout.HexToPixel(pointy, new Hex(1, 1, -2));
      var candidated = Layout.PixelToHex(pointy, p);
      var rounded = FractionalHex.HexRound(candidated);
      Assert.AreEqual(new Hex(1, 1, -2), rounded);
    }
  }
}