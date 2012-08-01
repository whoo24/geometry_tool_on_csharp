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
        public Canvas()
        {
            InitializeComponent();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            DrawAxis(e);
        }

        void DrawAxis(PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);

            Rectangle client_rect = new Rectangle(0, 0, this.Width, this.Height);
            Brush WhiteBrush = new SolidBrush(Color.White);
            //e.Graphics.FillRectangle(WhiteBrush, client_rect);

            Pen axis_pen = new Pen(Color.Gray);
            e.Graphics.DrawLine(axis_pen, new System.Drawing.Point(0, client_rect.Height / 2), new System.Drawing.Point(client_rect.Width, client_rect.Height / 2));
            e.Graphics.DrawLine(axis_pen, new System.Drawing.Point(client_rect.Width / 2, 0), new System.Drawing.Point(client_rect.Width / 2, client_rect.Height));
        }

        private void Canvas_Resize(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
