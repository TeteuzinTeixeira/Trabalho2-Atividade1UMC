using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoWakim
{
    public interface ISolverStrategy
    {
        double[] Solve(double[,] A, double[] B);
    }
}