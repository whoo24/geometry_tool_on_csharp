namespace GeometryTool.Hexagonal {
  public struct OffsetCoord {
    static public int ODD = -1;
    static public int EVEN = 1;

    public readonly int col;
    public readonly int row;

    public OffsetCoord (int col, int row) {
      this.col = col;
      this.row = row;
    }

    static public OffsetCoord QoffsetFromCube (int offset, Hex h) {
      int col = h.q;
      int row = h.r + (h.q + offset * (h.q & 1)) / 2;
      return new OffsetCoord(col, row);
    }

    static public Hex QoffsetToCube (int offset, OffsetCoord h) {
      int q = h.col;
      int r = h.row - (h.col + offset * (h.col & 1)) / 2;
      int s = -q - r;
      return new Hex(q, r, s);
    }

    static public OffsetCoord RoffsetFromCube (int offset, Hex h) {
      int col = h.q + (h.r + offset * (h.r & 1)) / 2;
      int row = h.r;
      return new OffsetCoord(col, row);
    }

    static public Hex RoffsetToCube (int offset, OffsetCoord h) {
      int q = h.col - (h.row + offset * (h.row & 1)) / 2;
      int r = h.row;
      int s = -q - r;
      return new Hex(q, r, s);
    }

    public static Hex HexToRectangle (Hex h, int offset) {
      int sq = h.q + ((offset * (h.r & 1) - h.r) / 2);
      int sr = h.r;
      return new Hex(sq, sr, -sq - sr);
    }

    public static Hex RectangleToHex (Hex h, int offset) {
      int sq = h.q - ((offset * (h.r & 1) - h.r) / 2);
      int sr = h.r;
      return new Hex(sq, sr, -sq - sr);
    }

    public static Hex ToScreen (Hex h) {
      return new Hex(h.q, -h.r, -h.q + h.r);
    }

    public static Hex ToWorld (Hex h) {
      return ToScreen(h);
    }

    static public bool Equals (OffsetCoord a, OffsetCoord b) {
      return (a.col == b.col && a.row == b.row);
    }

    public override string ToString () {
      return string.Format("({0}, {1})", col, row);
    }
  }
}
