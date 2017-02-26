using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeometryTool;
using GeometryTool.CanvasDetail;

namespace GeometryTool.Tests {
  [TestClass]
  public class CanvasTest {
    [TestMethod]
    public void CanvasTestOffset () {
      Context context = new Context(200, 200);
      Assert.AreEqual<double>(-100, context.left_corner.x);
      Assert.AreEqual<double>(100, context.left_corner.y);
    }

    [TestMethod]
    public void CanvasTest_ToScreen_origin () {
      Context context = new Context(200, 200);
      var p1 = context.ToScreen(new Core.Coord2d(0, 0));
      Assert.AreEqual<int>(100, p1.X);
      Assert.AreEqual<int>(100, p1.Y);
    }

    [TestMethod]
    public void CanvasTest_ToScreen_positive_coord () {
      Context context = new Context(200, 200);
      var p2 = context.ToScreen(new Core.Coord2d(10, 10));
      Assert.AreEqual<int>(110, p2.X);
      Assert.AreEqual<int>(90, p2.Y);
    }

    [TestMethod]
    public void CanvasTest_ToScreen_negative_coord () {
      Context context = new Context(200, 200);
      var p2 = context.ToScreen(new Core.Coord2d(-10, -10));
      Assert.AreEqual<int>(90, p2.X);
      Assert.AreEqual<int>(110, p2.Y);
    }

    [TestMethod]
    public void CanvasTest_ToLocal_origin () {
      Context context = new Context(200, 200);
      var p2 = context.ToLocal(new System.Drawing.Point(100, 100));
      Assert.AreEqual<double>(0, p2.x);
      Assert.AreEqual<double>(0, p2.y);
      Assert.AreEqual<double>(-100, context.left_corner.x);
      Assert.AreEqual<double>(100, context.left_corner.y);
    }

    [TestMethod]
    public void CanvasTest_ToLocal_negative () {
      Context context = new Context(200, 200);
      var p2 = context.ToLocal(new System.Drawing.Point(90, 110));
      Assert.AreEqual<double>(-10, p2.x);
      Assert.AreEqual<double>(-10, p2.y);
    }

    [TestMethod]
    public void CanvasTest_ToLocal_positive () {
      Context context = new Context(200, 200);
      var p2 = context.ToLocal(new System.Drawing.Point(110, 90));
      Assert.AreEqual<double>(10, p2.x);
      Assert.AreEqual<double>(10, p2.y);
    }
  }
}
