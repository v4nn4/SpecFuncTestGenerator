#include <iostream>
#include "MaximaMotor.hpp"

int main(int argc, char* argv[]) {
    if(argc==3)
    {
        RequiredDirectories requiredDirectories;
        requiredDirectories.cwd = argv[1];
        requiredDirectories.maxima = argv[2];
        MaximaMotor motor(requiredDirectories);
        std::vector<std::vector<double>> values(1);
        values[0] = std::vector<double>(5);
        values[0][0] = -1;
        values[0][1] = -0.5;
        values[0][2] = -0;
        values[0][3] = 0.5;
        values[0][4] = 1;
        std::vector<double> funcArgs(2);
        funcArgs[0] = 0.0; // mean
        funcArgs[1] = 1.0; // variance
        motor.Call("cdf_normal", values, funcArgs, 10);
        return 0;
    }
    else
    {
        std::cout << "Use SpecFuncTestGenerator <cwd> <maxima directory>" << std::endl;
        return 1;
    }
}