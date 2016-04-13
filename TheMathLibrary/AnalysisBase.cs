using TheMathLibrary.LinearAlgebra.Vectors;

namespace TheMathLibrary.Analysis
{
    public class AnalysisBase
    {
        /// <summary>
        /// Calculates the derivation of a simple polynomial function.
        /// </summary>
        public static string FunctionDerivation(Vector coefficients, Vector exponents, int derivationLevel)
        {
            Vector derivation = new Vector(new double[coefficients.Values.Length]);
            string derivedExpression = "";

            for (int i = 0; i < derivationLevel; i++)
            {
                for(int j = 0; j < coefficients.Values.Length; j++)
                {
                    if(i == 0)
                        derivation.Values[j] += exponents.Values[j] * coefficients.Values[j];
                    else
                        derivation.Values[j] = exponents.Values[j] * derivation.Values[j];

                    //Decrease the exponent by one after the multiplication.
                    if (exponents.Values[j] != 0)
                        exponents.Values[j]--;
                }
            }

            for(int i = 0; i < coefficients.Values.Length; i++)
            {
                //if (exponents.vectorValues[i] == 0)
                //    derivation.vectorValues[i] = 1;
                if(i != coefficients.Values.Length-1)
                    derivedExpression += derivation.Values[i] + "x^" + exponents.Values[i] + " + ";
                else
                    derivedExpression += derivation.Values[i] + "x^" + exponents.Values[i] ;
            }
            return derivedExpression;
        }
    }
}
