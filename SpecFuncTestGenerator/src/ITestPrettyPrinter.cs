using System;
using System.Linq;

namespace SpecFuncTestGenerator
{
    public interface ITestPrettyPrinter
    {
        string Format(string[][] x, string[] fx, int precdigits, string funcName);
        string Tab();
    }

    public abstract class CSharpTestPrettyPrinter : ITestPrettyPrinter
    {
        public abstract string Format(string[][] x, string[] fx, int precdigits, string funcName);

        public string Tab()
        {
            return "    ";
        }
    }

    public abstract class CppTestPrettyPrinter : ITestPrettyPrinter
    {
        public abstract string Format(string[][] x, string[] fx, int precdigits, string funcName);

        public string Tab()
        {
            return "  ";
        }
    }

    public class NUnitCSharpTestPrettyPrinter : CSharpTestPrettyPrinter
    {
        public override string Format(string[][] x, string[] fx, int precdigits, string funcName)
        {
            var ss = "";
            if (x[0].Length != fx.Length)
                throw new Exception("x and fx have different sizes");
            for (var i = 0; i < x[0].Length; ++i)
            {
                ss += "[TestCase(";
                ss = x.Aggregate(ss, (current, t) => current + (t[i] + ","));
                ss += fx[i] + ")]\n";
            }
            ss += "void " + funcName + "Test(";
            for (var argIdx = 0; argIdx < x.Length; ++argIdx)
            {
                ss += "double x"+argIdx+",";
            }
            ss += " double fx)\n";
            ss += "{\n";
            ss += Tab() + "var prec = 1.0e-" + precdigits + ";\n";
            ss += Tab() + "var f = " + funcName + "(";
            for (var argIdx = 0; argIdx < x.Length; ++argIdx )
            {
                ss += "x" + argIdx;
                if (argIdx < x.Length - 1) ss += ",";
            }
            ss += ");\n";
            ss += Tab() + "Assert.AreEqual(fx,f,prec);\n";
            ss += "}";
            return ss;
        }
    }

    public class GTestCppTestPrettyPrinter : CppTestPrettyPrinter
    {
        public override string Format(string[][] x, string[] fx, int precdigits, string funcName)
        {
            var ss = "";
            ss += "TEST(SpecFunc," + funcName + ")\n";
            ss += "{\n";
            ss += Tab() + "double prec = 1.0e-" + precdigits + ";\n";
            int length;
            for (var argIdx = 0; argIdx < x.Length; ++argIdx )
            {
                length = x[argIdx].Length;
                ss += Tab() + "double x"+argIdx+"[" + length + "] =\n";
                ss += Tab() + Tab() + "{\n";
                for (var i = 0; i < length; ++i)
                {
                    ss += Tab() + Tab() + Tab() + x[argIdx][i];
                    if (i < length - 1) ss += ",";
                    ss += "\n";
                }
                ss += Tab() + Tab() + "};\n";    
            }
            length = x[0].Length;
            ss += Tab() + "double fx[" + length + "] =\n";
            ss += Tab() + Tab() + "{\n";
            for (var i = 0; i < length; ++i)
            {
                ss += Tab() + Tab() + Tab() + fx[i];
                if (i < length - 1) ss += ",";
                ss += "\n";
            }
            ss += Tab() +  Tab()+ "};\n";
            ss += Tab() + "for(size_t i=0;i<fx.size();++i)\n";
            ss += Tab() + "{\n";
            ss += Tab() + Tab() + "EXPECT_NEAR(fx[i]," + funcName + "(";
            for(var argIdx = 0; argIdx < x.Length ; ++argIdx)
            {
                ss += "x" + argIdx + "[i]";
                if (argIdx < x.Length - 1) ss += ",";
            }
            ss += "),prec);\n";
            ss += Tab() + "}\n";
            ss += "}";
            return ss;
        }
    }

    public class TestPrettyPrinterFactory
    {
        public static ITestPrettyPrinter Instance(bool isCpp)
        {
            if(isCpp)
            {
                return new GTestCppTestPrettyPrinter();
            }
            return new NUnitCSharpTestPrettyPrinter();
        }
    }
}