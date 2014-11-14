#pragma once

#include <vector>

class IntervalGenerator
{
public:
    IntervalGenerator(const unsigned int& n) : _n(n) {};
    std::vector<std::vector<double>> Generate(const std::vector<double>& xmin, const std::vector<double>& xmax);
private:
    unsigned int _n;
};