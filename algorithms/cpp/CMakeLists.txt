cmake_minimum_required(VERSION 3.16)
project(problem_solving_algorithms LANGUAGES CXX)

add_executable(algorithm_tests tests/algorithms_test.cpp)
target_include_directories(algorithm_tests PRIVATE include)
target_compile_features(algorithm_tests PRIVATE cxx_std_17)

enable_testing()
add_test(NAME algorithm_tests COMMAND algorithm_tests)
