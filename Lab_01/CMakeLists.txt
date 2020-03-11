cmake_minimum_required(VERSION 3.10)
project(Lab_05)


set(CMAKE_CXX_STANDARD 17)

add_library(Lab_05_Lib
        BoyerMoore.cpp BoyerMoore.h)

# target_link_libraries(Lab_05_Lib PRIVATE Lab_05_MatrixLib)

target_include_directories(Lab_05_Lib PUBLIC ${CMAKE_CURRENT_SOURCE_DIR})
