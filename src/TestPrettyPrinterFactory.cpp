#include "TestPrettyPrinterFactory.hpp"
#include "TestPrettyPrinter.hpp"

ITestPrettyPrinter* TestPrettyPrinterFactory::Instance(const bool& isCpp)
{
    if(isCpp)
    {
        return new GTestCppTestPrettyPrinter();
    }
    return new NUnitCSharpTestPrettyPrinter();
}