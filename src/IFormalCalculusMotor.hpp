#pragma once

#include <string>
#include <vector>

class Result
{
public:
    std::vector<std::string> strings;
    bool status;
};

class IFormalCalculusMotor
{
public:
    virtual Result Call(const std::string& funcName, const std::vector<std::vector<double>>& values, const std::vector<double>& funcArgs, const unsigned int& precisionDigits) = 0;
};