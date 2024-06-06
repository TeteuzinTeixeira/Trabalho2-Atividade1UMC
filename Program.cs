using System;

namespace TrabalhoWakim
{
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
