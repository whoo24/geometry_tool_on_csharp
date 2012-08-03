using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GeometryTool
{
    public partial class GeomForm : Form
    {
        public GeomForm()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
            Brush brush = new SolidBrush(Color.Red);
//            e.Graphics.FillEllipse(brush, e.ClipRectangle);
        }

        Gizmo MakePointGizmo;
        Gizmo LinkPointGizmo;

        private void Form1_Load(object sender, EventArgs e)
        {
            MakePointGizmo = new Gizmo
            {
                OnClick = new Action<MouseEventArgs>(AddPoint),
                OnMove = new Action<MouseEventArgs>(MovePanel),
                OnFinish = () => {}
            };

            LinkPointGizmo = new Gizmo
            {
                OnClick = new Action<MouseEventArgs>(LinkPoint),
                OnMove = new Action<MouseEventArgs>(MovePanel),
                OnFinish = () => { old_point = null; }
            };

            Global.Instance.Gizmo = MakePointGizmo;
        }

        private void AddPoint(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            PointObject mouse_p = new PointObject { Position = new Vertex { x = e.X, y = e.Y } };

            panel1.Points.Add(mouse_p);

            panel1.Refresh();
        }

        PointObject old_point;

        private void LinkPoint(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            PointObject p = GetPointObject(e.Location);
            if (p != null)
            {
                if (old_point != null)
                {
                    LineObject line = new LineObject { Point1 = old_point, Point2 = p };
                    panel1.Lines.Add(line);
                }
                old_point = p;

                panel1.Refresh();
            }
        }

        private void MovePanel(MouseEventArgs e)
        {
            //if (!Capture)
            //    return;
            if (e.Button != MouseButtons.Middle)
                return;

            Point left_corner = panel1.LeftCorner;
            left_corner.Offset((old_mouse_point.X - e.X), (e.Y - old_mouse_point.Y));

            old_mouse_point = e.Location;
            panel1.LeftCorner = left_corner;
            panel1.Refresh();
        }

        private PointObject GetPointObject(Point p)
        {
            foreach (PointObject point in panel1.Points)
            {
                if (point.Contains(p))
                {
                    return point;
                }
            }
            return null;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Global.Instance.Gizmo = MakePointGizmo;            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Global.Instance.Gizmo = LinkPointGizmo;
        }

        private void panel1_Click(object sender, EventArgs _e)
        {
            // create point at mouse point
            MouseEventArgs e = _e as MouseEventArgs;

            Global.Instance.Gizmo.OnClick(e);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Global.Instance.Gizmo.OnMove(e);
        }

        Point old_mouse_point;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            //if (!Capture)
            {
            //    Capture = true;
                old_mouse_point = e.Location;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            //if (Capture)
            //    Capture = false;
        }

        
    }
}
