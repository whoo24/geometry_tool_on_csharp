using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryTool.Hexagonal {
  [System.Serializable]
  public struct Offset {
    public int row;
    public int col;

    public Offset (int row, int col) {
      this.row = row; this.col = col;
    }

    public override string ToString () {
      return string.Format("[{0},{1}]", row, col);
    }
  }
}
