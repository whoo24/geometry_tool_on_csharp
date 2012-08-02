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

        public Canvas()
        {
            InitializeComponent();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            ClearColor(e);
            DrawAxis(e);
            DrawPoints(e);
        }

        void DrawAxis(PaintEventArgs e)
        {
            Rectangle client_rect = new Rectangle(0, 0, this.Width, this.Height);
            Brush WhiteBrush = new SolidBrush(Color.White);

            Pen axis_pen = new Pen(Color.Gray);
            e.Graphics.DrawLine(axis_pen, new Point(0, client_rect.Height / 2), new Point(client_rect.Width, client_rect.Height / 2));
            e.Graphics.DrawLine(axis_pen, new Point(client_rect.Width / 2, 0), new Point(client_rect.Width / 2, client_rect.Height));
        }

        private void ClearColor(PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
        }

        void DrawPoints(PaintEventArgs e)
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
