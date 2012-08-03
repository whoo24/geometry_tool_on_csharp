using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GeometryTool
{
    public class Vertex
    {
        public double x;
        public double y;

        public Point Location
        {
            get { return new Point( (int)x, (int)y); }
            set { x = value.X; y = value.Y;  }
        }
    }
}
