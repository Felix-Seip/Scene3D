using System;
namespace TheMathLibrary.LinearAlgebra.Matrices
{
    public class RotationsMatrix : Matrix
    {
        public enum MatrixType
        {
            OriginAxis = 0,
            XAxis = 1,
            YAxis = 2,
            ZAxis = 3
        }

        /// <summary>
        /// Creates a new rotations matrix. 
        /// </summary>
        public RotationsMatrix(int type, double angle)
        {
            angle = Basics.Basics.DegreesToRadians(angle);

            //Set the matrix to the corresponding special matrices.
            if (type == (int)MatrixType.OriginAxis)
            {
                Values = new double[3][];
                Values[0] = new double[] { Math.Cos(angle), -Math.Sin(angle), 0 };
                Values[1] = new double[] { Math.Sin(angle), Math.Cos(angle), 0 };
                Values[2] = new double[] { 0, 0, 1 };
            }
            else if (type == (int)MatrixType.XAxis)
            {
                Values = new double[3][];
                Values[0] = new double[] { 1, 0, 0 };
                Values[1] = new double[] { 0, Math.Cos(angle), -Math.Sin(angle) };
                Values[2] = new double[] { 0, Math.Sin(angle), Math.Cos(angle) };
            }
            else if (type == (int)MatrixType.YAxis)
            {
                Values = new double[3][];
                Values[0] = new double[] { Math.Cos(angle), 0, Math.Sin(angle) };
                Values[1] = new double[] { 0, 1, 0 };
                Values[2] = new double[] { -Math.Sin(angle), 0, Math.Cos(angle) };
            }
            else if (type == (int)MatrixType.ZAxis)
            {
                Values = new double[3][];
                Values[0] = new double[] { Math.Cos(angle), -Math.Sin(angle), 0 };
                Values[1] = new double[] { Math.Sin(angle), Math.Cos(angle), 0 };
                Values[2] = new double[] { 0, 0, 1 };
            }
        }

    }
}
