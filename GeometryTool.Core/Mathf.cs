using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryTool.Core {
  public class Mathf {
    public const float Deg2Rad = 0.0174532924F;
    public const float Infinity = float.PositiveInfinity;
    public const float NegativeInfinity = float.NegativeInfinity;
    public const float PI = 3.14159274F;
    public const float Rad2Deg = 57.29578F;
    public static readonly float Epsilon = 1E-05F;

    public static float Cos (float f) {
      return (float)Math.Cos(f);
    }

    public static float Sin (float f) {
      return (float)Math.Sin(f);
    }

    public static float Max (params float[] values) {
      float max = float.MinValue;
      foreach (float value in values) {
        max = max > value ? max : value;
      }
      return max;
    }

    public static int Max (params int[] values) {
      int max = int.MinValue;
      foreach (int value in values) {
        max = max > value ? max : value;
      }
      return max;
    }

    public static float Min (params float[] values) {
      float min = float.MinValue;
      foreach (float value in values) {
        min = min < value ? min : value;
      }
      return min;
    }

    public static int Min (params int[] values) {
      int min = int.MinValue;
      foreach (int value in values) {
        min = min < value ? min : value;
      }
      return min;
    }

    public static int Abs (int a) {
      return a > 0 ? a : -a;
    }

    public static float Abs (float a) {
      return a > 0.0f ? a : -a;
    }

    public static float Sqrt (float a) {
      return (float)Math.Sqrt(a);
    }

    public static int RoundToInt(float a) {
      return (int)(a + 0.5f);
    }

    public static float Round (float a) {
      return (int)(a + 0.5f);
    }

    public static float Pow (float f, float p) {
      return (float)Math.Pow(f, p);
    }

  }
}
