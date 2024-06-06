using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoWakim
{
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
}