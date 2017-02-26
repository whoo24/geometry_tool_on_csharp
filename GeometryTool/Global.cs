using GeometryTool.CanvasDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeometryTool {
  public class Global {
    public static Global Instance {
      get { return instance; }
    }
    private static Global instance = new Global();

    public Context Context { get; set; }
  }
}
