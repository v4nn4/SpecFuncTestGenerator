#pragma once

class ITestPrettyPrinter;

class TestPrettyPrinterFactory
{
public:
    ITestPrettyPrinter* Instance(const bool& isCpp);
};