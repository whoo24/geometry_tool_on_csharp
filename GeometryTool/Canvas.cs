using System;
using System.Drawing;
using System.Windows.Forms;
using GeometryTool.Core;
using GeometryTool.CanvasDetail;

namespace GeometryTool {
  public partial class Canvas : UserControl {
    public Canvas () {
      InitializeComponent();
    }

    private void Canvas_Paint (object sender, PaintEventArgs e) {
      ClearColor(e);
      DrawAxis(e, Global.Instance.Context);
      DrawLines(e, Global.Instance.Context);
      DrawPoints(e, Global.Instance.Context);
      DrawRectangle(e, Global.Instance.Context);
    }
    
    void DrawAxis (PaintEventArgs e, Context context) {
      Brush WhiteBrush = new SolidBrush(Color.White);
      using (Pen axis_pen = new Pen(Color.Gray)) {
        // Y-Axis
        if (context.left_corner.x <= 0 && 0 <= context.right_corner.x) {
          int sx = (int)(context.width * 0.5 - context.center.x);
          e.Graphics.DrawLine(axis_pen, new Point(sx, 0), new Point(sx, Height));
        }
        // X-Axis
        if (context.right_corner.y<= 0 && 0 <= context.left_corner.y) {
          int sy = (int)(context.center.y - context.height * 0.5);
          e.Graphics.DrawLine(axis_pen, new Point(0, sy), new Point(Width, sy));
        }
      }
    }

    private void ClearColor (PaintEventArgs e) {
      e.Graphics.Clear(Color.White);
    }

    void DrawLines (PaintEventArgs e, Context context) {
      foreach (LineObject line in context.container.lines_) {
        line.Draw(this, e, context);
      }
    }

    void DrawPoints (PaintEventArgs e, Context context) {
      foreach (PointObject p in context.container.points_) {
        p.Draw(this, e, context);
      }
    }

    void DrawRectangle (PaintEventArgs e, Context context) {
      foreach (RectangleObject rectangle in context.container.rectangles_) {
        rectangle.Draw(this, e, context);
      }
    }

    private void Canvas_Resize (object sender, EventArgs e) {
      Refresh();
    }

    private void Canvas_Load (object sender, EventArgs e) {
      Global.Instance.Context = new Context(Width, Height);
      System.Diagnostics.Debug.WriteLine(this.Size);
    }
  }
}
