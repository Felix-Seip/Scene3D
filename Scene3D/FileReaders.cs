using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using TheMathLibrary.Geometry.Shapes;
using TheMathLibrary.LinearAlgebra.Vectors;

namespace Scene3D
{
    public class FileReaders
    {
        public static List<Triangle> ReadOBJFile(string fileName)
        {
            List<Triangle> ListOfThreeDimensionalPoints = new List<Triangle>();
            List<Vector3D> points = new List<Vector3D>();
            try
            {
                Regex findAllTrianglePoints = new Regex(@"[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?");

                string[] triangles = File.ReadAllLines(fileName);
                triangles[0] = "";
                for (int i = 0; i < triangles.Length; i++)
                {
                    string triangle = triangles[i];
                    if (triangle.Contains("v") && !triangle.Contains("vt") && !triangle.Contains("vn"))
                    {
                        MatchCollection foundTrianglePoints = findAllTrianglePoints.Matches(triangle);

                        for (int j = 0; j <= foundTrianglePoints.Count; j += 3)
                        {
                            if (j == 3 || j == 6 || j == 9)
                            {
                                Vector3D point = new Vector3D(double.Parse(foundTrianglePoints[j - 1].ToString(), CultureInfo.InvariantCulture), double.Parse(foundTrianglePoints[j - 2].ToString(), CultureInfo.InvariantCulture), double.Parse(foundTrianglePoints[j - 3].ToString(), CultureInfo.InvariantCulture));
                                points.Add(point);
                            }
                        }
                        triangles[i] = "";
                    }
                }

                for (int i = 0; i < triangles.Length; i++)
                {
                    string triangle = triangles[i];
                    if (triangle.Contains("f"))
                    {
                        MatchCollection foundTrianglePoints = findAllTrianglePoints.Matches(triangle);

                        for (int j = 0; j <= foundTrianglePoints.Count; j += 3)
                        {
                            if (j == 3 || j == 6 || j == 9)
                            {
                                Vector3D point = new Vector3D(double.Parse(foundTrianglePoints[j - 3].ToString(), CultureInfo.InvariantCulture), double.Parse(foundTrianglePoints[j - 2].ToString(), CultureInfo.InvariantCulture), double.Parse(foundTrianglePoints[j - 1].ToString(), CultureInfo.InvariantCulture));
                                ListOfThreeDimensionalPoints.Add(new Triangle(points[(int)point.X - 1], points[(int)point.Y - 1], points[(int)point.Z - 1]));
                            }
                        }
                        triangles[i] = "";
                    }
                }
            }
            catch (Exception ex)
            {
            }
            //MessageBox.Show("Done!");
            return ListOfThreeDimensionalPoints;
        }

        public static List<Triangle> ReadINCFile(string fileName)
        {
            List<Triangle> ListOfThreeDimensionalPoints = new List<Triangle>();
            List<Vector3D> points = new List<Vector3D>();
            try
            {
                Regex findAllTrianglePoints = new Regex(@"[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?");

                string[] triangles = File.ReadAllLines(fileName);
                for (int i = 0; i < triangles.Length; i++)
                {
                    string triangle = triangles[i];

                    MatchCollection foundTrianglePoints = findAllTrianglePoints.Matches(triangle);

                    for (int j = 0; j <= foundTrianglePoints.Count; j += 3)
                    {
                        if (j == 3 || j == 6 || j == 9)
                        {
                            Vector3D point = new Vector3D(double.Parse(foundTrianglePoints[j - 1].ToString(), CultureInfo.InvariantCulture), double.Parse(foundTrianglePoints[j - 2].ToString(), CultureInfo.InvariantCulture), double.Parse(foundTrianglePoints[j - 3].ToString(), CultureInfo.InvariantCulture));
                            points.Add(point);
                        }
                        
                    }
                }

                for(int i = 0; i < points.Count; i++)
                {
                    if (i % 3 == 0 && i != 0)
                        ListOfThreeDimensionalPoints.Add(new Triangle(points[i], points[i - 1], points[i - 2]));
                }
            }
            catch (Exception ex)
            {
            }

            return ListOfThreeDimensionalPoints;
        }

    }
}
