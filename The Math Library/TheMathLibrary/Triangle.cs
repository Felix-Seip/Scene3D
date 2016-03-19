using TheMathLibrary.LinearAlgebra.Vectors;

namespace TheMathLibrary.Geometry.Shapes
{
    public class Triangle
    {
        public Vector3D point1 { get; private set; }
        public Vector3D point2 { get; private set; }
        public Vector3D point3 { get; private set; }

        public Triangle(Vector3D vector1, Vector3D vector2, Vector3D vector3)
        {
            this.point1 = vector1;
            this.point2 = vector2;
            this.point3 = vector3;
        }
    }
}
