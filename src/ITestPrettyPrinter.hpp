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
    std::string Tab()
    {
        return "    ";
    };
};

class CppTestPrettyPrinter : public ITestPrettyPrinter
{
public:
    virtual std::string Format(const std::vector<std::vector<std::string>>& x, const std::vector<std::string>& fx, const unsigned int& precisionDigits, const std::string& funcName) = 0;
    std::string Tab()
    {
        return "  ";
    };
};

class NUnitCSharpTestPrettyPrinter : public CSharpTestPrettyPrinter
{
public:
    std::string Format(const std::vector<std::vector<std::string>>& x, const std::vector<std::string>& fx, const unsigned int& precisionDigits, const std::string& funcName)
    {
        std::stringstream ss;
        if (x[0].size() != fx.size())
            throw std::invalid_argument("x and fx have different sizes");
        for (size_t i = 0; i < x[0].size(); ++i)
        {
            ss << "[TestCase(";
            //ss = x.Aggregate(ss, (current, t) => current + (t[i] + ","));
            ss << fx[i] << ")]\n";
        }
        ss << "void " << funcName << "Test(";
        for (size_t argIdx = 0; argIdx < x.size(); ++argIdx)
        {
            ss << "double x" << argIdx << ",";
        }
        ss << " double fx)\n";
        ss << "{\n";
        ss << Tab() << "var prec = 1.0e-" << precisionDigits << ";\n";
        ss << Tab() << "var f = " << funcName << "(";
        for (size_t argIdx = 0; argIdx < x.size(); ++argIdx )
        {
            ss << "x" << argIdx;
            if (argIdx < x.size()- 1) ss << ",";
        }
        ss << ");\n";
        ss << Tab() << "Assert.AreEqual(fx,f,prec);\n";
        ss << "}";
        return ss.str();
    };
};

class GTestCppTestPrettyPrinter : public CppTestPrettyPrinter
{
public:
    std::string Format(const std::vector<std::vector<std::string>>& x, const std::vector<std::string>& fx, const unsigned int& precisionDigits, const std::string& funcName)
    {
        std::stringstream ss;
        ss << "TEST(SpecFunc," << funcName << ")\n";
        ss << "{\n";
        ss << Tab() << "double prec = 1.0e-" << precisionDigits << ";\n";
        size_t length;
        for (size_t argIdx = 0; argIdx < x.size(); ++argIdx )
        {
            length = x[argIdx].size();
            ss << Tab() << "double x" << argIdx << "[" << length << "] =\n";
            ss << Tab() << Tab() << "{\n";
            for (size_t i = 0; i < length; ++i)
            {
                ss << Tab() << Tab() << Tab() << x[argIdx][i];
                if (i < length - 1) ss << ",";
                ss << "\n";
            }
            ss << Tab() << Tab() << "};\n";
        }
        length = x[0].size();
        ss << Tab() << "double fx[" << length << "] =\n";
        ss << Tab() << Tab() << "{\n";
        for (size_t i = 0; i < length; ++i)
        {
            ss << Tab() << Tab() << Tab() << fx[i];
            if (i < length - 1) ss << ",";
            ss << "\n";
        }
        ss << Tab() <<  Tab() << "};\n";
        ss << Tab() << "for(size_t i=0;i<fx.size();++i)\n";
        ss << Tab() << "{\n";
        ss << Tab() << Tab() << "EXPECT_NEAR(fx[i]," << funcName << "(";
        for(size_t argIdx = 0; argIdx < x.size() ; ++argIdx)
        {
            ss << "x" << argIdx << "[i]";
            if (argIdx < x.size()- 1) ss << ",";
        }
        ss << "),prec);\n";
        ss << Tab() << "}\n";
        ss << "}";
        return ss.str();
    }
};

class TestPrettyPrinterFactory
{
public:
    ITestPrettyPrinter* Instance(bool isCpp)
    {
        if(isCpp)
        {
            return new GTestCppTestPrettyPrinter();
        }
        return new NUnitCSharpTestPrettyPrinter();
    }
};