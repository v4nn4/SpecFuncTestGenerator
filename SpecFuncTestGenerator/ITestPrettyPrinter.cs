using System;

namespace SpecFuncTestGenerator
{
    public interface ITestPrettyPrinter
    {
        string Format(string[] x, string[] fx, int precdigits, string funcName);
        string Tab();
    }

    public abstract class CSharpTestPrettyPrinter : ITestPrettyPrinter
    {
        public abstract string Format(string[] x, string[] fx, int precdigits, string funcName);

        public string Tab()
        {
            return "    ";
        }
    }

    public abstract class CppTestPrettyPrinter : ITestPrettyPrinter
    {
        public abstract string Format(string[] x, string[] fx, int precdigits, string funcName);

        public string Tab()
        {
            return "  ";
        }
    }

    public class NUnitCSharpTestPrettyPrinter : CSharpTestPrettyPrinter
    {
        public override string Format(string[] x, string[] fx, int precdigits, string funcName)
        {
            if(x.Length!=fx.Length)
                throw new Exception("x and fx have different sizes");
            string ss = "";
            for(var i=0;i<x.Length;++i)
            {
                ss += "[TestCase(" + x[i] + "," + fx[i] + ")]\n";
            }
            ss += "void " + funcName + "Test(double x, double fx)\n";
            ss += "{\n";
            ss += Tab() + "var prec = 1.0e-" + precdigits + ";\n";
            ss += Tab() + "var f = " + funcName + "(x);\n";
            ss += Tab() + "Assert.AreEqual(fx,f,prec);\n";
            ss += "}";
            return ss;
        }
    }

    public class GTestCppTestPrettyPrinter : CppTestPrettyPrinter
    {
        public override string Format(string[] x, string[] fx, int precdigits, string funcName)
        {
            if (x.Length != fx.Length)
                throw new Exception("x and fx have different sizes");
            var length = x.Length;
            var ss = "";
            ss += "TEST(SpecFunc," + funcName + ")\n";
            ss += "{\n";
            ss += Tab() + "double prec = 1.0e-" + precdigits + ";\n";
            ss += Tab() + "double x[" + length + "] =\n";
            ss += Tab() + Tab() + "{\n";
            for (var i = 0; i < length; ++i)
            {
                ss += Tab() + Tab() +Tab()+ x[i];
                if (i < length - 1) ss += ",";
                ss += "\n";
            }
            ss += Tab() + Tab() + "};\n";
            ss += Tab() + "double fx[" + length + "] =\n";
            ss += Tab() + Tab() + "{\n";
            for (var i = 0; i < length; ++i)
            {
                ss += Tab() + Tab() + Tab() + fx[i];
                if (i < length - 1) ss += ",";
                ss += "\n";
            }
            ss += Tab() +  Tab()+ "};\n";
            ss += Tab() + "for(size_t i=0;i<x.size();++i)\n";
            ss += Tab() + "{\n";
            ss += Tab() + Tab() + "EXPECT_NEAR(fx[i],"+funcName + "(x[i]),prec);\n";
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