using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoWakim
{
     public class GaussianEliminationSolver : ISolverStrategy
    {
        public double[] Solve(double[,] A, double[] B)
        {
            int n = B.Length;
            double[,] augmentedMatrix = new double[n, n + 1];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    augmentedMatrix[i, j] = A[i, j];
                }
                augmentedMatrix[i, n] = B[i];
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    double ratio = augmentedMatrix[j, i] / augmentedMatrix[i, i];
                    for (int k = 0; k < n + 1; k++)
                    {
                        augmentedMatrix[j, k] -= ratio * augmentedMatrix[i, k];
                    }
                }
            }

            double[] X = new double[n];
            for (int i = n - 1; i >= 0; i--)
            {
                X[i] = augmentedMatrix[i, n];
                for (int j = i + 1; j < n; j++)
                {
                    X[i] -= augmentedMatrix[i, j] * X[j];
                }
                X[i] /= augmentedMatrix[i, i];
            }

            return X;
        }
    }
}