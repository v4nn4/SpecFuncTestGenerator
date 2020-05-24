#include "TestPrettyPrinter.hpp"

std::string GTestCppTestPrettyPrinter::Format(const std::vector<std::vector<std::string>>& x, const std::vector<std::string>& fx, const unsigned int& precisionDigits, const std::string& funcName)
{
    auto tab = "  ";
    std::stringstream ss;
    ss << "TEST(SpecFunc," << funcName << ")\n";
    ss << "{\n";
    ss << tab << "double prec = 1.0e-" << precisionDigits << ";\n";
    size_t length;
    for (size_t argIdx = 0; argIdx < x.size(); ++argIdx )
    {
        length = x[argIdx].size();
        ss << tab << "double x" << argIdx << "[" << length << "] =\n";
        ss << tab << tab << "{\n";
        for (size_t i = 0; i < length; ++i)
        {
            ss << tab << tab << tab << x[argIdx][i];
            if (i < length - 1) ss << ",";
            ss << "\n";
        }
        ss << tab << tab << "};\n";
    }
    length = x[0].size();
    ss << tab << "double fx[" << length << "] =\n";
    ss << tab << tab << "{\n";
    for (size_t i = 0; i < length; ++i)
    {
        ss << tab << tab << tab << fx[i];
        if (i < length - 1) ss << ",";
        ss << "\n";
    }
    ss << tab <<  tab << "};\n";
    ss << tab << "for(size_t i=0;i<fx.size();++i)\n";
    ss << tab << "{\n";
    ss << tab << tab << "EXPECT_NEAR(fx[i]," << funcName << "(";
    for(size_t argIdx = 0; argIdx < x.size() ; ++argIdx)
    {
        ss << "x" << argIdx << "[i]";
        if (argIdx < x.size()- 1) ss << ",";
    }
    ss << "),prec);\n";
    ss << tab << "}\n";
    ss << "}";
    return ss.str();
}

std::string NUnitCSharpTestPrettyPrinter::Format(const std::vector<std::vector<std::string>>& x, const std::vector<std::string>& fx, const unsigned int& precisionDigits, const std::string& funcName)
{
    auto tab = "    ";
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
    ss << tab << "var prec = 1.0e-" << precisionDigits << ";\n";
    ss << tab << "var f = " << funcName << "(";
    for (size_t argIdx = 0; argIdx < x.size(); ++argIdx )
    {
        ss << "x" << argIdx;
        if (argIdx < x.size()- 1) ss << ",";
    }
    ss << ");\n";
    ss << tab << "Assert.AreEqual(fx,f,prec);\n";
    ss << "}";
    return ss.str();
}