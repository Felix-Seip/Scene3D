using System;

namespace TheMathLibrary.LinearAlgebra.Vectors
{
    public class Vector4D
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }
        public double W { get; private set; }
        public double Magnitude { get; private set; }

        public Vector4D(double x, double y, double z, double xyz)
        {
            X = x;
            Y = y;
            Z = z;
            W = xyz;
        }

        /// <summary>
        /// Returns the product of two 4D vectors.
        /// </summary>
        public static double DotProduct(Vector4D vector1, Vector4D vector2)
        {
            return (vector1.X * vector2.X) + (vector1.Y * vector2.Y) + (vector1.Z * vector2.Z) + (vector1.W * vector2.W);
        }
        /// <summary>
        /// Returns the directional vector between two 4D vectors.
        /// </summary>
        public static Vector4D Subtract(Vector4D vector1, Vector4D vector2)
        {
            return new Vector4D((vector1.X - vector2.X), (vector1.Y - vector2.Y), (vector1.Z - vector2.Z), (vector1.W - vector2.W));
        }
        /// <summary>
        /// Returns the sum of two 4D vectors.
        /// </summary>
        public static Vector4D Add(Vector4D vector1, Vector4D vector2)
        {
            return new Vector4D((vector1.X + vector2.X), (vector1.Y + vector2.Y), (vector1.Z + vector2.Z), (vector1.W + vector2.W));
        }
        /// <summary>
        /// Returns the Length of a 4D vector.
        /// </summary>
        public void CalculateMagnitude()
        {
            Magnitude = Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2) + Math.Pow(W, 2));
        }
        public override string ToString()
        {
            return "|" + X + "|\n|" + Y + "|\n|" + Z + "|\n|" + W + "|\n";
        }

    }
}

