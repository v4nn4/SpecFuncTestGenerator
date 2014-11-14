cmake_minimum_required(VERSION 2.8.4)
project(SpecFuncTestGenerator)

set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -std=c++11")
file(GLOB SOURCE_FILES "src/*.hpp" "src/*.cpp")
add_executable(SpecFuncTestGenerator ${SOURCE_FILES})