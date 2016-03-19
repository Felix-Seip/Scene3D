using System;

namespace TheMathLibrary.LinearAlgebra.Vectors
{
    public class Vector3D
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }
        public double Magnitude { get; private set; }

        public Vector3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
            CalculateMagnitude();
        }
        /// <summary>
        /// Returns the product of two 3D vectors.
        /// </summary>
        public static double DotProduct(Vector3D vector1, Vector3D vector2)
        {
            return (vector1.X * vector2.X) + (vector1.Y * vector2.Y) + (vector1.Z * vector2.Z);
        }
        /// <summary>
        /// Returns the directional vector between two vectors.
        /// </summary>
        public static Vector3D SubtractWithVector3D(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D((vector1.X - vector2.X), (vector1.Y - vector2.Y), (vector1.Z - vector2.Z));
        }
        /// <summary>
        /// Returns the sum of two 3D vectors.
        /// </summary>
        public static Vector3D AdditionWithVector3D(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D((vector1.X + vector2.X), (vector1.Y + vector2.Y), (vector1.Z + vector2.Z));
        }
        /// <summary>
        /// Returns the Length of a 3D vector.
        /// </summary>
        private void CalculateMagnitude()
        {
            Magnitude = Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2));
        }
        /// <summary>
        /// Returns the cross product of two 3D vectors.
        /// </summary>
        public static Vector3D CrossProduct(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D
                ((vector1.Y * vector2.Z) - (vector1.Z * vector2.Y), 
                (vector1.Z * vector2.X) - (vector1.X * vector2.Z), 
                (vector1.X * vector2.Y) - (vector1.Y * vector2.X));
        }
        public override string ToString()
        {
            return  "|" + X + "|\n|" + Y + "|\n|" + Z + "|\n";
        }

    }

}
