using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeometryTool.Core;
using System.Collections.Generic;

namespace GeometryTool.Hexagonal.Tests {
  [TestClass]
  public class Hexagonal_Origin {

    [TestClass]
    public class Tests {

      static public void EqualHex (String name, Hex a, Hex b) {
        if (!(a.q == b.q && a.s == b.s && a.r == b.r)) {
          Tests.Complain(name);
        }
      }


      static public void EqualOffsetcoord (String name, OffsetCoord a, OffsetCoord b) {
        if (!(a.col == b.col && a.row == b.row)) {
          Tests.Complain(name);
        }
      }


      static public void EqualInt (String name, int a, int b) {
        if (!(a == b)) {
          Tests.Complain(name);
        }
      }


      static public void EqualHexArray (String name, List<Hex> a, List<Hex> b) {
        Tests.EqualInt(name, a.Count, b.Count);
        for (int i = 0; i < a.Count; i++) {
          Tests.EqualHex(name, a[i], b[i]);
        }
      }


      [TestMethod]
      public void TestLayout () {
        Hex h = new Hex(3, 4, -7);
        Layout flat = new Layout(Layout.flat, new Point(10, 15), new Point(35, 71));
        Assert.AreEqual(h, FractionalHex.HexRound(Layout.PixelToHex(flat, Layout.HexToPixel(flat, h))));
        Layout pointy = new Layout(Layout.pointy_, new Point(10, 15), new Point(35, 71));
        Assert.AreEqual(h, FractionalHex.HexRound(Layout.PixelToHex(pointy, Layout.HexToPixel(pointy, h))));
      }


      static public void TestConversionRoundtrip () {
        Hex a = new Hex(3, 4, -7);
        OffsetCoord b = new OffsetCoord(1, -3);
        Tests.EqualHex("conversion_roundtrip even-q", a, OffsetCoord.QoffsetToCube(OffsetCoord.EVEN, OffsetCoord.QoffsetFromCube(OffsetCoord.EVEN, a)));
        Tests.EqualOffsetcoord("conversion_roundtrip even-q", b, OffsetCoord.QoffsetFromCube(OffsetCoord.EVEN, OffsetCoord.QoffsetToCube(OffsetCoord.EVEN, b)));
        Tests.EqualHex("conversion_roundtrip odd-q", a, OffsetCoord.QoffsetToCube(OffsetCoord.ODD, OffsetCoord.QoffsetFromCube(OffsetCoord.ODD, a)));
        Tests.EqualOffsetcoord("conversion_roundtrip odd-q", b, OffsetCoord.QoffsetFromCube(OffsetCoord.ODD, OffsetCoord.QoffsetToCube(OffsetCoord.ODD, b)));
        Tests.EqualHex("conversion_roundtrip even-r", a, OffsetCoord.RoffsetToCube(OffsetCoord.EVEN, OffsetCoord.RoffsetFromCube(OffsetCoord.EVEN, a)));
        Tests.EqualOffsetcoord("conversion_roundtrip even-r", b, OffsetCoord.RoffsetFromCube(OffsetCoord.EVEN, OffsetCoord.RoffsetToCube(OffsetCoord.EVEN, b)));
        Tests.EqualHex("conversion_roundtrip odd-r", a, OffsetCoord.RoffsetToCube(OffsetCoord.ODD, OffsetCoord.RoffsetFromCube(OffsetCoord.ODD, a)));
        Tests.EqualOffsetcoord("conversion_roundtrip odd-r", b, OffsetCoord.RoffsetFromCube(OffsetCoord.ODD, OffsetCoord.RoffsetToCube(OffsetCoord.ODD, b)));
      }


      static public void TestOffsetFromCube () {
        Tests.EqualOffsetcoord("offset_from_cube even-q", new OffsetCoord(1, 3), OffsetCoord.QoffsetFromCube(OffsetCoord.EVEN, new Hex(1, 2, -3)));
        Tests.EqualOffsetcoord("offset_from_cube odd-q", new OffsetCoord(1, 2), OffsetCoord.QoffsetFromCube(OffsetCoord.ODD, new Hex(1, 2, -3)));
      }


      static public void TestOffsetToCube () {
        Tests.EqualHex("offset_to_cube even-", new Hex(1, 2, -3), OffsetCoord.QoffsetToCube(OffsetCoord.EVEN, new OffsetCoord(1, 3)));
        Tests.EqualHex("offset_to_cube odd-q", new Hex(1, 2, -3), OffsetCoord.QoffsetToCube(OffsetCoord.ODD, new OffsetCoord(1, 2)));
      }

      static public void Complain (String name) {
        Console.WriteLine("FAIL " + name);
      }

      [TestMethod]
      public void TestAll () {
        Tests.TestConversionRoundtrip();
        Tests.TestOffsetFromCube();
        Tests.TestOffsetToCube();
      }

    }
  }
}