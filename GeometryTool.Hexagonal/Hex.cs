using System;
using System.Collections.Generic;

namespace GeometryTool.Hexagonal {
  [Serializable]
  public struct Hex {
    public Hex (int q, int r, int s) {
      this.q = q;
      this.r = r;
      this.s = s;
    }
    public readonly int q;
    public readonly int r;
    public readonly int s;

    static public Hex Add (Hex a, Hex b) {
      return new Hex(a.q + b.q, a.r + b.r, a.s + b.s);
    }

    static public Hex Subtract (Hex a, Hex b) {
      return new Hex(a.q - b.q, a.r - b.r, a.s - b.s);
    }

    static public Hex Scale (Hex a, int k) {
      return new Hex(a.q * k, a.r * k, a.s * k);
    }

    static public List<Hex> directions = new List<Hex> { new Hex(1, 0, -1), new Hex(1, -1, 0), new Hex(0, -1, 1), new Hex(-1, 0, 1), new Hex(-1, 1, 0), new Hex(0, 1, -1) };

    static public Hex Direction (int direction) {
      return directions[direction];
    }

    static public Hex Neighbor (Hex hex, int direction) {
      return Add(hex, Hex.Direction(direction));
    }

    static public List<Hex> diagonals = new List<Hex> { new Hex(2, -1, -1), new Hex(1, -2, 1), new Hex(-1, -1, 2), new Hex(-2, 1, 1), new Hex(-1, 2, -1), new Hex(1, 1, -2) };

    static public Hex DiagonalNeighbor (Hex hex, int direction) {
      return Hex.Add(hex, diagonals[direction]);
    }

    static public int Length (Hex hex) {
      return (Math.Abs(hex.q) + Math.Abs(hex.r) + Math.Abs(hex.s)) / 2;
    }

    static public int Distance (Hex a, Hex b) {
      return Length(Subtract(a, b));
    }

    static public bool Equals (Hex a, Hex b) {
      return (a.q == b.q && a.s == b.s && a.r == b.r);
    }

    public override bool Equals (object b) {
      if (b is Hex) {
        return Equals(this, (Hex)b);
      }
      return base.Equals(b);
    }

    static public bool operator == (Hex a, Hex b) {
      return Equals(a, b);
    }

    static public bool operator != (Hex a, Hex b) {
      return !(a == b);
    }

    public override int GetHashCode () {
      return base.GetHashCode();
    }

    public override string ToString () {
      return string.Format("({0}, {1}, {2})", q, r, s);
    }
  }
}
