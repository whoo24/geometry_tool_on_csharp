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

        public Action<MouseEventArgs> OnClick;
        public Action OnFinish;
    }
}
