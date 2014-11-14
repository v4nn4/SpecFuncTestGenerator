#pragma once

#include <unordered_map>

struct MaximaFunctions
{
    static std::unordered_map<std::string,std::pair<int,int>> Instance()
    {
        std::unordered_map<std::string,std::pair<int,int>> m;
        m.insert("cdf_normal", std::make_pair(1, 2));
        m.insert("cdf_student_t", std::make_pair(1, 1));
        /*m["cdf_chi2", 1, 1),
        m["cdf_noncentral_chi2l", 1, 2),
        m["cdf_exp", 1, 1),
        m["cdf_lognormal", 1, 2),
        m["cdf_gamma", 1, 1),
        m["cdf_beta", 1, 2),
        m["cdf_continuous_uniform", 1, 2),
        m["cdf_logistic", 1, 2),
        m["cdf_pareto", 1, 2),
        m["cdf_weibull", 1, 2),
        m["cdf_rayleigh", 1, 1),
        m["cdf_laplace", 1, 2),
        m["cdf_cauchy", 1, 2),
        m["cdf_gumbel", 1, 2),
        m["quantile_normal", 1, 2),
        m["quantile_student_t", 1, 1),
        m["quantile_noncentral_student_t", 1, 2),
        m["quantile_chi2", 1, 1),
        m["quantile_noncentral_chi2", 1, 2),
        m["quantile_f", 1, 2),
        m["quantile_exp", 1, 1),
        m["quantile_lognormal", 1, 2),
        m["quantile_gamma", 1, 2),
        m["quantile_beta", 1, 2),
        m["quantile_continuous_uniform", 1, 2),
        m["quantile_logistic", 1, 2),
        m["quantile_pareto", 1, 2),
        m["quantile_weibull", 1, 2),
        m["quantile_rayleigh", 1, 1),
        m["quantile_laplace", 1, 2),
        m["quantile_cauchy", 1, 2),
        m["quantile_gumbel", 1, 2),
        m["bessel_j", 2, 0),
        m["bessel_y", 2, 0),
        m["bessel_i", 2, 0),
        m["bessel_k", 2, 0),
        m["hankel_1", 2, 0),
        m["hankel_2", 2, 0),
        m["gamma", 1, 0),
        m["gamma_incomplete", 2, 0),
        m["gamma_incomplete_regularized", 2, 0),
        m["gamma_incomplete_generalized", 3, 0),
        m["beta", 2, 0),
        m["beta_incomplete", 3, 0),
        m["beta_incomplete_regularized", 3, 0),
        m["beta_incomplete_generalized", 4, 0),
        m["erf", 1, 0),
        m["erfc", 1, 0),
        m["erfi", 1, 0),
        m["erf_generalized ", 2, 0)*/
        return m;
    }
    static const std::unordered_map<int,int> maximaFunctions;
};

const std::unordered_map<std::string,std::pair<int,int>> MaximaFunctions::maximaFunctions = MaximaFunctions::Instance();