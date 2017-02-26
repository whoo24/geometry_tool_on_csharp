using GeometryTool.Gizmos;

namespace GeometryTool {
  public class Gizmo {
    public Behavior behavor {
      get {
        return behavor_;
      }

      set {
        behavor_ = value;
      }
    }

    public Gizmo () {}
    
    private Behavior behavor_;
  }
}
