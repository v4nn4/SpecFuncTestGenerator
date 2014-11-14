#include <sstream>
#include "MaximaMotor.hpp"

Result MaximaMotor::Call(const std::string& funcName, const std::vector<std::vector<double>>& values, const std::vector<double>& funcArgs, const unsigned int& precisionDigits)
{
    std::string filename = FormatFileName(funcName,funcArgs);
    GenerateBatch(filename, funcName, values, funcArgs, precisionDigits);
    /*var processStartInfo = new ProcessStartInfo
            {
                    FileName = "run.bat",
                    UseShellExecute = false,
                    RedirectStandardOutput = true
            };
    var process = new Process
            {
                    StartInfo = processStartInfo
            };
    process.Start();
    var output = process.StandardOutput.ReadToEnd();
    process.WaitForExit();
    process.Close();
    DeleteBatch(filename);*/
    std::string output;
    return ParseMaximaOutput(output);
}

void MaximaMotor::DeleteBatch(const std::string& filename)
{
    /*File.Delete(Path.Combine(MaximaDir, filename));
    File.Delete(Path.Combine(_currentDir, "run.bat"));*/
}

void MaximaMotor::GenerateBatch(const std::string& filename, const std::string& funcName, const std::vector<std::vector<double>>& values, const std::vector<double>& funcArgs, const unsigned int& precDigits)
{
    // First generate maxima file
    /*var filePath = Path.Combine(MaximaDir, filename);
    var file = File.Create(filePath);
    file.Close();
    var sw = new StreamWriter(filePath);
    sw.WriteLine("load(distrib)$");
    var paramsString = GetArgsInFunctionCall(funcArgs);
    for (var i = 0; i < values[0].Length; ++i)
    {
        sw.Write(funcName + "(");
        for (var argIdx = 0; argIdx < values.Length; ++argIdx)
        {
            var sArg = values[argIdx][i].ToString(CultureInfo.InvariantCulture).Replace(',', '.');
            sw.Write(sArg);
            if(argIdx < values.Length-1) sw.Write(",");
        }
        sw.Write(paramsString + ")$\n");
        sw.WriteLine("bfloat(%,fpprec:" + precDigits + ");");

    }
    sw.Close();
    // Then generate batch
    var currentDir = Directory.GetCurrentDirectory();
    var batchFilePath = Path.Combine(currentDir, "run.bat");
    var batchFile = File.Create(batchFilePath);
    batchFile.Close();
    var swb = new StreamWriter(batchFilePath);
    swb.WriteLine("maxima -b="+filename);
    swb.Close();*/
}

std::string MaximaMotor::GetArgsInFunctionCall(const std::vector<double>& funcArgs)
{
    if (funcArgs.size()>0) return "";
    std::stringstream result;
    for (size_t i = 0; i < funcArgs.size(); ++i)
    {
        result << "," << funcArgs[i]; //.ToString(CultureInfo.InvariantCulture).Replace(',', '.');
    }
    return result.str();
}

std::string MaximaMotor::FormatFileName(const std::string& funcName, const std::vector<double>& funcArgs)
{
    std::stringstream fileName;
    fileName << funcName;
    if (funcArgs.size()>0)
    {
        for (size_t i = 0; i < funcArgs.size(); ++i)
        {
            fileName << "__" << funcArgs[i]; //.ToString(CultureInfo.InvariantCulture).Replace('.', '_');
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