cmake_minimum_required(VERSION 3.10)
project(Lab_02_Lib ASM-ATT)

add_library(Lab_02_Lib
        Lib.s Lib.h)

target_include_directories(Lab_02_Lib PUBLIC ${CMAKE_CURRENT_SOURCE_DIR})
