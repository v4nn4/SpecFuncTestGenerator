using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace SpecFuncTestGenerator
{
    public partial class Form1 : Form
    {
        private static readonly List<Tuple<string, int, int>> RegisteredFunctions = HardCodedFunctions.Instance().GetRegisteredFunctions();
        public Form1()
        {
            InitializeComponent();
            foreach (var t in RegisteredFunctions)
            {
                registeredFunc.Items.Add(t.Item1);
            }
        }

        private void Button1Click(object sender, EventArgs e)
        {
            const int n = 10;
            var xmax = double.Parse(inputValueMax.Text);
            var xmin = double.Parse(inputValueMin.Text);
            var step = (xmax - xmin)/n;
            var gen = new EquiIntervalGenerator(step);
            var x = gen.Generate(xmin, xmax);
            var xs = new string[x.Length];
            for(var i=0;i<x.Length;++i)
            {
                xs[i] = x[i].ToString(CultureInfo.InvariantCulture);
            }
            var motor = new MaximaMotor();
            var args = GetCurrentArgs();
            var prec = int.Parse(precDigits.Text);
            var res = motor.Call("cdf_normal", x, args, prec);
            var printer = TestPrettyPrinterFactory.Instance(isCpp.Checked);
            var output = printer.Format(xs, res, prec, "cnorm");
            MessageBox.Show(output);
        }

        private double[] GetCurrentArgs()
        {
            if (parameter3.Visible)
            {
                return new[]
                           {
                               double.Parse(parameter1.Text),
                               double.Parse(parameter2.Text),
                               double.Parse(parameter3.Text)
                           };
            }
            if(parameter2.Visible)
            {
                return new[]
                           {
                               double.Parse(parameter1.Text),
                               double.Parse(parameter2.Text)
                           };
            }
            if(parameter1.Visible)
            {
                return new[]
                           {
                               double.Parse(parameter1.Text)
                           };
            }
            throw  new Exception("No parameter visible : cannot get args.");
        }

        private void RegisteredFuncSelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(var t in RegisteredFunctions)
            {
                if(t.Item1==registeredFunc.Text)
                {
                    var nbArgs = t.Item3;
                    parameter1.Hide();
                    parameter2.Hide();
                    parameter3.Hide();
                    if (nbArgs == 3)
                    {
                        parameter3.Show();
                    }
                    if(nbArgs>=2)
                    {
                        parameter2.Show();
                    }
                    if(nbArgs>=1)
                    {
                        parameter1.Show();
                    }
                    break;
                }
            }
        }
    }
}
