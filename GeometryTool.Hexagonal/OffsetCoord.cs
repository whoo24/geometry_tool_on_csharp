﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryTool.Hexagonal {
  public struct OffsetCoord {
    public OffsetCoord (int col, int row) {
      this.col = col;
      this.row = row;
    }
    public readonly int col;
    public readonly int row;
    static public int EVEN = 1;
    static public int ODD = -1;

    static public OffsetCoord QoffsetFromCube (int offset, Hex h) {
      int col = h.q;
      int row = h.r + (int)((h.q + offset * (h.q & 1)) / 2);
      return new OffsetCoord(col, row);
    }


    static public Hex QoffsetToCube (int offset, OffsetCoord h) {
      int q = h.col;
      int r = h.row - (int)((h.col + offset * (h.col & 1)) / 2);
      int s = -q - r;
      return new Hex(q, r, s);
    }


    static public OffsetCoord RoffsetFromCube (int offset, Hex h) {
      int col = h.q + (int)((h.r + offset * (h.r & 1)) / 2);
      int row = h.r;
      return new OffsetCoord(col, row);
    }


    static public Hex RoffsetToCube (int offset, OffsetCoord h) {
      int q = h.col - (int)((h.row + offset * (h.row & 1)) / 2);
      int r = h.row;
      int s = -q - r;
      return new Hex(q, r, s);
    }

  }
}
