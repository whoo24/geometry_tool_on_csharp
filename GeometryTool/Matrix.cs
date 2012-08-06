using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeometryTool
{
    class Matrix
    {
        double[,] m_m = new double[3,3];

        public void SetScale(double sx, double sy, double sz)
        {
            m_m[0,0] = sx;
            m_m[1,1] = sy;
            m_m[2,2] = sz;
        }

        public Vector RowToVec(int row_index)
        {
            return new Vector { X = m_m[row_index, 0], Y = m_m[row_index, 1], Z = m_m[row_index, 2] };
        }

        public void VecToRow(int row_index, Vector v)
        {
            m_m[row_index, 0] = v.X;
            m_m[row_index, 1] = v.Y;
            m_m[row_index, 2] = v.Z;
        }

        public static Matrix Multiply(Matrix a, Matrix b)
        {
            Matrix r = new Matrix();

            r.VecToRow(0, Matrix.Multiply(a, b.RowToVec(0)));
            r.VecToRow(1, Matrix.Multiply(a, b.RowToVec(1)));
            r.VecToRow(2, Matrix.Multiply(a, b.RowToVec(2)));

            return r;
        }

        public static Vector Multiply(Matrix m, Vector v)
        {
            Vector r = new Vector{
                X = (m.m_m[0, 0] * v.X) + (m.m_m[0, 1] * v.Y) + (m.m_m[0, 2] * v.Z),
                Y = (m.m_m[1, 0] * v.X) + (m.m_m[1, 1] * v.Y) + (m.m_m[1, 2] * v.Z),
                Z = (m.m_m[2, 0] * v.X) + (m.m_m[2, 1] * v.Y) + (m.m_m[2, 2] * v.Z),
            };

            return r;
        }

        
    }
}

