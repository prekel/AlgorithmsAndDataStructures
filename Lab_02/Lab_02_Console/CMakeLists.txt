cmake_minimum_required(VERSION 3.10)
project(Lab_02_Console C)

set(CMAKE_C_STANDARD 11)

add_executable(Lab_02_Console
        main.c)

# target_link_libraries(Lab_02_Console PRIVATE Lab_02_Lib Lab_02_Lib_C)
target_link_libraries(Lab_02_Console PRIVATE Lab_02_Lib)

target_include_directories(Lab_02_Console PUBLIC ${CMAKE_CURRENT_SOURCE_DIR})
