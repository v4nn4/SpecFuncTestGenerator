namespace SpecFuncTestGenerator
{
    public interface IFormalCalculusMotor
    {
        string[] Call(string funcName, double[] values, double[] funcArgs, int precDigits);
    }
}