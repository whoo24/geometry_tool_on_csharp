using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeometryTool.Core;
using System.Collections.Generic;

namespace GeometryTool.Hexagonal.Tests {
  [TestClass]
  public class HexagonalTile {

    [TestClass]
    public class Tests {


      static public bool EqualHex (String name, Hex a, Hex b) {
        if (!(a.q == b.q && a.s == b.s && a.r == b.r)) {
          Tests.Complain(name);
          return false;
        }
        return true;
      }


      static public bool EqualOffsetcoord (String name, OffsetCoord a, OffsetCoord b) {
        if (!(a.col == b.col && a.row == b.row)) {
          Tests.Complain(name);
          return false;
        }
        return true;
      }


      static public bool EqualInt (String name, int a, int b) {
        if (!(a == b)) {
          Tests.Complain(name);
          return false;
        }
        return true;
      }


      static public bool EqualHexArray (String name, List<Hex> a, List<Hex> b) {
        if (!Tests.EqualInt(name, a.Count, b.Count)) {
          return false;
        }
        for (int i = 0; i < a.Count; i++) {
          if (!Tests.EqualHex(name, a[i], b[i])) {
            return false;
          }
        }
        return true;
      }


      static public void TestHexArithmetic () {
        Assert.IsTrue(Tests.EqualHex("hex_add", new Hex(4, -10, 6), Hex.Add(new Hex(1, -3, 2), new Hex(3, -7, 4))));
        Assert.IsTrue(Tests.EqualHex("hex_subtract", new Hex(-2, 4, -2), Hex.Subtract(new Hex(1, -3, 2), new Hex(3, -7, 4))));
      }


      static public void TestHexDirection () {
        Assert.IsTrue(Tests.EqualHex("hex_direction", new Hex(0, -1, 1), Hex.Direction(2)));
      }


      static public void TestHexNeighbor () {
        Assert.IsTrue(Tests.EqualHex("hex_neighbor", new Hex(1, -3, 2), Hex.Neighbor(new Hex(1, -2, 1), 2)));
      }


      static public void TestHexDiagonal () {
        Assert.IsTrue(Tests.EqualHex("hex_diagonal", new Hex(-1, -1, 2), Hex.DiagonalNeighbor(new Hex(1, -2, 1), 3)));
      }


      static public void TestHexDistance () {
        Assert.IsTrue(Tests.EqualInt("hex_distance", 7, Hex.Distance(new Hex(3, -7, 4), new Hex(0, 0, 0))));
      }


      static public void TestHexRound () {
        FractionalHex a = new FractionalHex(0, 0, 0);
        FractionalHex b = new FractionalHex(1, -1, 0);
        FractionalHex c = new FractionalHex(0, -1, 1);
        Assert.IsTrue(Tests.EqualHex("hex_round 1", new Hex(5, -10, 5), FractionalHex.HexRound(FractionalHex.HexLerp(new FractionalHex(0, 0, 0), new FractionalHex(10, -20, 10), 0.5))));
        Assert.IsTrue(Tests.EqualHex("hex_round 2", FractionalHex.HexRound(a), FractionalHex.HexRound(FractionalHex.HexLerp(a, b, 0.499))));
        Assert.IsTrue(Tests.EqualHex("hex_round 3", FractionalHex.HexRound(b), FractionalHex.HexRound(FractionalHex.HexLerp(a, b, 0.501))));
        Assert.IsTrue(Tests.EqualHex("hex_round 4", FractionalHex.HexRound(a), FractionalHex.HexRound(new FractionalHex(a.q * 0.4 + b.q * 0.3 + c.q * 0.3, a.r * 0.4 + b.r * 0.3 + c.r * 0.3, a.s * 0.4 + b.s * 0.3 + c.s * 0.3))));
        Assert.IsTrue(Tests.EqualHex("hex_round 5", FractionalHex.HexRound(c), FractionalHex.HexRound(new FractionalHex(a.q * 0.3 + b.q * 0.3 + c.q * 0.4, a.r * 0.3 + b.r * 0.3 + c.r * 0.4, a.s * 0.3 + b.s * 0.3 + c.s * 0.4))));
      }


