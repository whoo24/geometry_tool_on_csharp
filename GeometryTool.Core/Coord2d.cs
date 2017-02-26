using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeometryTool.Core {
  [Serializable]
  public struct Coord2d {
    public double x;
    public double y;

    public Coord2d (double _x, double _y) {
      x = _x;
      y = _y;
    }

    public Coord2d (Coord2d p) {
      x = p.x;
      y = p.y;
    }

    public static Coord2d operator - (Coord2d p1, Coord2d p2) {
      return new Coord2d(p1.x - p2.x, p1.y - p2.y);
    }

    public static Coord2d operator + (Coord2d p1, Coord2d p2) {
      return new Coord2d(p1.x + p2.x, p1.y + p2.y);
    }

    public static Coord2d operator * (Coord2d p1, Coord2d p2) {
      return new Coord2d(p1.x * p2.x, p1.y * p2.y);
    }

    public static Coord2d operator * (Coord2d p1, double scala) {
      return new Coord2d(p1.x * scala, p1.y * scala);
    }

    public void Offset (double dx, double dy) {
      x += dx;
      y += dy;
    }
  }
}
