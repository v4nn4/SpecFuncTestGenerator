using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace SpecFuncTestGenerator
{
    public class MaximaMotor : IFormalCalculusMotor
    {
        private readonly string _maximaDir = @"D:\Program Files (x86)\Maxima-5.31.2\share\maxima\5.31.2\share";
        private readonly string _currentDir = Directory.GetCurrentDirectory();

        public string[] Call(string funcName, double[] values, double[] funcArgs, int precDigits)
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
            File.Delete(Path.Combine(_maximaDir, filename));
            File.Delete(Path.Combine(_currentDir, "run.bat"));
        }

        private void GenerateBatch(string filename, string funcName, double[] values, double[] funcArgs, int precDigits)
        {
            // First generate maxima file
            var filePath = Path.Combine(_maximaDir, filename);
            var file = File.Create(filePath);
            file.Close();
            var sw = new StreamWriter(filePath);
            sw.WriteLine("load(distrib)$");
            for(var i=0;i<values.Length;++i)
            {
                var sArg0 = values[i].ToString(CultureInfo.InvariantCulture).Replace(',', '.');
                var sArg1 = funcArgs[0].ToString(CultureInfo.InvariantCulture).Replace(',', '.');
                var sArg2 = funcArgs[1].ToString(CultureInfo.InvariantCulture).Replace(',', '.');
                sw.WriteLine(funcName + "(" + sArg0 + "," + sArg1 + "," + sArg2 + ")$");
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

        private string FormatFileName(string funcName, double[] funcArgs)
        {
            var fileName = funcName;
            for (var i = 0; i < funcArgs.Length; ++i)
            {
                fileName += "__" + funcArgs[i].ToString(CultureInfo.InvariantCulture).Replace('.', '_');

            }
            fileName += ".max";
            return fileName;
        }

        private static string[] ParseMaximaOutput(string str)
        {
            var regex = new Regex("\\(%o[0-9]+\\)(.+)([0-9]\\.[0-9]+b.+)");
            var match = regex.Matches(str);
            var formattedFloat = new string[match.Count];
            for(var i=0;i<match.Count;++i)
            {
                formattedFloat[i] = match[i].Groups[2].Value.Replace('b', 'e');
            }
            return formattedFloat;
        }
    }
}