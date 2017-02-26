using GeometryTool.CanvasDetail;
using System.Drawing;
using System.Windows.Forms;

namespace GeometryTool.Gizmos {
  public class LinkPointGizmo : Behavior {
    private Canvas canvas_;
    private PointObject old_point_;

    public LinkPointGizmo (Canvas canvas) {
      this.canvas_ = canvas;
    }

    public void OnClick (MouseEventArgs e, Context context) {
      LinkPoint(e, context);
    }

    public void OnMove (MouseEventArgs e, Context context) {
    }

    public void OnDown (MouseEventArgs e, Context context) { }
    public void OnUp (MouseEventArgs e, Context context) { }

    public void OnFinish () {
      old_point_ = null;
    }

    private void LinkPoint (MouseEventArgs e, Context context) {
      if (e.Button != MouseButtons.Left) {
        return;
      }
      var pt = new Point((int)context.ToLocal(e.Location).x, (int)context.ToLocal(e.Location).y);
      PointObject p = context.container.GetPointObject(pt);
      if (p != null) {
        if (old_point_ != null) {
          LineObject line = new LineObject { Point1 = old_point_, Point2 = p };
          context.container.lines_.Add(line);
        }
        old_point_ = p;
        canvas_.Refresh();
      }
    }
  }
}
