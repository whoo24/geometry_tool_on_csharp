using GeometryTool.Core;
using System.Drawing;
using System.Windows.Forms;

namespace GeometryTool.CanvasDetail {
  public class Context {
    public Context (int width, int height) {
      left_corner_.x = -width / 2;
      left_corner_.y = height / 2;
      width_ = width;
      height_ = height;
    }

    public Coord2d ToLocal (Point p) {
      return new Coord2d(left_corner_.x + p.X,
                         left_corner_.y - p.Y);
    }

    public Point ToScreen (Coord2d p) {
      return new Point((int)(p.x - left_corner.x),
                       (int)(left_corner.y - p.y)); // y 는 위로 가면서 커짐
    }
    
    public CanvasContainer container {
      get {
        return container_;
      }
    }

    public Coord2d left_corner {
      get { return left_corner_; }
      set { left_corner_ = value; }
    }

    public Coord2d center {
      get { return left_corner + new Coord2d(width_ / 2, height_ / 2); }
    }

    public Coord2d right_corner {
      get { return left_corner + new Coord2d(width_, -height_); }
    }

    public Point old_mouse_point_;
    public Gizmo gizmo { get; } = new Gizmo();

    public int width {
      get {
        return width_;
      }
    }

    public int height {
      get {
        return height_;
      }
    }

    private Coord2d left_corner_ = new Coord2d(0, 0);
    private int width_;
    private int height_;
    private CanvasContainer container_ = new CanvasContainer();
  }
}
