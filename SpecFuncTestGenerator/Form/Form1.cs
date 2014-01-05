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
            var motor = new MaximaMotor();
            
            // Getting args
            var x = GetCurrentValues();
            var args = GetCurrentArgs();
            var prec = int.Parse(precDigits.Text);

            var res = motor.Call(registeredFunc.Text, x, args, prec);

            if(!res.Item2)
            {
                MessageBox.Show(res.Item1[0]);
                return;
            }

            var printer = TestPrettyPrinterFactory.Instance(isCpp.Checked);
            // Converting x to string
            var xs = new string[x.Length][];
            for (var argIdx = 0; argIdx < x.Length; ++argIdx)
            {
                xs[argIdx] = new string[x[argIdx].Length];
                for (var i = 0; i < x[argIdx].Length; ++i)
                {
                    xs[argIdx][i] = x[argIdx][i].ToString(CultureInfo.InvariantCulture);
                }
            }
            var output = printer.Format(xs, res.Item1, prec, "cnorm");
            MessageBox.Show(output);
        }

        private double[][] GetCurrentValues()
        {
            double[] xmin;
            double[] xmax;
            if(input2ValueMax.Visible)
            {
                xmin = new double[2];
                xmin[0] = double.Parse(input1ValueMin.Text);
                xmin[1] = double.Parse(input2ValueMin.Text);
                xmax = new double[2];
                xmax[0] = double.Parse(input1ValueMax.Text);
                xmax[1] = double.Parse(input2ValueMax.Text);
            }
            else
            {
                xmin = new double[1];
                xmin[0] = double.Parse(input1ValueMin.Text);
                xmax = new double[1];
                xmax[0] = double.Parse(input1ValueMax.Text);
            }
            const int n = 10;
            var gen = new EquiIntervalGenerator(n);
            return gen.Generate(xmin, xmax);
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
            return null;
        }

        private void RegisteredFuncSelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(var t in RegisteredFunctions)
            {
                if(t.Item1==registeredFunc.Text)
                {
                    var nbValues = t.Item2;
                    input1ValueMax.Hide();
                    input1ValueMin.Hide();
                    input2ValueMax.Hide();
                    input2ValueMin.Hide();
                    labelInput2Max.Hide();
                    labelInput2Min.Hide();
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
                    if(nbValues==2)
                    {
                        input2ValueMax.Show();
                        input2ValueMin.Show();
                        labelInput2Max.Show();
                        labelInput2Min.Show();
                    }
                    if(nbValues>=1)
                    {
                        input1ValueMax.Show();
                        input1ValueMin.Show();
                    }
                    break;
                }
            }
        }
    }
}
