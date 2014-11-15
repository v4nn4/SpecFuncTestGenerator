#include "IFormalCalculusMotor.hpp"

class MaximaMotor : IFormalCalculusMotor
{
public:
    Result Call(const std::string& funcName, const std::vector<std::vector<double>>& values, const std::vector<double>& funcArgs, const unsigned int& precisionDigits);
private:
    void GenerateMaximaFile(const std::string &filename, const std::string &funcName, const std::vector<std::vector<double>> &values, const std::vector<double> &funcArgs, const unsigned int &precisionDigits);
    std::string GetArgsInFunctionCall(const std::vector<double>& funcArgs);
    static std::string FormatFileName(const std::string& funcName, const std::vector<double>& funcArgs);
    static Result ParseMaximaOutput(const std::string& str);
};