using System.Collections.Generic;
using TheMathLibrary.Geometry.Shapes;
using TheMathLibrary.LinearAlgebra.Vectors;

namespace TheMathLibrary.LinearAlgebra.Matrices
{
    public class Transformations
    {

        /// <summary>
        /// Moves each point to the new X and Y coordinates
        /// </summary>
        public static List<Vector3D> Translation(Matrix matrix, List<Vector3D> originalPoints)
        {
            List<Vector3D> newPoints = new List<Vector3D>();
            for (int i = 0; i < originalPoints.Count; i++)
            {
                Vector3D newPointPosition = Matrix.MultiplicationWithVector3D(matrix, originalPoints[i]);
                newPoints.Add(newPointPosition);
            }
            return newPoints;
        }

        /// <summary>
        /// Rotates all points around the origin.
        /// Then returns the new rotated points
        /// </summary>
        public static List<Triangle> RotationAroundOrigin(Matrix matrix, List<Triangle> originalPoints)
        {
            List<Triangle> newPoints = new List<Triangle>();
            for (int i = 0; i < originalPoints.Count; i++)
            {
                Triangle newPointPosition = new Triangle(
                    Matrix.MultiplicationWithVector3D(matrix, originalPoints[i].point1),
                    Matrix.MultiplicationWithVector3D(matrix, originalPoints[i].point2),
                    Matrix.MultiplicationWithVector3D(matrix, originalPoints[i].point3));
                newPoints.Add(newPointPosition);
            }

            return newPoints;
        }

        public static List<Vector3D> RotationAroundPoint(Matrix matrix, List<Vector3D> originalPoints)
        {
            List<Vector3D> newPoints = new List<Vector3D>();
            for (int i = 0; i < originalPoints.Count; i++)
            {
                Vector3D newPointPosition = Matrix.MultiplicationWithVector3D(matrix, originalPoints[i]);
                newPoints.Add(newPointPosition);
            }

            return newPoints;
        }
    }
}
