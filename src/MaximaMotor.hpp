#include "IFormalCalculusMotor.hpp"

class MaximaMotor : IFormalCalculusMotor
{
private:
    //static const std::string MaximaDir = "D:\\Program Files (x86)\\Maxima-5.31.2\\share\\maxima\\5.31.2\\share";
    //readonly string _currentDir = Directory.GetCurrentDirectory();
public:
    Result Call(const std::string& funcName, const std::vector<std::vector<double>>& values, const std::vector<double>& funcArgs, const unsigned int& precisionDigits);

private:
    void DeleteBatch(const std::string& filename);
    void GenerateBatch(const std::string& filename, const std::string& funcName, const std::vector<std::vector<double>>& values, const std::vector<double>& funcArgs, const unsigned int& precisionDigits);
    std::string GetArgsInFunctionCall(const std::vector<double>& funcArgs);
    static std::string FormatFileName(const std::string& funcName, const std::vector<double>& funcArgs);
    static Result ParseMaximaOutput(const std::string& str);
};