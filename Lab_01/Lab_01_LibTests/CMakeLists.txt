cmake_minimum_required(VERSION 3.10)
project(Lab_01_LibTests CXX)

set(CMAKE_CXX_STANDARD 17)

add_executable(Lab_01_LibTests
        BoyerMooreTests.cpp)

include_directories(${GTEST_INCLUDE_DIRS})

target_link_libraries(Lab_01_LibTests PRIVATE gtest gtest_main)
target_link_libraries(Lab_01_LibTests PRIVATE Lab_01_Lib)

target_include_directories(Lab_01_LibTests PUBLIC ${CMAKE_CURRENT_SOURCE_DIR})
