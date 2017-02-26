using System.Collections.Generic;
using System.Drawing;

namespace GeometryTool {
  public class CanvasContainer {
    public PointObject GetPointObject (Point p) {
      foreach (PointObject point in points_) {
        if (point.Contains(p)) {
          return point;
        }
      }
      return null;
    }

    public List<PointObject> points_ = new List<PointObject>();
    public List<LineObject> lines_ = new List<LineObject>();
    public List<RectangleObject> rectangles_ = new List<RectangleObject>();
  }
}
