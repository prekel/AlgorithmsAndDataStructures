cmake_minimum_required(VERSION 3.10)
project(Lab_02_LibTests C)

set(CMAKE_C_STANDARD 11)

add_executable(Lab_02_LibTests
        main.c
        Tests.h Tests.c
        Suite.h Suite.c)

target_link_libraries(Lab_02_LibTests PRIVATE cunit)
target_link_libraries(Lab_02_LibTests PRIVATE Lab_02_Lib)

target_include_directories(Lab_02_LibTests PUBLIC ${CMAKE_CURRENT_SOURCE_DIR})
