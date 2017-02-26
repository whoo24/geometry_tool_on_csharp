using GeometryTool.CanvasDetail;
using System.Windows.Forms;

namespace GeometryTool.Gizmos {
  public interface Behavior {
    void OnClick (MouseEventArgs e, Context context);
    void OnDown (MouseEventArgs e, Context context);
    void OnUp (MouseEventArgs e, Context context);
    void OnMove (MouseEventArgs e, Context context);
    void OnFinish ();
  }
}
