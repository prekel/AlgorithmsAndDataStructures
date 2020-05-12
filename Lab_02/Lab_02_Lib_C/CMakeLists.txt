cmake_minimum_required(VERSION 3.10)
project(Lab_02_Lib_C C)

set(CMAKE_C_STANDARD 11)

add_library(Lab_02_Lib_C Lib.c Lib.h)
# add_library(Lab_02_Lib_C Lib.h)

target_include_directories(Lab_02_Lib_C PUBLIC ${CMAKE_CURRENT_SOURCE_DIR})
