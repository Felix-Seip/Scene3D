using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Math_Library
{
    public class Vector3D
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }

        public Vector3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static double DotProduct(Vector3D vector1, Vector3D vector2)
        {
            return (vector1.X * vector2.X) + (vector1.Y * vector2.Y) + (vector1.Z * vector2.Z);
        }

        /// <summary>
        /// Can be used to find directional vectors
        /// </summary>
        public static Vector3D Subtract(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D((vector1.X - vector2.X), (vector1.Y - vector2.Y), (vector1.Z - vector2.Z));
        }

        public static Vector3D Add(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D((vector1.X + vector2.X), (vector1.Y + vector2.Y), (vector1.Z + vector2.Z));
        }

        public static double Length(Vector3D vector)
        {
            return Math.Sqrt(Math.Pow(vector.X, 2) + Math.Pow(vector.Y, 2) + Math.Pow(vector.Z, 2));
        }
    }
}
