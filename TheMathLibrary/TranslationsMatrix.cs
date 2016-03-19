namespace TheMathLibrary.LinearAlgebra.Matrices
{
    public class TranslationsMatrix : Matrix
    {
        ///// <summary>
        ///// Creates a translation matrix
        ///// </summary>
        public TranslationsMatrix(double X, double Y)
        {
            Values = new double[3][];
            Values[0] = new double[] { 1, 0, X }; 
            Values[1] = new double[] { 0, 1, Y };
            Values[2] = new double[] { 0, 0, 1 };
        }
    }
}
