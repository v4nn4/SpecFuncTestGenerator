using System;

namespace SpecFuncTestGenerator
{
    public interface IFormalCalculusMotor
    {
        Tuple<string[],bool> Call(string funcName, double[][] values, double[] funcArgs, int precDigits);
    }
}