using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeometryTool
{
    //모든 직선 l은 그 직선 위의 한 쌍의 점(x1, y1)과 (x2, y2)를 써서 표현할 수 있다.
    // ax + bx + c = 0;
    // y = mx + b; m=직선의 기울기, b = y절편
    // m = dy / dx = (y1 - y2) / (x1 - x2), y절편 = b = y1 - mx1
    // 수직선은 dx 가 0이 되기 때문에 m을 구할 수 없다.
    public class Line
    {
        public double a; // x의 계수
        public double b; // y의 계수
        public double c; // 상수

        public static Line points_to_line(Vertex p1, Vertex p2)
        {
            Line line = new Line();

            if (p1.x == p2.x)
            {
                line.a = 1;
                line.b = 0;
                line.c = -p1.x;
            }
            else
            {
                line.b = 1;
                line.a = -(p1.y - p2.y) / (p1.x - p2.x);
                line.c = -(line.a * p1.x) - (line.b * p1.y);
            }
            return line;
        }

        public static Line point_and_slope_to_line(Vertex p, double m)
        {
            Line line = new Line();
            line.a = -m;
            line.b = 1;
            line.c = -((line.a * p.x) + (line.b * p.y));
            return line;
        }

        public static bool is_parallel(Line l1, Line l2)
        {
            return ((Math.Abs(l1.a - l2.a) <= double.Epsilon) &&
                    (Math.Abs(l1.b - l2.b) <= double.Epsilon));
        }

        public static bool is_same(Line l1, Line l2)
        {
            return (is_parallel(l1, l2) && (Math.Abs(l1.c - l2.c) <= double.Epsilon));
        }

        // 어떤 점(x', y')가 있을 때, y = mx + b 라는 공식의 x 자리에 x'를 대입했을 때 y 값이 y'이 되면,
        // 그 점은 직선 l:y = mx + b 위에 있다고 말할 수 있다.
        // 두 직선 l1: y = m1x + b1과 l2: y = m2x + b2의 교점은 x와 y의 값이 모두 같은 점이다
        //       b2 - b1             b2 - b1
        // x = -----------  y = m1 ----------- + b1
        //       m1 - m2             m1 - m2

        public static bool intersection_point(Line l1, Line l2, ref Vertex p)
        {
            p = new Vertex();

            if (is_same(l1, l2))
            {// 동일한 직선. 교점이 무한하게 많다.
                p.x = p.y = 0;
                return true;
            }

            if (is_parallel(l1, l2) == true)
            {
                // 교점 없다
                return false;
            }

            p.x = (l2.b * l1.c - l1.b * l2.c) / (l2.a * l1.b - l1.a * l2.b);

            if (Math.Abs(l1.b) > double.Epsilon)
                p.y = -(l1.a * (p.x) + l1.c) / l1.b;
            else
                p.y = -(l2.a * (p.x) + l2.c) / l2.b;

            return true;
        }

        public static bool closest_point(Vertex v, Line l, ref Vertex p)
        {

            if (Math.Abs(l.b) <= double.Epsilon) // 수직선
            {
                p = new Vertex
                {
                    x = -(l.c),
                    y = v.y
                };
                return true;
            }

            if (Math.Abs(l.a) <= double.Epsilon) // 수평선
            {
                p = new Vertex
                {
                    x = v.x,
                    y = -(l.c)
                };
                return true;
            }

            // 1과 수직이고 (x, y)를 지나는 직선
            Line perp = point_and_slope_to_line(v, 1 / l.a);
            return intersection_point(l, perp, ref p);
        }

    }
}
