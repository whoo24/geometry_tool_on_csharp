using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace GeometryTool
{
    public class PointObject
    {
        public Vertex Position { get; set; }

        public PointObject()
        {

        }

        public void Draw(PaintEventArgs e)
        {
            using( Brush VertexBrush = new SolidBrush(Color.Black) )
            {
                Rectangle draw_rect = new Rectangle( new Point( (int)Position.x, (int)Position.y), new Size(4, 4));
                draw_rect.Offset(-2, -2);

                e.Graphics.FillRectangle(VertexBrush, draw_rect);
            }
        }
    }
}
