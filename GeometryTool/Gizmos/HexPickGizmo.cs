using GeometryTool.CanvasDetail;
using GeometryTool.Hexagonal;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GeometryTool.Gizmos {
  public class HexPickGizmo : Behavior {
    private Canvas canvas_;
    private Layout pointy_ = new Layout(Layout.pointy_, new Hexagonal.Point(60 / (System.Math.Sqrt(3) / 2), 70), new Hexagonal.Point(0, 0));

    public HexPickGizmo (Canvas canvas) {
      canvas_ = canvas;
    }

    public void OnClick (MouseEventArgs e, Context context) {
      PickHex(e, context);
    }

    public void OnMove (MouseEventArgs e, Context context) {
    }

    public void OnDown (MouseEventArgs e, Context context) { }

    public void OnUp (MouseEventArgs e, Context context) { }

    public void OnFinish () { }

    private void PickHex (MouseEventArgs e, Context context) {
      if (e.Button != MouseButtons.Left) {
        return;
      }
      var local_pt = context.ToLocal(e.Location);
      var hex = Layout.GetHexFromPixel(pointy_, new Hexagonal.Point(local_pt.x, local_pt.y));
      DrawHex(hex, Color.Red, context);
      canvas_.Refresh();
    }
    
    private void DrawHex (Hex h, Color line_color, Context context) {
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
      RectangleObject r = new RectangleObject();
      r.rectangle = new Core.Rect() {
        lt = new Core.Coord2d(center.x + -60, center.y + 70),
        rt = new Core.Coord2d(center.x + 60, center.y + 0),
        lb = new Core.Coord2d(center.x + -60, center.y + -70),
        rb = new Core.Coord2d(center.x + 60, center.y + -70)
      };
      r.Color = Color.Aqua;
      context.container.rectangles_.Add(r);
    }
  }
}
