using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoWakim
{
    public class LUSolver : ISolverStrategy
    {
        public double[] Solve(double[,] A, double[] B)
        {
            int n = B.Length;
            double[,] L = new double[n, n];
            double[,] U = new double[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j < i)
                        L[j, i] = 0;
                    else
                    {
                        L[j, i] = A[j, i];
                        for (int k = 0; k < i; k++)
                            L[j, i] = L[j, i] - L[j, k] * U[k, i];
                    }
                }
                for (int j = 0; j < n; j++)
                {
                    if (j < i)
                        U[i, j] = 0;
                    else if (j == i)
                        U[i, j] = 1;
                    else
                    {
                        U[i, j] = A[i, j] / L[i, i];
                        for (int k = 0; k < i; k++)
                            U[i, j] = U[i, j] - ((L[i, k] * U[k, j]) / L[i, i]);
                    }
                }
            }

            double[] Y = new double[n];
            for (int i = 0; i < n; i++)
            {
                Y[i] = B[i];
                for (int k = 0; k < i; k++)
                {
                    Y[i] -= L[i, k] * Y[k];
                }
                Y[i] /= L[i, i];
            }

            double[] X = new double[n];
            for (int i = n - 1; i >= 0; i--)
            {
                X[i] = Y[i];
                for (int k = i + 1; k < n; k++)
                {
                    X[i] -= U[i, k] * X[k];
                }
            }

            return X;
        }
    }
}