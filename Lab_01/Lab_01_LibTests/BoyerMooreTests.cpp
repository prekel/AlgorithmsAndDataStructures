#include <vector>

#include <gtest/gtest.h>

#include "BoyerMoore.h"

using namespace testing;

TEST(BoyerMooreTests, BoyerMooreTest1)
{
    EXPECT_LT(1, 2);
}

TEST(BoyerMooreTests, BoyerMooreTest2)
{
    auto bm = new BoyerMoore("123123", "23", 256);
    bm->Calculate();
    auto answer = bm->GetAnswer();

    EXPECT_LT(1, 2);

    delete bm;
}

TEST(BoyerMooreTests, PreBmBcTest1)
{
    int sigma = 256;
    auto m = 2;
    auto bm = new BoyerMoore("123123", "23", sigma);

    bm->PreBmBc();

    auto bmbc = bm->GetBmBc();

    ASSERT_EQ(bmbc->size(), sigma);
    for (int i = 0; i < sigma; i++)
    {
        ASSERT_EQ(bmbc->at(i), m);
    }

    delete bm;
}