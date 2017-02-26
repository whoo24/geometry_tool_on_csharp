using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryTool.Core {
  public struct Vector3 {
    public const float kEpsilon = 1E-05F;
    public float x;
    public float y;
    public float z;

    public Vector3 (float x, float y) {
      this.x = x; this.y = y; this.z = 0;
    }
    public Vector3 (float x, float y, float z) {
      this.x = x; this.y = y; this.z = z;
    }

    public static Vector3 zero {
      get {
        return new Vector3(0, 0, 0);
      }
    }
  }
}
