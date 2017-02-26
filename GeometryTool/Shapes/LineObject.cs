using System.Windows.Forms;
using System.Drawing;
using GeometryTool.CanvasDetail;

namespace GeometryTool {
  public class LineObject {
    public PointObject Point1;
    public PointObject Point2;
    public Color color = Color.Black;

    public LineObject () { }

    public void Draw (Canvas canvas, PaintEventArgs e, Context context) {
      using (Pen LinePen = new Pen(color)) {
        e.Graphics.DrawLine(LinePen, context.ToScreen(Point1.Position), context.ToScreen(Point2.Position));
      }
    }
  }
}
