using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Math_Library
{
    public class Matrix3X3
    {
        double[][] Matrix;
        public Matrix3X3(double[,] matrix)
        {
            if(matrix.Length != 9)
            {
                Matrix = matrix;
            }
            else
            {
                throw new FormatException("Wrong Format for 3X3 Matrix");
            }
        }

        public static void MultiplicationWithMatrix()
        {

        }

        public static Matrix3X3 MultiplicationWithScalar(Matrix3X3 matrix, double scalar)
        {
            return new Matrix3X3(new double[][] { });
        }

        public static Matrix3X3 MultiplicationWithVector(Matrix3X3 matrix, Vector3D vector)
        {
            double[,] newMultipliedMatrix = new double[3,3];
            for(int i = 0; i < matrix.Matrix.Length; i++)
            {
                for(int j = 0; j < matrix.Matrix[i].Length; j++)
                {

                } 
            }
        }

    }
}
