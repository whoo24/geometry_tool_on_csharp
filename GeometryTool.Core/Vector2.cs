using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryTool.Core {
  public struct Vector2 {
    public const float kEpsilon = 1E-05F;
    public float x;
    public float y;

    public Vector2 (float x, float y) {
      this.x = x; this.y = y;
    }


  }
}
