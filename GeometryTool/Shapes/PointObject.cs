using System.Windows.Forms;
using System.Drawing;
using GeometryTool.Core;
using GeometryTool.CanvasDetail;

namespace GeometryTool {
  public class PointObject {
    public Coord2d Position { get; set; }

    public PointObject () { }

    public PointObject (Coord2d p) { Position = p; }

    public PointObject (Point p) { Position = new Coord2d(p.X, p.Y); }

    public void Draw (Canvas canvas, PaintEventArgs e, Context context) {
      using (Brush VertexBrush = new SolidBrush(Color.Black)) {
        Rectangle draw_rect = new Rectangle(context.ToScreen(new Coord2d(Position.x, Position.y)), new Size(4, 4));
        draw_rect.Offset(-2, -2);
        e.Graphics.FillRectangle(VertexBrush, draw_rect);
      }
    }

    public bool Contains (Point p) {
      Rectangle draw_rect = new Rectangle(new Point((int)Position.x, (int)Position.y), new Size(4, 4));
      draw_rect.Offset(-2, -2);

      return draw_rect.Contains(p);
    }
  }
}
