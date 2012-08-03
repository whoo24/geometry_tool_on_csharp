using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace GeometryTool
{
    public class LineObject
    {
        public PointObject Point1; public PointObject Point2;

        public LineObject()
        {

        }

        public void Draw(PaintEventArgs e)
        {
            using (Pen LinePen = new Pen(Color.Black))
            {
                e.Graphics.DrawLine(LinePen, Point1.Position.Location, Point2.Position.Location);
            }
        }
    }
}
