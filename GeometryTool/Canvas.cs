using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GeometryTool
{
    public partial class Canvas : UserControl
    {
        List<PointObject> m_points = new List<PointObject>();
        public List<PointObject> Points
        {
            get { return m_points; }
            set { m_points = value; }
        }

        List<LineObject> m_lines = new List<LineObject>();
        public List<LineObject> Lines
        {
            get { return m_lines; }
            set { m_lines = value; }
        }

        Point left_corner = new Point(0);
        public Point LeftCorner
        {
            get { return left_corner; }
            set { left_corner = value; }
        }

        public Canvas()
        {
            InitializeComponent();
            left_corner.X = -Width / 2;
            left_corner.Y = Height / 2;
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            Rectangle client_rect = new Rectangle( LeftCorner, this.Size );

            ClearColor(e);
            DrawAxis(client_rect, e);
            DrawLines(client_rect, e);
            DrawPoints(client_rect, e);
        }

        Point ToLocal(Point p)
        {
            Point local = new Point
            {
                X = p.X + LeftCorner.X,
                Y = p.Y + LeftCorner.Y
            };
            return local;
        }

        Point ToScreen(Point p)
        {
            Point screen = new Point
            {
                X = p.X - LeftCorner.X,
                Y = LeftCorner.Y - p.Y
            };
            return screen;
        }

        void DrawAxis(Rectangle client_rect, PaintEventArgs e)
        {
            Brush WhiteBrush = new SolidBrush(Color.White);

            Pen axis_pen = new Pen(Color.Gray);

            e.Graphics.DrawLine(axis_pen, ToScreen(new Point(0, LeftCorner.Y - Height)), ToScreen(new Point(0, LeftCorner.Y))); // Y-Axis
            e.Graphics.DrawLine(axis_pen, ToScreen(new Point(Width - LeftCorner.X, 0)), ToScreen(new Point(LeftCorner.X, 0))); // X-Axis
        }

        private void ClearColor(PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
        }

        void DrawLines(Rectangle client_rect, PaintEventArgs e)
        {
            foreach (LineObject line in Lines)
            {
                line.Draw(e);
            }
        }

        void DrawPoints(Rectangle client_rect, PaintEventArgs e)
        {
            foreach (PointObject p in Points)
            {
                p.Draw(e);
            }
        }

        private void Canvas_Resize(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
