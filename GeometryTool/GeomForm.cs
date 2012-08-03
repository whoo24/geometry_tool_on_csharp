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
                OnFinish = () => {}
            };

            LinkPointGizmo = new Gizmo
            {
                OnClick = new Action<MouseEventArgs>(LinkPoint),
                OnFinish = () => { old_point = null; }
            };

            Global.Instance.Gizmo = MakePointGizmo;
        }

        private void AddPoint(MouseEventArgs e)
        {
            PointObject mouse_p = new PointObject { Position = new Vertex { x = e.X, y = e.Y } };

            panel1.Points.Add(mouse_p);

            panel1.Refresh();
        }

        PointObject old_point;

        private void LinkPoint(MouseEventArgs e)
        {
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

        
    }
}
