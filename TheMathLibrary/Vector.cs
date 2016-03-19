using System;
namespace TheMathLibrary.LinearAlgebra.Vectors
{
    public class Vector
    {
        /// <summary>
        /// Values in the vector.
        /// </summary>
        public double[] Values;
        /// <summary>
        /// The number of elements in the vector.
        /// </summary>
        public int Size { get; private set; }
        public double Magnitude { get; private set; }

        public Vector(double[] values)
        {
            Values = values;
            Size = values.Length;
            CalculateMagnitude();
        }
        /// <summary>
        /// Returns the length of a vector.
        /// </summary>
        private void CalculateMagnitude()
        {
            double squaredValues = 0;

            for (int i = 0; i < Size; i++)
                squaredValues += Math.Pow(Values[i], 2);

            Math.Sqrt(squaredValues);
        }
        /// <summary>
        /// Returns the dot product of two vectors.
        /// </summary>
        public static double DotProduct(Vector vector1, Vector vector2)
        {
            double dotProduct = 0;
            if (vector1.Size == vector2.Size)
            {
                for(int i = 0; i < vector1.Size; i++)
                {
                    dotProduct += vector1.Values[i] * vector2.Values[i];
                }
            }
            return dotProduct;
        }
        /// <summary>
        /// Returns the sum of two vectors.
        /// </summary>
        public static Vector AdditionWithVector(Vector vector1, Vector vector2)
        {
            double[] addedValues = new double[vector1.Size];
            if (vector1.Size == vector2.Size)
            {
                for (int i = 0; i < vector1.Size; i++)
                {
                    addedValues[i] = vector1.Values[i] + vector2.Values[i];
                }
            }
            return new Vector(addedValues);
        }
        /// <summary>
        /// Returns the directional vector between two vectors.
        /// </summary>
        public static Vector SubtractionWithVector(Vector vector1, Vector vector2)
        {
            double[] subtractedValues = new double[vector1.Size];
            if(vector1.Values.Length == vector2.Size)
            {
                for (int i = 0; i < vector1.Size; i++)
                {
                    subtractedValues[i] = vector1.Values[i] - vector2.Values[i];
                }
            }
            return new Vector(subtractedValues);
        }
        /// <summary>
        /// Returns the product two vectors.
        /// </summary>
        public static Vector MultiplicationWithVector(Vector vector1, Vector vector2)
        {
            double[] multipliedValues = new double[vector1.Size];
            if(vector1.Size == vector2.Size)
            {
                for (int i = 0; i < vector1.Size; i++)
                {
                    multipliedValues[i] = vector1.Values[i] * vector2.Values[i];
                }
            }

            return new Vector(multipliedValues);
        }
        public override string ToString()
        {
            string vectorAsString = "";

            for (int i = 0; i < Values.Length; i++)
                vectorAsString += "|" + Values[i] + "|\n";

            return vectorAsString;
        }
    }
}