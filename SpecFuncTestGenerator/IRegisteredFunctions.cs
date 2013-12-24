using System;
using System.Collections.Generic;

namespace SpecFuncTestGenerator
{
    public interface IRegisteredFunctions
    {
        List<Tuple<string, int, int>> GetRegisteredFunctions();
    }

    public class HardCodedFunctions : IRegisteredFunctions
    {
        public static List<Tuple<string, int, int>> RegisteredFunctions = new List<Tuple<string, int, int>>
                                                                         {
                                                                             /* Probabilities */
                                                                             new Tuple<string, int, int>("cdf_normal", 1, 2),
                                                                             new Tuple<string, int, int>("cdf_student_t", 1, 1),
                                                                             new Tuple<string, int, int>("cdf_chi2", 1, 1),
                                                                             new Tuple<string, int, int>("cdf_noncentral_chi2l", 1, 2),
                                                                             new Tuple<string, int, int>("cdf_exp", 1, 1),
                                                                             new Tuple<string, int, int>("cdf_lognormal", 1, 2),
                                                                             new Tuple<string, int, int>("cdf_gamma", 1, 1),
                                                                             new Tuple<string, int, int>("cdf_beta", 1, 2),
                                                                             new Tuple<string, int, int>("cdf_continuous_uniform", 1, 2),
                                                                             new Tuple<string, int, int>("cdf_logistic", 1, 2),
                                                                             new Tuple<string, int, int>("cdf_pareto", 1, 2),
                                                                             new Tuple<string, int, int>("cdf_weibull", 1, 2),
                                                                             new Tuple<string, int, int>("cdf_rayleigh", 1, 1),
                                                                             new Tuple<string, int, int>("cdf_laplace", 1, 2),
                                                                             new Tuple<string, int, int>("cdf_cauchy", 1, 2),
                                                                             new Tuple<string, int, int>("cdf_gumbel", 1, 2),
                                                                             /* Special Functions */
                                                                             new Tuple<string, int, int>("bessel_j", 2, 0),
                                                                             new Tuple<string, int, int>("bessel_y", 2, 0),
                                                                             new Tuple<string, int, int>("bessel_i", 2, 0),
                                                                             new Tuple<string, int, int>("bessel_k", 2, 0),
                                                                             new Tuple<string, int, int>("hankel_1", 2, 0),
                                                                             new Tuple<string, int, int>("hankel_2", 2, 0),
                                                                             new Tuple<string, int, int>("gamma", 1, 0),
                                                                             new Tuple<string, int, int>("gamma_incomplete", 2, 0),
                                                                             new Tuple<string, int, int>("gamma_incomplete_regularized", 2, 0),
                                                                             new Tuple<string, int, int>("gamma_incomplete_generalized", 3, 0),
                                                                             new Tuple<string, int, int>("beta", 2, 0),
                                                                             new Tuple<string, int, int>("beta_incomplete", 3, 0),
                                                                             new Tuple<string, int, int>("beta_incomplete_regularized", 3, 0),
                                                                             new Tuple<string, int, int>("beta_incomplete_generalized", 4, 0),
                                                                             new Tuple<string, int, int>("erf", 1, 0),
                                                                             new Tuple<string, int, int>("erfc", 1, 0),
                                                                             new Tuple<string, int, int>("erfi", 1, 0),
                                                                             new Tuple<string, int, int>("erf_generalized ", 2, 0)

                                                                         };
        public List<Tuple<string, int, int>> GetRegisteredFunctions()
        {
            return RegisteredFunctions;
        }

        public static HardCodedFunctions Instance()
        {
            return new HardCodedFunctions();
        }
    }
}