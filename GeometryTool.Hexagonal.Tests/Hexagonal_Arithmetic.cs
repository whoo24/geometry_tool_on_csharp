﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeometryTool.Core;
using System.Collections.Generic;

namespace GeometryTool.Hexagonal.Tests {
  [TestClass]
  public class Hexagonal_Arithmetic {
    public object HexPenGizmo { get; private set; }

    [TestMethod]
    public void TestHexArithmetic_Add () {
      Assert.IsTrue(Hex.Equals(new Hex(4, -10, 6), Hex.Add(new Hex(1, -3, 2), new Hex(3, -7, 4))));
    }

    [TestMethod]
    public void TestHexArithmetic_Subtract () {
      Assert.IsTrue(Hex.Equals(new Hex(-2, 4, -2), Hex.Subtract(new Hex(1, -3, 2), new Hex(3, -7, 4))));
    }

    [TestMethod]
    public void TestHexDirection () {
      Assert.IsTrue(Hex.Equals(new Hex(0, -1, 1), Hex.Direction(2)));
    }

    [TestMethod]
    public void TestHexNeighbor () {
      Assert.IsTrue(Hex.Equals(new Hex(1, -3, 2), Hex.Neighbor(new Hex(1, -2, 1), 2)));
    }

    [TestMethod]
    public void TestHexDiagonal () {
      Assert.IsTrue(Hex.Equals(new Hex(-1, -1, 2), Hex.DiagonalNeighbor(new Hex(1, -2, 1), 3)));
    }

    [TestMethod]
    public void TestHexDistance () {
      Assert.AreEqual(7, Hex.Distance(new Hex(3, -7, 4), new Hex(0, 0, 0)));
    }

    [TestMethod]
    public void TestHexRound_1 () {
      var lerped = FractionalHex.HexLerp(new FractionalHex(0, 0, 0), new FractionalHex(10, -20, 10), 0.5);
      Assert.AreEqual(new Hex(5, -10, 5), FractionalHex.HexRound(lerped));
    }

    [TestMethod]
    public void TestHexRound_2 () {
      var lerped = FractionalHex.HexLerp(new FractionalHex(0, 0, 0), new FractionalHex(1, -1, 0), 0.499);
      Assert.AreEqual(new Hex(0, 0, 0), FractionalHex.HexRound(lerped));
    }

    [TestMethod]
    public void TestHexRound_3 () {
      FractionalHex a = new FractionalHex(0, 0, 0);
      FractionalHex b = new FractionalHex(1, -1, 0);
      FractionalHex c = new FractionalHex(0, -1, 1);
      Assert.AreEqual(FractionalHex.HexRound(b), FractionalHex.HexRound(FractionalHex.HexLerp(a, b, 0.501)));
    }

    [TestMethod]
    public void TestHexRound_4 () {
      FractionalHex a = new FractionalHex(0, 0, 0);
      FractionalHex b = new FractionalHex(1, -1, 0);
      FractionalHex c = new FractionalHex(0, -1, 1);
      Assert.AreEqual(FractionalHex.HexRound(a), FractionalHex.HexRound(new FractionalHex(a.q * 0.4 + b.q * 0.3 + c.q * 0.3, a.r * 0.4 + b.r * 0.3 + c.r * 0.3, a.s * 0.4 + b.s * 0.3 + c.s * 0.3)));
    }

    [TestMethod]
    public void TestHexRound_5 () {
      FractionalHex a = new FractionalHex(0, 0, 0);
      FractionalHex b = new FractionalHex(1, -1, 0);
      FractionalHex c = new FractionalHex(0, -1, 1);
      Assert.AreEqual(FractionalHex.HexRound(c), FractionalHex.HexRound(new FractionalHex(a.q * 0.3 + b.q * 0.3 + c.q * 0.4, a.r * 0.3 + b.r * 0.3 + c.r * 0.4, a.s * 0.3 + b.s * 0.3 + c.s * 0.4)));
    }

    [TestMethod]
    public void TestHexLinedraw () {
      var actually = FractionalHex.HexLinedraw(new Hex(0, 0, 0), new Hex(1, -5, 4));
      Assert.AreEqual(6, actually.Count);
      Assert.IsTrue(Hex.Equals(new Hex(0, 0, 0), actually[0]));
      Assert.IsTrue(Hex.Equals(new Hex(0, -1, 1), actually[1]));
      Assert.IsTrue(Hex.Equals(new Hex(0, -2, 2), actually[2]));
      Assert.IsTrue(Hex.Equals(new Hex(1, -3, 2), actually[3]));
      Assert.IsTrue(Hex.Equals(new Hex(1, -4, 3), actually[4]));
      Assert.IsTrue(Hex.Equals(new Hex(1, -5, 4), actually[5]));
    }

