SpecFuncTestGenerator
=====================

Unit test generator for special functions with arbitrary precision using Maxima

##How to build

 MSBuild :
    msbuild SpecFuncTestGenerator.csproj /t:build /p:Configuration=Release
    
##How to use the GUI

1. Select a Maxima special function
2. Enter a number of digits
3. Define an interval using xmin/xmax (10 linear values for now)
4. Enter parameters corresponding to the Maxima function (example: cdf_normal(x,mean,std)
6. Choose a type of test (gtest or NUnit)
5. Generate unit test !
