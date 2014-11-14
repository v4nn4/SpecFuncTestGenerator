#pragma once

#include <string>
#include <vector>
#include <sstream>

class ITestPrettyPrinter
{
public:
    virtual std::string Format(const std::vector<std::vector<std::string>>& x, const std::vector<std::string>& fx, const unsigned int& precisionDigits, const std::string& funcName) = 0;
    virtual std::string Tab() = 0;
};

class CSharpTestPrettyPrinter : public ITestPrettyPrinter
{
public:
    std::string Format(const std::vector<std::vector<std::string>>& x, const std::vector<std::string>& fx, const unsigned int& precisionDigits, const std::string& funcName);
    std::string Tab();
};

class CppTestPrettyPrinter : public ITestPrettyPrinter
{
public:
    virtual std::string Format(const std::vector<std::vector<std::string>>& x, const std::vector<std::string>& fx, const unsigned int& precisionDigits, const std::string& funcName) = 0;
    std::string Tab();
};

class NUnitCSharpTestPrettyPrinter : public CSharpTestPrettyPrinter
{
public:
    std::string Format(const std::vector<std::vector<std::string>>& x, const std::vector<std::string>& fx, const unsigned int& precisionDigits, const std::string& funcName);
};

class GTestCppTestPrettyPrinter : public CppTestPrettyPrinter
{
public:
    std::string Format(const std::vector<std::vector<std::string>>& x, const std::vector<std::string>& fx, const unsigned int& precisionDigits, const std::string& funcName);
};