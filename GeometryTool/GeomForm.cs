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
        List<Point> m_points = new List<Point>();

        public GeomForm()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
            Brush brush = new SolidBrush(Color.Red);
//            e.Graphics.FillEllipse(brush, e.ClipRectangle);
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
