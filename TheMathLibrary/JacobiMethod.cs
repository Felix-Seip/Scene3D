using System;
using TheMathLibrary.LinearAlgebra.Matrices;
using TheMathLibrary.LinearAlgebra.Vectors;

namespace TheMathLibrary.Methods
{
    public class JacobiMethod
    {
        /// <summary>
        /// Solves a linear system of equations using the Jacobi Method.
        /// </summary>
        public static Vector Solve(Matrix inputMatrix, Vector expectedOutcome, int iterations = 20, int accuracy = 3)
        {
            Vector solvedVector = new Vector(new double[inputMatrix.ColumnCount]);
            Vector previousVector = new Vector(new double[inputMatrix.ColumnCount]);

            //Loop through the amount of iterations
            for (int k = 0; k < iterations; k++)
            {
                //Loop through the matrices rows
                for (int i = 0; i < inputMatrix.RowCount; i++)
                {
                    double sigma = 0;
                    //Loop through the matrices columns
                    for (int j = 0; j < inputMatrix.ColumnCount; j++)
                    {
                        if (j != i)
                            sigma += inputMatrix[i, j] * solvedVector[j];
                    }
                    solvedVector.Values[i] = Math.Round((expectedOutcome[i] - sigma) / inputMatrix[i, i], accuracy);
                }
                Console.WriteLine("Step #" + k + ": \n" + solvedVector.ToString());
                if (CheckConvergence(solvedVector, previousVector))
                    return solvedVector;

                for(int i = 0; i < solvedVector.Values.Length; i++)
                    previousVector.Values[i] = solvedVector[i];
            }
            return solvedVector;
        }

        private static bool CheckConvergence(Vector currentVector, Vector previousVector)
        {
            int numberOfSameValues = 0;
            if (previousVector != null)
            {
                for (int i = 0; i < currentVector.Values.Length; i++)
                {
                    if (currentVector.Values[i] == previousVector[i])
                        numberOfSameValues++;
                }
            }

            //If all three values are the same, then the method is converging.
            if (numberOfSameValues == currentVector.Values.Length)
                return true;
            
            return false;
        }

    }
}
