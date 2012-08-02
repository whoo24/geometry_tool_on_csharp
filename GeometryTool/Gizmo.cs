using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GeometryTool
{
    public class Gizmo
    {
        public Gizmo()
        {

        }

        public delegate void ClickEvent(PaintEventArgs e);
        public Action<PaintEventArgs> OnClick;
    }

    public class GizmoMakePoint : Gizmo
    {
        GizmoMakePoint()
        {
            OnClick = delegate(PaintEventArgs e) { };
        }
    }

}
