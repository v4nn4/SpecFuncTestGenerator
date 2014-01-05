using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace SpecFuncTestGenerator
{
    public class MaximaMotor : IFormalCalculusMotor
    {
        private const string MaximaDir = @"D:\Program Files (x86)\Maxima-5.31.2\share\maxima\5.31.2\share";
        private readonly string _currentDir = Directory.GetCurrentDirectory();

        public Tuple<string[],bool> Call(string funcName, double[][] values, double[] funcArgs, int precDigits)
        {
            var filename = FormatFileName(funcName,funcArgs);
            GenerateBatch(filename, funcName, values, funcArgs, precDigits);
            var processStartInfo = new ProcessStartInfo
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
            DeleteBatch(filename);
            return ParseMaximaOutput(output);
        }

        private void DeleteBatch(string filename)
        {
            File.Delete(Path.Combine(MaximaDir, filename));
            File.Delete(Path.Combine(_currentDir, "run.bat"));
        }

        private void GenerateBatch(string filename, string funcName, double[][] values, double[] funcArgs, int precDigits)
        {
            // First generate maxima file
            var filePath = Path.Combine(MaximaDir, filename);
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
            swb.Close();
        }

        private string GetArgsInFunctionCall(double[] funcArgs)
        {
            if (funcArgs == null) return "";
            var result = "";
            for (var i = 0; i < funcArgs.Length; ++i)
            {
                result += "," + funcArgs[i].ToString(CultureInfo.InvariantCulture).Replace(',', '.');
            }
            return result;
        }

        private static string FormatFileName(string funcName, double[] funcArgs)
        {
            var fileName = funcName;
            if (funcArgs != null)
            {
                for (var i = 0; i < funcArgs.Length; ++i)
                {
                    fileName += "__" + funcArgs[i].ToString(CultureInfo.InvariantCulture).Replace('.', '_');
                }
            }
            fileName += ".max";
            return fileName;
        }

        private static Tuple<string[], bool> ParseMaximaOutput(string str)
        {
            var regex = new Regex("\\(%o[0-9]+\\)(.+)([0-9]\\.[0-9]+b.+)");
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
            else
            {
                // Maxima thrown an error
                var regexError = new Regex("([^%].+)\\n\\s--\\san error\\.\\sTo\\sdebug\\sthis\\stry:\\sdebugmode\\(true\\);");
                var matchError = regexError.Matches(str);
                var errorString = matchError[0].Groups[1].Value.Replace("\\n", "");
                return new Tuple<string[], bool>(new string[1]{errorString}, false);
            }
        }
    }
}