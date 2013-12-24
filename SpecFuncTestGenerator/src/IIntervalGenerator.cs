using System;

namespace SpecFuncTestGenerator
{
    public interface IIntervalGenerator
    {
        double[] Generate(double xmin, double xmax);
    }

    public class EquiIntervalGenerator : IIntervalGenerator
    {
        private readonly double _step;

        public EquiIntervalGenerator(double step)
        {
            _step = step;
        }

        public double[] Generate(double xmin, double xmax)
        {
            var n = Convert.ToInt16((xmax - xmin)/_step);
            var res = new double[n+1];
            for(var i=0;i<n+1;++i)
            {
                res[i] = xmin + i*_step;
            }
            return res;
        }
    }
}