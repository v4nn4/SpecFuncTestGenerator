#include "IIntervalGenerator.hpp"

std::vector<std::vector<double>> IntervalGenerator::Generate(const std::vector<double>& xmin, const std::vector<double>& xmax)
{
    size_t size = xmin.size();
    std::vector<std::vector<double>> res(size);
    for (size_t argIdx = 0; argIdx < xmin.size();++argIdx )
    {
        double step = (xmax[argIdx] - xmin[argIdx]) / (_n - 1);
        res[argIdx] = std::vector<double>(_n);
        for (size_t idx = 0; idx < _n; ++idx)
        {
            res[argIdx][idx] = xmin[argIdx] + idx * step;
        }
    }
    return res;
}