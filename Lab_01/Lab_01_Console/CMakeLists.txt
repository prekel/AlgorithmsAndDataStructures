cmake_minimum_required(VERSION 3.10)
project(Lab_01_Console CXX)

set(CMAKE_CXX_STANDARD 17)

add_executable(Lab_01_Console
        main.cpp)

target_link_libraries(Lab_01_Console PRIVATE Lab_01_Lib)

target_include_directories(Lab_01_Console PUBLIC ${CMAKE_CURRENT_SOURCE_DIR})
