using System;

namespace TheMathLibrary.LinearAlgebra.Vectors
{
    public class Vector2D
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Magnitude { get; private set; }
        
        public Vector2D(double x, double y)
        {
            X = x;
            Y = y;
            CalculateMagnitude();
        }
        /// <summary>
        /// Returns the product of two 2D vectors.
        /// </summary>
        public static double DotProduct(Vector2D vector1, Vector2D vector2)
        {
            return (vector1.X * vector2.X) + (vector1.Y * vector2.Y);
        }
        /// <summary>
        /// Returns the directional vector between two 2D vectors.
        /// </summary>
        public static Vector2D SubtractionWithVector2D(Vector2D vector1, Vector2D vector2)
        {
            return new Vector2D((vector1.X - vector2.X), (vector1.Y - vector2.Y));
        }
        /// <summary>
        /// Returns the sum of two 2D vectors.
        /// </summary>
        public static Vector2D AdditionWithVector2D(Vector2D vector1, Vector2D vector2)
        {
            return new Vector2D((vector1.X + vector2.X), (vector1.Y + vector2.Y));
        }
        /// <summary>
        /// Returns the length of a 2D vector.
        /// </summary>
        private void CalculateMagnitude()
        {
            Magnitude = Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
        }
        public override string ToString()
        {
            return "|" + X + "|\n|" + Y + "|\n";
        }

    }
}
