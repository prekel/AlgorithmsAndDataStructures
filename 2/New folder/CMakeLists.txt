cmake_minimum_required(VERSION 3.10)

enable_language(ASM-ATT)
set(mySrcs Matrix.s MatrixIO.s main.s)

# set(CMAKE_ASM-ATT_FLAGS "-m32")

add_executable(player ${mySrcs})

target_compile_options(player PRIVATE --32)
set_target_properties(player PROPERTIES LINK_FLAGS "-m32")

set(CMAKE_C_LINK_EXECUTABLE gcc)