      static public void TestHexLinedraw () {
        Assert.IsTrue(Tests.EqualHexArray("hex_linedraw", new List<Hex> { new Hex(0, 0, 0), new Hex(0, -1, 1), new Hex(0, -2, 2), new Hex(1, -3, 2), new Hex(1, -4, 3), new Hex(1, -5, 4) }, FractionalHex.HexLinedraw(new Hex(0, 0, 0), new Hex(1, -5, 4))));
      }


      static public void TestLayout () {
        Hex h = new Hex(3, 4, -7);
        Layout flat = new Layout(Layout.flat, new Point(10, 15), new Point(35, 71));
        Assert.IsTrue(Tests.EqualHex("layout", h, FractionalHex.HexRound(Layout.PixelToHex(flat, Layout.HexToPixel(flat, h)))));
        Layout pointy = new Layout(Layout.pointy, new Point(10, 15), new Point(35, 71));
        Assert.IsTrue(Tests.EqualHex("layout", h, FractionalHex.HexRound(Layout.PixelToHex(pointy, Layout.HexToPixel(pointy, h)))));
      }


      static public void TestConversionRoundtrip () {
        Hex a = new Hex(3, 4, -7);
        OffsetCoord b = new OffsetCoord(1, -3);
        Assert.IsTrue(Tests.EqualHex("conversion_roundtrip even-q", a, OffsetCoord.QoffsetToCube(OffsetCoord.EVEN, OffsetCoord.QoffsetFromCube(OffsetCoord.EVEN, a))));
        Assert.IsTrue(Tests.EqualOffsetcoord("conversion_roundtrip even-q", b, OffsetCoord.QoffsetFromCube(OffsetCoord.EVEN, OffsetCoord.QoffsetToCube(OffsetCoord.EVEN, b))));
        Assert.IsTrue(Tests.EqualHex("conversion_roundtrip odd-q", a, OffsetCoord.QoffsetToCube(OffsetCoord.ODD, OffsetCoord.QoffsetFromCube(OffsetCoord.ODD, a))));
        Assert.IsTrue(Tests.EqualOffsetcoord("conversion_roundtrip odd-q", b, OffsetCoord.QoffsetFromCube(OffsetCoord.ODD, OffsetCoord.QoffsetToCube(OffsetCoord.ODD, b))));
        Assert.IsTrue(Tests.EqualHex("conversion_roundtrip even-r", a, OffsetCoord.RoffsetToCube(OffsetCoord.EVEN, OffsetCoord.RoffsetFromCube(OffsetCoord.EVEN, a))));
        Assert.IsTrue(Tests.EqualOffsetcoord("conversion_roundtrip even-r", b, OffsetCoord.RoffsetFromCube(OffsetCoord.EVEN, OffsetCoord.RoffsetToCube(OffsetCoord.EVEN, b))));
        Assert.IsTrue(Tests.EqualHex("conversion_roundtrip odd-r", a, OffsetCoord.RoffsetToCube(OffsetCoord.ODD, OffsetCoord.RoffsetFromCube(OffsetCoord.ODD, a))));
        Assert.IsTrue(Tests.EqualOffsetcoord("conversion_roundtrip odd-r", b, OffsetCoord.RoffsetFromCube(OffsetCoord.ODD, OffsetCoord.RoffsetToCube(OffsetCoord.ODD, b))));
      }


      static public void TestOffsetFromCube () {
        Assert.IsTrue(Tests.EqualOffsetcoord("offset_from_cube even-q", new OffsetCoord(1, 3), OffsetCoord.QoffsetFromCube(OffsetCoord.EVEN, new Hex(1, 2, -3))));
        Assert.IsTrue(Tests.EqualOffsetcoord("offset_from_cube odd-q", new OffsetCoord(1, 2), OffsetCoord.QoffsetFromCube(OffsetCoord.ODD, new Hex(1, 2, -3))));
      }


