using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeometryTool.Core {
  public class LineSegment {
    public Coord2d p1;
    public Coord2d p2;

    public double 기울기 () {
      return (p1.y - p2.y) / (p1.x - p2.x);
    }

  }
}
