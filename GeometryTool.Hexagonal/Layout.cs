﻿using GeometryTool.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryTool.Hexagonal {
  public struct Layout {
    public Layout (Orientation orientation, Point size, Point origin) {
      this.orientation = orientation;
      this.size = size;
      this.origin = origin;
    }
    public readonly Orientation orientation;
    public readonly Point size;
    public readonly Point origin;
    static public Orientation pointy = new Orientation(Math.Sqrt(3.0), Math.Sqrt(3.0) / 2.0, 0.0, -3.0 / 2.0, Math.Sqrt(3.0) / 3.0, -1.0 / 3.0, 0.0, 2.0 / 3.0, 0.5);
    static public Orientation flat = new Orientation(3.0 / 2.0, 0.0, Math.Sqrt(3.0) / 2.0, Math.Sqrt(3.0), 2.0 / 3.0, 0.0, -1.0 / 3.0, Math.Sqrt(3.0) / 3.0, 0.0);

    static public Point HexToPixel (Layout layout, Hex h) {
      Orientation M = layout.orientation;
      Point size = layout.size;
      Point origin = layout.origin;
      double x = (/*M.f0*/2.0f * h.q + 1.0f * (h.r & 1)) * size.x;
      //double x = (M.f0 * h.q + M.f1 * (h.r & 1)) * size.x;
      double y = (M.f2 * h.q + M.f3 * h.r) * size.y;
      return new Point(x + origin.x, y + origin.y);
    }


    static public FractionalHex PixelToHex (Layout layout, Point p) {
      Orientation M = layout.orientation;
      Point size = layout.size;
      Point origin = layout.origin;
      Point pt = new Point((p.x - origin.x) / size.x, (p.y - origin.y) / size.y);
      double q = M.b0 * pt.x + M.b1 * ((int)pt.y&1);
      double r = M.b2 * pt.x + M.b3 * pt.y;
      return new FractionalHex(q, r, -q - r);
    }

    static public Hex GetHexFromPixel (Layout layout, Point p, ref Hex c, ref Rect r, ref Rect h) {
      Orientation M = layout.orientation;
      Point size = layout.size;
      Point origin = layout.origin;
      //int q = (int)Math.Floor(pt.x);
      //int r = 0;// (M.f2 * (int)(pt.y / size.y) + M.f3 * pt.x / M.f0) * size.y;
      var candidate = FractionalHex.HexRound(PixelToHex(layout, p));
      c = candidate;
      //var candidate = new Hex(q, r, -q - r);
      var corners = PolygonCorners(layout, candidate);
      double hex_h = corners[0].y - corners[1].y;
      double hex_w = corners[0].x - corners[4].x;
      // body
      Rect rect = new Rect();
      var center = HexToPixel(layout, candidate);
      rect.SetCenter(new Coord2d(center.x, center.y));
      rect.SetWidth(hex_w);
      rect.SetHeight(hex_h);
      r = rect;
      if (rect.Contains(new Coord2d(p.x, p.y))) {
        return candidate;
      }
      // header
      Rect header = new Rect();
      header.SetCenter(new Coord2d(center.x, 0));// corners[0].y + (corners[5].y - corners[0].y) * 0.5));
      header.SetWidth(corners[0].x - corners[4].x);
      header.SetHeight(corners[5].y - corners[0].y);
      h = header;
      if (rect.Contains(new Coord2d(p.x, p.y))) {
        return Hex.Add(candidate, new Hex(0, -1, 1));
      } else {
        return Hex.Add(candidate, new Hex(0, 1, -1));
      }
    }

    static public Point HexCornerOffset (Layout layout, int corner) {
      Orientation M = layout.orientation;
      Point size = layout.size;
      double angle = 2.0 * Math.PI * (M.start_angle - corner) / 6;
      double degree = angle * (180.0f / Math.PI);
      return new Point(size.x * (corner == 2 || corner == 5 ? Math.Cos(angle) : 1.0f * Math.Sign(Math.Cos(angle))), size.y * Math.Sin(angle));
    }


    static public List<Point> PolygonCorners (Layout layout, Hex h) {
      List<Point> corners = new List<Point> { };
      Point center = Layout.HexToPixel(layout, h);
      for (int i = 0; i < 6; i++) {
        Point offset = Layout.HexCornerOffset(layout, i);
        corners.Add(new Point(center.x + offset.x, center.y + offset.y));
      }
      return corners;
    }

    double sign (Coord2d p1, Coord2d p2, Coord2d p3) {
      return (p1.x - p3.x) * (p2.y - p3.y) - (p2.x - p3.x) * (p1.y - p3.y);
    }

    bool PointInTriangle (Coord2d pt, Coord2d v1, Coord2d v2, Coord2d v3) {
      bool b1, b2, b3;

      b1 = sign(pt, v1, v2) < 0.0f;
      b2 = sign(pt, v2, v3) < 0.0f;
      b3 = sign(pt, v3, v1) < 0.0f;

      return ((b1 == b2) && (b2 == b3));
    }

  }
}