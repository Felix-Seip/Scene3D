using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Shapes;
using TheMathLibrary.Basics;
using TheMathLibrary.Geometry.Shapes;
using TheMathLibrary.LinearAlgebra.Matrices;
using TheMathLibrary.LinearAlgebra.Vectors;

namespace Scene3D
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Triangle> ChangedThreeDimensionalTriangles = new List<Triangle>();
        private List<Triangle> UnChangedThreeDimensionalTriangles = new List<Triangle>();
        private List<Triangle> TempListOfThreeDimensionalPoints = new List<Triangle>();
        private List<Vector3D> listCrosses = new List<Vector3D>();
        private List<double> listScalarProducts = new List<double>();
        private Polygon objectPolygon;
        private Vector3D camera = new Vector3D(0, 0, -10);
        private int _scrollVariable = 50;

        //Used to store the 3D object files that are required since the resources are converted to bytes. 
        private static string tempFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Berufsschule\Scene3D";
        private Brush objectColor = Brushes.Gray;

        public MainWindow()
        {
            InitializeComponent();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            if (!Directory.Exists(tempFilePath))
                Directory.CreateDirectory(tempFilePath);

            Render(Properties.Resources.Cube3D, ".obj");
        }

        /// <summary>
        /// Calculates the normal vectors of the triangles.
        /// Based on the normal vectors, the corresponding sides are shown.
        /// </summary>
        private void CalculateSidesShown()
        {
            listCrosses.Clear();
            listScalarProducts.Clear();
            for (int i = 0; i < UnChangedThreeDimensionalTriangles.Count; i++)
            {
                //Calculate the normal vectors needed later on.
                Vector3D v = Vector3D.SubtractWithVector3D(UnChangedThreeDimensionalTriangles[i].point2, UnChangedThreeDimensionalTriangles[i].point1);
                Vector3D v1 = Vector3D.SubtractWithVector3D(UnChangedThreeDimensionalTriangles[i].point3, UnChangedThreeDimensionalTriangles[i].point2);
                listCrosses.Add(Vector3D.CrossProduct(v, v1));
            }

            for (int i = 0; i < listCrosses.Count; i++)
                listScalarProducts.Add(Vector3D.DotProduct(camera, listCrosses[i]));

        }

        /// <summary>
        /// Convert the 3D points to 2D screen coordinates
        /// </summary>
        private void Convert3DTo2D()
        {
            ChangedThreeDimensionalTriangles.Clear();
            ProjectionsMatrix projectionsMatrix = new ProjectionsMatrix();
            for (int i = 0; i < UnChangedThreeDimensionalTriangles.Count; i++)
            {
                Vector4D v = TheMathLibrary.LinearAlgebra.Matrices.Matrix.MultiplicationWithVector4D(projectionsMatrix, new Vector4D(UnChangedThreeDimensionalTriangles[i].point1.X, UnChangedThreeDimensionalTriangles[i].point1.Y, UnChangedThreeDimensionalTriangles[i].point1.Z, 1));
                Vector4D v1 = TheMathLibrary.LinearAlgebra.Matrices.Matrix.MultiplicationWithVector4D(projectionsMatrix, new Vector4D(UnChangedThreeDimensionalTriangles[i].point2.X, UnChangedThreeDimensionalTriangles[i].point2.Y, UnChangedThreeDimensionalTriangles[i].point2.Z, 1));
                Vector4D v2 = TheMathLibrary.LinearAlgebra.Matrices.Matrix.MultiplicationWithVector4D(projectionsMatrix, new Vector4D(UnChangedThreeDimensionalTriangles[i].point3.X, UnChangedThreeDimensionalTriangles[i].point3.Y, UnChangedThreeDimensionalTriangles[i].point3.Z, 1));

                ChangedThreeDimensionalTriangles.Add(new Triangle(new Vector3D(v.X, v.Y, v.Z), new Vector3D(v1.X, v1.Y, v1.Z), new Vector3D(v2.X, v2.Y, v2.Z)));
            }
        }

        /// <summary>
        /// Draw the 2D coordinates on the screen.
        /// </summary>
        private void Draw()
        {
            if (myCanvas.Children.Count != 0)
                myCanvas.Children.Clear();

            PointCollection pc = new PointCollection();

            for (int i = 0; i < ChangedThreeDimensionalTriangles.Count; i++)
            {
                if (listScalarProducts[i] < 0)
                {
                    //Add the points of the triangles to the point collection for the polygon.
                    //Multiply by the scroll variable for zooming.
                    pc.Add(new Point(ChangedThreeDimensionalTriangles[i].point1.X * _scrollVariable, ChangedThreeDimensionalTriangles[i].point1.Y * _scrollVariable));
                    pc.Add(new Point(ChangedThreeDimensionalTriangles[i].point2.X * _scrollVariable, ChangedThreeDimensionalTriangles[i].point2.Y * _scrollVariable));
                    pc.Add(new Point(ChangedThreeDimensionalTriangles[i].point3.X * _scrollVariable, ChangedThreeDimensionalTriangles[i].point3.Y * _scrollVariable));
                }
            }

            objectPolygon = new Polygon();
            objectPolygon.Points = pc;
            objectPolygon.Stroke = objectColor;

            //Add the completed polygon to the canvas.
            myCanvas.Children.Add(objectPolygon);
        }

        private void Render(byte[] fileObject, string fileExtension)  
        {
            myCanvas.Children.Clear();
            UnChangedThreeDimensionalTriangles.Clear();

            //Create temporary file from the resource file which contains bytes.
            File.WriteAllBytes(tempFilePath + @"\tempOBJFile" + fileExtension, fileObject);

            //Read the temporary file since it contains the points of the Cube.
            UnChangedThreeDimensionalTriangles = FileReaders.ReadOBJFile(tempFilePath + @"\tempOBJFile" + fileExtension);
            CalculateSidesShown();
            Convert3DTo2D();
            Draw();

            //Delete the temporary file since it is no longer needed.
            File.Delete(tempFilePath + @"\tempOBJFile" + fileExtension);
        }

        private void OnZoom(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            int mouseScrollDirection = e.Delta;

            //If the mouseScrollDirection is negative, zoom out.
            if (mouseScrollDirection < 0)
                _scrollVariable -= 10;
            //Else zoom in.
            else
                _scrollVariable += 10;
            Convert3DTo2D();
            Draw();
        }

        private void XAxisRotation_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double degrees;
            if (e.OldValue < e.NewValue)
                degrees = e.NewValue;
            else
                degrees = -e.NewValue;

            RotationsMatrix rotationsMatrix = new RotationsMatrix((int)RotationsMatrix.MatrixType.XAxis, Basics.DegreesToRadians(degrees));
            //Recalculate the points by multiplying the old points with a rotations matrix.
            UnChangedThreeDimensionalTriangles = Transformations.RotationAroundOrigin(rotationsMatrix, UnChangedThreeDimensionalTriangles);

            CalculateSidesShown();
            Convert3DTo2D();
            Draw();
        }

        private void YAxisRotation_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double degrees;
            if (e.OldValue < e.NewValue)
                degrees = e.NewValue;
            else
                degrees = -e.NewValue;

            RotationsMatrix rotationsMatrix = new RotationsMatrix((int)RotationsMatrix.MatrixType.YAxis, Basics.DegreesToRadians(degrees));
            //Recalculate the points by multiplying the old points with a rotations matrix.
            UnChangedThreeDimensionalTriangles = Transformations.RotationAroundOrigin(rotationsMatrix, UnChangedThreeDimensionalTriangles);

            CalculateSidesShown();
            Convert3DTo2D();
            Draw();
        }

        private void ZAxisRotation_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double degrees;
            if (e.OldValue < e.NewValue)
                degrees = e.NewValue;
            else
                degrees = -e.NewValue;

            RotationsMatrix rotationsMatrix = new RotationsMatrix((int)RotationsMatrix.MatrixType.ZAxis, Basics.DegreesToRadians(degrees));
            //Recalculate the points by multiplying the old points with a rotations matrix.
            UnChangedThreeDimensionalTriangles = Transformations.RotationAroundOrigin(rotationsMatrix, UnChangedThreeDimensionalTriangles);

            CalculateSidesShown();
            Convert3DTo2D();
            Draw();
        }

        #region MenuItem Events
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //Create new OpenFileDialog to let the user select a .obj or .inc file.
            Microsoft.Win32.OpenFileDialog filePick = new Microsoft.Win32.OpenFileDialog();
            filePick.Filter = "OBJ Files(*.obj)|*.obj|INC Files(*.inc)|*.inc";
            filePick.ShowDialog();
            FileInfo selectedFile = null;

            try
            {
                //Retrieve the path of the selected file
                selectedFile = new FileInfo(filePick.FileName);
            }
            catch (Exception ex)
            {
            }

            //Since the file formats have different object structures, 
            //the right method needs to be called to read the points that are in the file.
            if (selectedFile != null && selectedFile.Extension == ".obj")
            {
                myCanvas.Children.Clear();
                UnChangedThreeDimensionalTriangles.Clear();
                UnChangedThreeDimensionalTriangles = FileReaders.ReadOBJFile(selectedFile.FullName);
            }
            else if (selectedFile != null && selectedFile.Extension == ".inc")
            {
                myCanvas.Children.Clear();
                UnChangedThreeDimensionalTriangles.Clear();
                UnChangedThreeDimensionalTriangles = FileReaders.ReadINCFile(selectedFile.FullName);
            }

            CalculateSidesShown();
            Convert3DTo2D();
            Draw();
        }

        private void CubeObjectMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Render(Properties.Resources.Cube3D, ".obj");
        }

        private void SphereObjectMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Render(Properties.Resources.Sphere3D, ".obj");
        }

        private void CylinderObjectMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Render(Properties.Resources.Cylinder3D, ".obj");
        }

        private void ConeObjectMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Render(Properties.Resources.Cone3D, ".obj");
        }

        private void GearObjectMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Render(Properties.Resources.TestRad, ".inc");
        }

        private void ColorPickerMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //Create new ColorDialog
            ColorDialog colorPickerDialog = new ColorDialog();

            //Get the dialog result of the ColorDialog. 
            DialogResult dialogresult = colorPickerDialog.ShowDialog();

            //Get the color the user picked.
            System.Drawing.Color pickedColor = colorPickerDialog.Color;

            //Only if the user pressed OK, set the objectColor to the color the user chose.
            if (dialogresult == System.Windows.Forms.DialogResult.OK)
            {
                objectColor = new SolidColorBrush(Color.FromArgb(pickedColor.A, pickedColor.R, pickedColor.G, pickedColor.B));

                //Redraw the object since the color has changed.
                Draw();
            }
        }

        private void AboutDialog_Click(object sender, RoutedEventArgs e)
        {
            //Create a new AboutDialog.
            AboutDialog myAboutDialog = new AboutDialog();

            //Set the owner of the AboutDialog to the current open dialog
            myAboutDialog.Owner = this;

            //Show the AboutDialog.
            myAboutDialog.ShowDialog();
        }
        #endregion
    }
}
