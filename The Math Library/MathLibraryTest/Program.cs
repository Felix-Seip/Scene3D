using System;
using System.IO;
using TheMathLibrary;
using TheMathLibrary.Methods;
using TheMathLibrary.LinearAlgebra.Matrices;
using TheMathLibrary.LinearAlgebra.Vectors;
using TheMathLibrary.Analysis;

namespace MathLibraryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            double[][] m = new double[3][];
            m[0] = new double[4];
            m[1] = new double[4];
            m[2] = new double[4];

            m[0][0] = 7;
            m[0][1] = 4;
            m[0][2] = 3;
            m[0][3] = 5;

            m[1][0] = 1;
            m[1][1] = 0;
            m[1][2] = 7;
            m[1][3] = 6;

            m[2][0] = 4;
            m[2][1] = 2;
            m[2][2] = 9;
            m[2][3] = 8;

            Matrix inputMatrix = new Matrix(m);
            //Vector inputVector = new Vector(new double[] { 2, 3, 1 });

            //Console.WriteLine(Matrix.MultiplicationWithVector(inputMatrix, inputVector).ToString());
            //GaussSeidelMethod.Solve(inputMatrix, inputVector, 50, 3
            Console.WriteLine(AnalysisBase.FunctionDerivation(new Vector(new double[] { 3, 2, 1 }), new Vector(new double[] { 5, 4, 3 }), 2));
            //Console.WriteLine("Input Matrix:\n" + inputMatrix.ToString());
            //Console.WriteLine("Transposed Matrix:\n" + Matrix.TransposeMatrix(inputMatrix).ToString());
            Console.ReadKey();

        }
    }
}
