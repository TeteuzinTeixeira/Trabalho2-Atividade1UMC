using System;

namespace LinearEquationSolver
{
    public interface ISolverStrategy
    {
        double[] Solve(double[,] A, double[] B);
    }

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

    public class MatrixGenerator
    {
        private static Random random = new Random();

        public static double[,] GenerateMatrix(int size)
        {
            double[,] matrix = new double[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = random.NextDouble() * 10;
                }
            }
            return matrix;
        }

        public static double[] GenerateVector(int size)
        {
            double[] vector = new double[size];
            for (int i = 0; i < size; i++)
            {
                vector[i] = random.NextDouble() * 10;
            }
            return vector;
        }
    }

    public class SolverContext
    {
        private ISolverStrategy? _strategy;

        public void SetStrategy(ISolverStrategy strategy)
        {
            _strategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
        }

        public double[] Solve(double[,] A, double[] B)
        {
            if (_strategy == null)
                throw new InvalidOperationException("Strategy not set");

            return _strategy.Solve(A, B);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int size = 3; // Tamanho da matriz
            double[,] A = MatrixGenerator.GenerateMatrix(size);
            double[] B = MatrixGenerator.GenerateVector(size);

            SolverContext context = new SolverContext();

            // Solução usando Eliminação Gaussiana
            context.SetStrategy(new GaussianEliminationSolver());
            double[] X1 = context.Solve(A, B);
            Console.WriteLine("Solução usando Eliminação Gaussiana:");
            PrintVector(X1);

            // Solução usando Decomposição LU
            context.SetStrategy(new LUSolver());
            double[] X2 = context.Solve(A, B);
            Console.WriteLine("Solução usando Decomposição LU:");
            PrintVector(X2);

            // Solução usando Iteração de Jacobi
            context.SetStrategy(new JacobiSolver());
            double[] X3 = context.Solve(A, B);
            Console.WriteLine("Solução usando Iteração de Jacobi:");
            PrintVector(X3);
        }

        static void PrintVector(double[] vector)
        {
            foreach (var value in vector)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
        }
    }
}
