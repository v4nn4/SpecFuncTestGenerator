#pragma once

#include <string>
#include <vector>
#include <sstream>

class ITestPrettyPrinter
{
public:
    virtual std::string Format(const std::vector<std::vector<std::string>>& x, const std::vector<std::string>& fx, const unsigned int& precisionDigits, const std::string& funcName) = 0;
};

class NUnitCSharpTestPrettyPrinter : public ITestPrettyPrinter
{
public:
    std::string Format(const std::vector<std::vector<std::string>>& x, const std::vector<std::string>& fx, const unsigned int& precisionDigits, const std::string& funcName);
};

class GTestCppTestPrettyPrinter : public ITestPrettyPrinter
{
public:
    std::string Format(const std::vector<std::vector<std::string>>& x, const std::vector<std::string>& fx, const unsigned int& precisionDigits, const std::string& funcName);
};