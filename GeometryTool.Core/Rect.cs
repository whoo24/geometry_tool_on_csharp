using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeometryTool.Core {
  [Serializable]
  public class Rect {
    public Coord2d lt = new Coord2d();
    public Coord2d rt = new Coord2d();
    public Coord2d lb = new Coord2d();
    public Coord2d rb = new Coord2d();

    public Coord2d Center {
      get { return new Coord2d(rt.x - lt.x, rt.y - rb.y) * 0.5 + rb; }
    }

    public Rect () { }
    public Rect (Rect r) {
      this.lt = r.lt;
      this.rt = r.rt;
      this.lb = r.lb;
      this.rb = r.rb;
    }

    public Rect (Coord2d p) {
      this.lt = p;
      this.rt = p;
      this.lb = p;
      this.rb = p;
    }

    public Coord2d LeftTop {
      get {
        return lt;
      }
    }

    public System.Drawing.Size Size {
      get {
        return new System.Drawing.Size((int)(rb.x - lt.x), (int)(lt.y - rb.y));
      }
    }

    public bool Contains (Coord2d p) {
      if (p.x < lt.x || rt.x < p.x) {
        return false;
      }
      if (p.y < lb.y || lt.y < p.y) {
        return false;
      }
      return true;
    }

    public double 기울기 () {
      return (lb.y - rt.y) / (lb.x - rt.x);
    }

    public Coord2d FractionContact (Coord2d p) {
      double width = rt.x - lt.x;
      double height = rt.y - rb.y;
      double sx = p.x - lb.x;
      double sy = p.y - lb.y;
      return new Coord2d(sx / width, sy / height);
    }

    public void SetWidth (double w) {
      double d = (w - Size.Width) * 0.5;
      lt.x -= d;
      lb.x -= d;
      rt.x += d;
      rb.x += d;
    }

    public void SetHeight (double h) {
      double d = (h - Size.Height) * 0.5;
      lt.y += d;
      lb.y -= d;
      rt.y += d;
      rb.y -= d;
    }

    public void SetCenter (Coord2d p) {
      var d = p - Center;
      lt += d;
      rt += d;
      lb += d;
      rb += d;
    }
  }
}