      static public void TestOffsetToCube () {
        Assert.IsTrue(Tests.EqualHex("offset_to_cube even-", new Hex(1, 2, -3), OffsetCoord.QoffsetToCube(OffsetCoord.EVEN, new OffsetCoord(1, 3))));
        Assert.IsTrue(Tests.EqualHex("offset_to_cube odd-q", new Hex(1, 2, -3), OffsetCoord.QoffsetToCube(OffsetCoord.ODD, new OffsetCoord(1, 2))));
      }


      [TestMethod]
      public void TestAll () {
        Tests.TestHexArithmetic();
        Tests.TestHexDirection();
        Tests.TestHexNeighbor();
        Tests.TestHexDiagonal();
        Tests.TestHexDistance();
        Tests.TestHexRound();
        Tests.TestHexLinedraw();
        Tests.TestLayout();
        Tests.TestConversionRoundtrip();
        Tests.TestOffsetFromCube();
        Tests.TestOffsetToCube();
      }

      [TestMethod]
      public void TestSquare () {
        Rect r = new Rect();
        r.lt = new Coord2d(0, 1);
        r.rt = new Coord2d(1, 1);
        r.lb = new Coord2d(0, 0);
        r.rb = new Coord2d(1, 0);
        /*
        0, 1 -------- 1, 1
             |     / |
             |   /   |
             | /     |
        0, 0 -------- 1, 0
        */
        Coord2d p1 = new Coord2d();
        p1.x = 0.2;
        p1.y = 0.9;

        Assert.AreEqual(r.기울기(), 1);
        Assert.AreEqual(new Coord2d(0.2, 0.9).x, r.FractionContact(p1).x);
        Assert.AreEqual(new Coord2d(0.2, 0.9).y, r.FractionContact(p1).y);
      }

      [TestMethod]
      public void TestRectangle () {
        Rect r = new Rect();
        r.lt = new Coord2d(0, 1);
        r.rt = new Coord2d(4, 1);
        r.lb = new Coord2d(0, 0);
        r.rb = new Coord2d(4, 0);
        /*
        0, 1 ------------------------ 4, 1
             |                    / |
             |           /          |
             | /                    |
        0, 0 ------------------------ 4, 0
        */
        Coord2d p1 = new Coord2d();
        p1.x = 1;
        p1.y = 0.9;

        Assert.AreEqual(0.25, r.기울기());
        Assert.AreEqual(new Coord2d(0.25, 0.9).x, r.FractionContact(p1).x);
        Assert.AreEqual(new Coord2d(0.25, 0.9).y, r.FractionContact(p1).y);
      }


      [TestMethod]
      public void TestRectangleContainsCoord2d() {
        Rect r = new Rect();
        r.lt = new Coord2d(0, 1);
        r.rt = new Coord2d(1, 1);
        r.lb = new Coord2d(1, 0);
        r.rb = new Coord2d(1, 0);

        Assert.IsTrue(r.Contains(new Coord2d(0.5, 0.5)));
        Assert.IsFalse(r.Contains(new Coord2d(1.1, 0.5)));
        Assert.IsFalse(r.Contains(new Coord2d(0.5, 1.1)));
        Assert.IsFalse(r.Contains(new Coord2d(-0.1, 0.5)));
        Assert.IsFalse(r.Contains(new Coord2d(0.5, -0.1)));
        Assert.IsFalse(r.Contains(new Coord2d(-0.1, -0.1)));
        Assert.IsFalse(r.Contains(new Coord2d(1.1, 1.1)));
      }

      [TestMethod]
      public void TestLineSegment () {
        LineSegment s = new LineSegment();
        s.p1 = new Coord2d(0, 0);
        s.p2 = new Coord2d(1, 1);
        Assert.AreEqual(s.기울기(), 1);
      }


      static public void Complain (String name) {
        Console.WriteLine("FAIL " + name);
      }
    }
  }
}