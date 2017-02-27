using GeometryTool.CanvasDetail;
using System.Windows.Forms;

namespace GeometryTool.Gizmos {
  public class MakePointGizmo : Behavior {
    public MakePointGizmo (Canvas canvas) {
      canvas_ = canvas;
    }

    public void OnClick (MouseEventArgs e, Context context) {
      AddPoint(e, context);
    }

    public void OnMove (MouseEventArgs e, Context context) {
    }

    public void OnDown (MouseEventArgs e, Context context) { }
    public void OnUp (MouseEventArgs e, Context context) { }

    public void OnFinish () { }

    private void AddPoint (MouseEventArgs e, Context context) {
      if (e.Button != MouseButtons.Left) {
        return;
      }
      var local = context.ToLocal(e.Location);
      context.container.points_.Add(new PointObject(local));
      canvas_.Refresh();
    }

    private Canvas canvas_;
  }
}
