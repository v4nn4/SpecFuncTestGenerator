#include <sstream>
#include <fstream>
#include "MaximaMotor.hpp"

MaximaMotor::MaximaMotor(const RequiredDirectories& requiredDirectories)
: _requiredDirectories(requiredDirectories)
{

}

Result MaximaMotor::Call(const std::string& funcName, const std::vector<std::vector<double>>& values, const std::vector<double>& funcArgs, const unsigned int& precisionDigits)
{
    std::string filename = FormatFileName(funcName,funcArgs);
    GenerateMaximaFile(filename, funcName, values, funcArgs, precisionDigits);
    std::stringstream ss;
    std::system(_requiredDirectories.cwd.c_str());
    ss << "exec '" << _requiredDirectories.maxima << "' -b=" << _requiredDirectories.cwd << filename;
    std::system(ss.str().c_str());
    std::string output;
    return ParseMaximaOutput(output);
}

void MaximaMotor::GenerateMaximaFile(const std::string &filename, const std::string &funcName, const std::vector<std::vector<double>> &values, const std::vector<double> &funcArgs, const unsigned int &precisionDigits)
{
    // First generate maxima file
    std::stringstream tempFilePath;
    tempFilePath << _requiredDirectories.cwd << filename;
    std::ofstream sw;
    sw.open(tempFilePath.str());
    sw << "load(distrib)$" << std::endl;
    std::string paramsString = GetArgsInFunctionCall(funcArgs);
    for (size_t i = 0; i < values[0].size(); ++i)
    {
        sw << funcName << "(";
        for (size_t argIdx = 0; argIdx < values.size(); ++argIdx)
        {
            std::string sArg = std::to_string(values[argIdx][i]);
            std::replace(sArg.begin(),sArg.end(),',', '.');
            sw << sArg;
            if(argIdx < values.size()-1) sw << ",";
        }
        sw << paramsString << ")$\n";
        sw << "bfloat(%);"; //,fpprec:" << precisionDigits << ");";
    }
    sw.close();
}

std::string MaximaMotor::GetArgsInFunctionCall(const std::vector<double>& funcArgs)
{
    if (funcArgs.size()==0) return "";
    std::stringstream result;
    std::string s;
    for (size_t i = 0; i < funcArgs.size(); ++i)
    {
        s = funcArgs[i];
        std::replace(s.begin(),s.end(),',','.');
        result << "," << funcArgs[i];
    }
    return result.str();
}

std::string MaximaMotor::FormatFileName(const std::string& funcName, const std::vector<double>& funcArgs)
{
    std::stringstream fileName;
    fileName << funcName;
    if (funcArgs.size()>0)
    {
        std::string s;
        for (size_t i = 0; i < funcArgs.size(); ++i)
        {
            s = funcArgs[i];
            std::replace(s.begin(),s.end(),'.','_');
            fileName << "__" << funcArgs[i];
        }
    }
    fileName << ".max";
    return fileName.str();
}

Result MaximaMotor::ParseMaximaOutput(const std::string& str)
{
    /*var regex = new Regex("\\(%o[0-9]+\\)(.+)([0-9]\\.[0-9]+b.+)");
    var match = regex.Matches(str);
    if(match.Count!=0)
    {
        var formattedFloat = new string[match.Count];
        for (var i = 0; i < match.Count; ++i)
        {
            formattedFloat[i] = match[i].Groups[2].Value.Replace('b', 'e');
        }
        return new Tuple<string[], bool>(formattedFloat,true);
    }
    // Maxima thrown an error
    var regexError = new Regex("([^%].+)\\n\\s--\\san error\\.\\sTo\\sdebug\\sthis\\stry:\\sdebugmode\\(true\\);");
    var matchError = regexError.Matches(str);
    var errorString = matchError[0].Groups[1].Value.Replace("\\n", "");
    return new Tuple<string[], bool>(new[]{errorString}, false);*/
    Result result;
    return result;
}