using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoWakim
{
   public class JacobiSolver : ISolverStrategy
    {
        public double[] Solve(double[,] A, double[] B)
        {
            int n = B.Length;
            double[] X = new double[n];
            double[] X_old = new double[n];
            double tolerance = 1e-10;
            int maxIterations = 1000;

            for (int k = 0; k < maxIterations; k++)
            {
                Array.Copy(X, X_old, n);

                for (int i = 0; i < n; i++)
                {
                    double sum = B[i];
                    for (int j = 0; j < n; j++)
                    {
                        if (i != j)
                            sum -= A[i, j] * X_old[j];
                    }
                    X[i] = sum / A[i, i];
                }

                double error = 0.0;
                for (int i = 0; i < n; i++)
                {
                    error += Math.Abs(X[i] - X_old[i]);
                }

                if (error < tolerance)
                    break;
            }

            return X;
        }
    }
}