    [TestMethod]
    static public void TestConversionRoundtrip_even_q () {
      Hex a = new Hex(3, 4, -7);
      OffsetCoord b = new OffsetCoord(1, -3);
      Assert.IsTrue(Hex.Equals(a, OffsetCoord.QoffsetToCube(OffsetCoord.EVEN, OffsetCoord.QoffsetFromCube(OffsetCoord.EVEN, a))));
      Assert.IsTrue(OffsetCoord.Equals(b, OffsetCoord.QoffsetFromCube(OffsetCoord.EVEN, OffsetCoord.QoffsetToCube(OffsetCoord.EVEN, b))));
    }

    [TestMethod]
    static public void TestConversionRoundtrip_odd_q () {
      Hex a = new Hex(3, 4, -7);
      OffsetCoord b = new OffsetCoord(1, -3);
      Assert.IsTrue(Hex.Equals(a, OffsetCoord.QoffsetToCube(OffsetCoord.ODD, OffsetCoord.QoffsetFromCube(OffsetCoord.ODD, a))));
      Assert.IsTrue(OffsetCoord.Equals(b, OffsetCoord.QoffsetFromCube(OffsetCoord.ODD, OffsetCoord.QoffsetToCube(OffsetCoord.ODD, b))));
    }

    [TestMethod]
    static public void TestConversionRoundtrip_even_r () {
      Hex a = new Hex(3, 4, -7);
      OffsetCoord b = new OffsetCoord(1, -3);
      Assert.AreEqual(a, OffsetCoord.RoffsetToCube(OffsetCoord.EVEN, OffsetCoord.RoffsetFromCube(OffsetCoord.EVEN, a)));
      Assert.IsTrue(OffsetCoord.Equals(b, OffsetCoord.RoffsetFromCube(OffsetCoord.EVEN, OffsetCoord.RoffsetToCube(OffsetCoord.EVEN, b))));
    }

    [TestMethod]
    static public void TestConversionRoundtrip_odd_r () {
      Hex a = new Hex(3, 4, -7);
      OffsetCoord b = new OffsetCoord(1, -3);
      Assert.IsTrue(Hex.Equals(a, OffsetCoord.RoffsetToCube(OffsetCoord.ODD, OffsetCoord.RoffsetFromCube(OffsetCoord.ODD, a))));
      Assert.IsTrue(OffsetCoord.Equals(b, OffsetCoord.RoffsetFromCube(OffsetCoord.ODD, OffsetCoord.RoffsetToCube(OffsetCoord.ODD, b))));
    }

    [TestMethod]
    static public void TestOffsetFromCube_even_q () {
      Assert.IsTrue(OffsetCoord.Equals(new OffsetCoord(1, 3), OffsetCoord.QoffsetFromCube(OffsetCoord.EVEN, new Hex(1, 2, -3))));
    }

    [TestMethod]
    static public void TestOffsetFromCube_odd_q () {
      Assert.IsTrue(OffsetCoord.Equals(new OffsetCoord(1, 2), OffsetCoord.QoffsetFromCube(OffsetCoord.ODD, new Hex(1, 2, -3))));
    }

    [TestMethod]
    public void TestOffsetToCube_even_ () {
      Assert.IsTrue(Hex.Equals(new Hex(1, 2, -3), OffsetCoord.QoffsetToCube(OffsetCoord.EVEN, new OffsetCoord(1, 3))));
    }

    [TestMethod]
    public void TestOffsetToCube_odd_q () {
      Assert.IsTrue(Hex.Equals(new Hex(1, 2, -3), OffsetCoord.QoffsetToCube(OffsetCoord.ODD, new OffsetCoord(1, 2))));
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
    public void TestRectangleContainsCoord2d () {
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

    [TestMethod]
    public void TestChangeFromRectangle_0_0 () {
      var h = OffsetCoord.RectangleToHex(new Hex(0, 0, 0), OffsetCoord.EVEN);
      Assert.AreEqual(new Hex(0, 0, 0), h);
    }

    [TestMethod]
    public void TestChangeFromRectangle_0_1 () {
      // 0, 1 의 결과를 원한다.
      var o = OffsetCoord.HexToRectangle(new Hex(0, 1, -1), OffsetCoord.EVEN);
      Assert.AreEqual(new Hex(0, 1, -1), o);
      var h = OffsetCoord.RectangleToHex(new Hex(0, 1, -1), OffsetCoord.EVEN);
      Assert.AreEqual(new Hex(0, 1, -1), h);
    }

    [TestMethod]
    public void TestChangeFromRectangle_0_2 () {
      // 0, 2 의 결과를 원한다.
      var o = OffsetCoord.HexToRectangle(new Hex(0, 2, -2), OffsetCoord.EVEN);
      Assert.AreEqual(new Hex(-1, 2, -1), o);
      var h = OffsetCoord.RectangleToHex(new Hex(-1, 2, -1), OffsetCoord.EVEN);
      Assert.AreEqual(new Hex(0, 2, -2), h);
    }
  }
}