/// \file
/// \brief Набор тестов
/// \details Набор тестов для алгоритмов.

#ifndef TESTS_H
#define TESTS_H

#include <CUnit/Basic.h>

CU_pSuite* TestsSuiteCreate();

void Test_Max_1();

void Test_Max_Many();

void Test_Average_1();

void Test_Average_Many();

#endif //TESTS_H

