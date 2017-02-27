using System;
using System.Windows.Forms;

namespace GeometryTool {
  public partial class GeomForm : Form {
    public GeomForm () {
      InitializeComponent();
    }

    private void panel1_Paint (object sender, PaintEventArgs e) { }

    private void Form1_Load (object sender, EventArgs e) {
      Global.Instance.Context.gizmo.behavor = new Gizmos.MakePointGizmo(panel1);
    }

    private void toolStripButton1_Click (object sender, EventArgs e) {
      Global.Instance.Context.gizmo.behavor = new Gizmos.MakePointGizmo(panel1);
    }

    private void toolStripButton2_Click (object sender, EventArgs e) {
      Global.Instance.Context.gizmo.behavor = new Gizmos.LinkPointGizmo(panel1);
    }

    private void panel1_Click (object sender, EventArgs e) {
      Global.Instance.Context.gizmo.behavor.OnClick(e as MouseEventArgs, Global.Instance.Context);
    }

    private void panel1_MouseMove (object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Middle) {
        // panning canvas
        var context = Global.Instance.Context;
        double sx = context.old_mouse_point_.X - e.X;
        double sy = (e.Y - context.old_mouse_point_.Y);
        context.left_corner += new Core.Coord2d(sx, sy);
        Global.Instance.Context.old_mouse_point_ = e.Location;
        panel1.Refresh();
      }
      Global.Instance.Context.gizmo.behavor.OnMove(e, Global.Instance.Context);
    }

    private void panel1_MouseDown (object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Middle) {
        var context = Global.Instance.Context;
        Global.Instance.Context.old_mouse_point_ = e.Location;
      }
      Global.Instance.Context.gizmo.behavor.OnDown(e, Global.Instance.Context);
    }

    private void panel1_MouseUp (object sender, MouseEventArgs e) {
      Global.Instance.Context.gizmo.behavor.OnUp(e, Global.Instance.Context);
    }

    private void toolStripButton5_Click (object sender, EventArgs e) {
      Global.Instance.Context.container.lines_.Clear();
      Global.Instance.Context.container.points_.Clear();
      Global.Instance.Context.container.rectangles_.Clear();
      panel1.Refresh();
    }

    private void toolStripButton4_Click (object sender, EventArgs e) {
      var gizmo = new Gizmos.HexPenGizmo(panel1);
      Global.Instance.Context.gizmo.behavor = gizmo;
      for(int y = 0; y < 3; ++y) {
        for (int x = 0; x < 3; ++x) {
          gizmo.DrawHex(new Hexagonal.Hex(x, y, -x -y), System.Drawing.Color.Blue, Global.Instance.Context);
        }
      }
      panel1.Refresh();
    }

    private void toolStripButton3_Click_1 (object sender, EventArgs e) {
      Global.Instance.Context.gizmo.behavor = new Gizmos.HexPickGizmo(panel1);
    }
  }
}
