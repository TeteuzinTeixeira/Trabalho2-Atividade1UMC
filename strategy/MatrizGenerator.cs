using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoWakim
{
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
}