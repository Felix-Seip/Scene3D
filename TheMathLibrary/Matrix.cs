using TheMathLibrary.LinearAlgebra.Vectors;

namespace TheMathLibrary.LinearAlgebra.Matrices
{
    public class Matrix
    {
        /// <summary>
        /// Values in the matrix.
        /// </summary>
        public double[][] Values { get; protected set; }
        /// <summary>
        /// Row count of the matrix.
        /// </summary>
        public int RowCount { get; private set; }
        /// <summary>
        /// Column count of the matrix.
        /// </summary>
        public int ColumnCount { get; private set; }
        public bool IsDiagonallyDominant { get; private set; }

        public double this[int i, int j]
        {
            get
            {
                return Values[i][j];
            }
        }

        public Matrix() { }
        public Matrix(double[][] matrix)
        {
            Values = matrix;
            RowCount = matrix.Length;
            ColumnCount = matrix[0].Length;
            CheckDiagonalDominance();
        }
        private void CheckDiagonalDominance()
        { 
            //TODO: Implement diagonal dominance logic
            IsDiagonallyDominant = false;
        }
        /// <summary>
        /// Returns the product of a matrix and a scalar.
        /// </summary>
        public static Matrix MultiplicationWithScalar(Matrix matrix, double scalar)
        {
            double[][] resultingMatrixValues = new double[matrix.RowCount][];
            for (int i = 0; i < resultingMatrixValues.Length; i++)
                resultingMatrixValues[i] = new double[matrix.ColumnCount];

            for(int i = 0; i < matrix.RowCount; i++)
            {
                for(int j = 0; j < matrix.ColumnCount; j++)
                {
                    resultingMatrixValues[i][j] = matrix[i, j] * scalar;
                }
            }
            return new Matrix(resultingMatrixValues);
        }
        /// <summary>
        /// Returns the product of a matrix and a vector.
        /// </summary>
        public static Vector MultiplicationWithVector(Matrix matrix, Vector vector)
        {
            double[] resultingVectorValues = new double[vector.Values.Length];
            
            //Check the needed requirements for a multiplication.
            if (matrix.ColumnCount == vector.Values.Length)
            {
                for(int i = 0; i < matrix.RowCount; i++)
                {
                    for(int j = 0; j < matrix.ColumnCount; j++)
                    {
                        resultingVectorValues[i] += matrix[i, j] * vector[j];
                    }
                }
            }
            return new Vector(resultingVectorValues);
        }
        /// <summary>
        /// Returns the product of a matrix and a 3D vector.
        /// </summary>
        public static Vector3D MultiplicationWithVector3D(Matrix matrix, Vector3D vector)
        {
            //Check the needed requirements for a multiplication.
            if(matrix.Values.Length == 3)
            {
                //Perform the multiplication and return a new 3D vector, since that is the result. 
                return new Vector3D(
                    matrix[0, 0] * vector.X + matrix[0, 1] * vector.Y + matrix[0, 2] * vector.Z,
                    matrix[1, 0] * vector.X + matrix[1, 1] * vector.Y + matrix[1, 2] * vector.Z,
                    matrix[2, 0] * vector.X + matrix[2, 1] * vector.Y + matrix[2, 2] * vector.Z);
            }
            return new Vector3D(0, 0, 0);
        }
        /// <summary>
        /// Returns the product of a matrix and a 4D vector.
        /// </summary>
        public static Vector4D MultiplicationWithVector4D(Matrix matrix, Vector4D vector)
        {
            //Check the needed requirements for a multiplication.
            if (matrix.Values.Length == 4)
            {
                //Perform the multiplication and return a new 4D vector, since that is the result. 
                return new Vector4D(
                    matrix[0, 0] * vector.X + matrix[0, 1] * vector.Y + matrix[0, 2] * vector.Z,
                    matrix[1, 0] * vector.X + matrix[1, 1] * vector.Y + matrix[1, 2] * vector.Z,
                    matrix[2, 0] * vector.X + matrix[2, 1] * vector.Y + matrix[2, 2] * vector.Z,
                    matrix[3, 0] * vector.X + matrix[3, 1] * vector.Y + matrix[3, 2] * vector.Z);
            }
            return new Vector4D(0, 0, 0, 0);
        }
        /// <summary>
        /// Returns the product of two matrices.
        /// </summary>
        public static Matrix MultiplicationWithMatrix(Matrix matrix1, Matrix matrix2)
        {
            double[][] multipliedMatrix = new double[matrix1.RowCount][];

            //Check the needed requirements for a matrix multiplication.
            if (matrix1.ColumnCount == matrix2.RowCount)
            {
                //Set up the new multiplied matrix.
                for (int i = 0; i < multipliedMatrix.Length; i++)
                    multipliedMatrix[i] = new double[matrix2.ColumnCount];

                for (int i = 0; i < matrix1.RowCount; i++)
                {
                    for (int j = 0; j < matrix2.ColumnCount; j++)
                    {
                        for (int k = 0; k < matrix2.ColumnCount - 1; k++)
                        {
                            multipliedMatrix[i][j] += matrix1[i, k] * matrix2[k, j];
                        }
                    }
                }
            }
            return new Matrix(multipliedMatrix);
        }
        /// <summary>
        /// Returns the transposed version of the matrix.
        /// </summary>
        public static Matrix TransposeMatrix(Matrix matrix)
        {
            double[][] transposedMatrixValues = new double[matrix.ColumnCount][];
            for(int i = 0; i < transposedMatrixValues.Length; i++)
                transposedMatrixValues[i] = new double[matrix.RowCount];

            for(int i = 0; i < matrix.ColumnCount; i++)
            {
                for(int j = 0; j < matrix.RowCount; j++)
                {
                    transposedMatrixValues[i][j] = matrix[j, i];
                }
            }
            return new Matrix(transposedMatrixValues);
        }
        public override string ToString()
        {
            string matrixAsString = "";
            for (int i = 0; i < Values.Length; i++)
            {
                for(int j = 0; j < Values[i].Length; j++)
                {
                    matrixAsString += Values[i][j] + "\t";
                }
                matrixAsString += "\n";
            }
            return matrixAsString;
        }

    }
}
