/// \file
/// \brief Реализация функций из Tests.h
/// \details Реализация функций из Tests.h.

#include <malloc.h>
#include <stdlib.h>

#include <CUnit/Basic.h>

#include "Tests.h"
#include "Suite.h"

#include "Lib.h"

#define TEST_PROLOGUE() \
double starttime__ = CU_get_elapsed_time(); \
do { \
printf("\n -----  Начат  %s\n", CU_get_current_test()->pName); \
} while (0) \

#define TEST_EPILOGUE() \
do { \
printf("\n ---- Закончен %s, прошло %lf секунд\n", CU_get_current_test()->pName, CU_get_elapsed_time() - starttime__); \
} while (0) \


static void TestsAddTests(CU_pSuite* pSuite)
{
    CU_ADD_TEST(*pSuite, Test_Max_1);
    CU_ADD_TEST(*pSuite, Test_Max_Many);
    CU_ADD_TEST(*pSuite, Test_Average_1);
    CU_ADD_TEST(*pSuite, Test_Average_Many);
}

CU_pSuite* TestsSuiteCreate()
{
    return SuiteCreate("Tests", TestsAddTests);
}

void Test_Max_1()
{
    TEST_PROLOGUE();

    const int count = 5;
    int a[] = {1, 2, 3, 4, 5};
    int maxa = MaxInArray(a, count);
    CU_ASSERT_EQUAL(maxa, 5);

    int b[] = {1, 5, 3, 4, -5};
    int maxb = MaxInArray(b, count);
    CU_ASSERT_EQUAL(maxb, 5);

    TEST_EPILOGUE();
}

void Test_Max_Many()
{
    TEST_PROLOGUE();

    const int count = 10000;
    int* a = (int*) malloc(count * sizeof(int));
    for (int i = 0; i < count; i++)
    {
        a[i] = i;
    }

    for (int i = 0; i < count; i++)
    {
        CU_ASSERT_EQUAL(MaxInArray(a, i + 1), i);
    }

    TEST_EPILOGUE();
}

void Test_Average_1()
{
    TEST_PROLOGUE();

    const int count = 5;
    int a[] = {1, 2, 3, 4, 5};
    double ava = AverageInArray(a, count);
    CU_ASSERT_DOUBLE_EQUAL(ava, 3, 1e-6);

    int b[] = {1, 5, 3, 4, -5};
    double avb = AverageInArray(b, count);
    CU_ASSERT_DOUBLE_EQUAL(avb, 8.0 / 5, 1e-6);

    TEST_EPILOGUE();
}

void Test_Average_Many()
{
    TEST_PROLOGUE();

    const int count = 10000;
    int* a = (int*) malloc(count * sizeof(int));
    for (int i = 0; i < count; i++)
    {
        a[i] = i;
    }

    for (int i = 1; i < count; i++)
    {
        double av1 = AverageInArray(a, i + 1);
        double av2 = i * i / 2.0 / i;
        CU_ASSERT_DOUBLE_EQUAL(av1, av2, 1e-6);
    }

    TEST_EPILOGUE();
}
