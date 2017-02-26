using GeometryTool.CanvasDetail;
using System.Drawing;

namespace GeometryTool {
  public class RectangleObject {
    public Core.Rect rectangle {
      get; set;
    }

    public Color Color { get; set; } = Color.Black;

    public RectangleObject () { rectangle = new Core.Rect(); }
    public RectangleObject (Core.Rect rect, Color color) { rectangle = rect;
      Color = color; }

    public void Draw (Canvas canvas, System.Windows.Forms.PaintEventArgs e, Context context) {
      using (var pen = new Pen(Color)) {
        Rectangle draw_rect = new Rectangle(context.ToScreen(rectangle.LeftTop), rectangle.Size);
        e.Graphics.DrawRectangle(pen, draw_rect);
      }
    }
  }
}
