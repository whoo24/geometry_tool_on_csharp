namespace GeometryTool.Hexagonal {
  public struct Point {
    public Point (double x, double y) {
      this.x = x;
      this.y = y;
    }

    public override string ToString () {
      return string.Format("({0}, {1})", x, y);
    }

    public readonly double x;
    public readonly double y;

  }

}
