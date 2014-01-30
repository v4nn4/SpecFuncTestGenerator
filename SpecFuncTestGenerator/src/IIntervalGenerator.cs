namespace SpecFuncTestGenerator
{
    public interface IIntervalGenerator
    {
        double[][] Generate(double[] xmin, double[] xmax);
    }

    public class EquiIntervalGenerator : IIntervalGenerator
    {
        private readonly int _n;

        public EquiIntervalGenerator(int n)
        {
            _n = n;
        }

        public double[][] Generate(double[] xmin, double[] xmax)
        {
            var size = xmin.Length;
            var res = new double[size][];
            for (var argIdx = 0; argIdx < xmin.Length;++argIdx )
            {
                var step = (xmax[argIdx] - xmin[argIdx]) / (_n - 1);
                res[argIdx] = new double[_n];
                for (var idx = 0; idx < _n; ++idx)
                {
                    res[argIdx][idx] = xmin[argIdx] + idx * step;
                }
            }
            return res;
        }
    }
}