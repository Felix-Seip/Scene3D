using System;
using TheMathLibrary.LinearAlgebra.Matrices;
using TheMathLibrary.LinearAlgebra.Vectors;

namespace TheMathLibrary.Methods
{
    public class GaussSeidelMethod
    {
        public static void Solve(Matrix inputMatrix, Vector expectedOutcome, int iterations = 20, int accuracy = 3)
        {
            //TODO: Implement Logic for Gauss Seidel Method

            //// Validation omitted
            //var x = expectedOutcome;
            //double delta;

            //// Gauss-Seidel with Successive OverRelaxation Solver
            //for (int k = 0; k < iterations; ++k)
            //{
            //    for (int i = 0; i < expectedOutcome.vectorValues.Length; ++i)
            //    {
            //        delta = 0.0f;

            //        for (int j = 0; j < i; ++j)
            //            delta += inputMatrix._matrix[i][j] * x.vectorValues[j];
            //        for (int j = i + 1; j < expectedOutcome.vectorValues.Length; ++j)
            //            delta += inputMatrix._matrix[i][j] * x.vectorValues[j];

            //        delta = (expectedOutcome.vectorValues[i] - delta) / inputMatrix._matrix[i][i];
            //        x.vectorValues[i] += 2 * (delta - x.vectorValues[i]);
            //    }
            //    Console.WriteLine(x.ToString());
            //}
        }
    }
}
