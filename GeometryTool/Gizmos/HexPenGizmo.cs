﻿using GeometryTool.CanvasDetail;
using GeometryTool.Hexagonal;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GeometryTool.Gizmos {
  public class HexPenGizmo : Behavior {
    public HexPenGizmo (Canvas canvas) {
      canvas_ = canvas;
    }

    public void OnClick (MouseEventArgs e, Context context) {
      AddHex(e, context);
    }

    public void OnMove (MouseEventArgs e, Context context) { }

    public void OnDown (MouseEventArgs e, Context context) { }

    public void OnUp (MouseEventArgs e, Context context) { }

    public void OnFinish () {}

    private void AddHex (MouseEventArgs e, Context context) {
      if (e.Button != MouseButtons.Left) {
        return;
      }
      var local_pt = context.ToLocal(e.Location);
      PointObject mouse_p = new PointObject { Position = local_pt };
      context.container.points_.Add(mouse_p);
      DrawHex(Layout.GetHexFromPixel(pointy_, new Hexagonal.Point(local_pt.x, local_pt.y)), Color.Red, context);
      var o = Layout.GetHexFromPixel(pointy_, new Hexagonal.Point(local_pt.x, local_pt.y));
      var h = OffsetCoord.RectangleToHex(o, layout.offset);
      System.Diagnostics.Debug.WriteLine(string.Format("{0} => {1}", o, OffsetCoord.ToWorld(h)));
      canvas_.Refresh();
    }
    
    public void DrawHex (Hex h, Color line_color, Context context) {
      List<Hexagonal.Point> corners = Layout.PolygonCorners(pointy_, h);
      PointObject p1 = new PointObject();
      p1.Position = new Core.Coord2d() { x = corners[0].x, y = corners[0].y };
      var first = p1;
      context.container.points_.Add(p1);
      for (int i = 1; i < 6; i++) {
        PointObject p2 = new PointObject();
        p2.Position = new Core.Coord2d() { x = corners[i].x, y = corners[i].y };
        context.container.points_.Add(p2);
        LineObject line = new LineObject();
        line.Point1 = p1;
        line.Point2 = p2;
        line.color = line_color;
        context.container.lines_.Add(line);
        p1 = p2;
        p2 = null;
      }
      LineObject aline = new LineObject();
      aline.Point1 = p1;
      aline.Point2 = first;
      aline.color = line_color;
      context.container.lines_.Add(aline);

      var center = Layout.HexToPixel(pointy_, h);
      RectangleObject r = new RectangleObject(new Core.Rect() {
        lt = new Core.Coord2d(center.x + -60, center.y + 70),
        rt = new Core.Coord2d(center.x + 60, center.y + 0),
        lb = new Core.Coord2d(center.x + -60, center.y + -70),
        rb = new Core.Coord2d(center.x + 60, center.y + -70)
      }, Color.Bisque);
      context.container.rectangles_.Add(r);
    }

    private Canvas canvas_;
    private Layout pointy_ = new Layout(Layout.pointy_, Layout.MakeSize(120, 140), new Hexagonal.Point(0, 0), OffsetCoord.ODD);

    public Layout layout {
      get {
        return pointy_;
      }

      set {
        pointy_ = value;
      }
    }
  }
}
