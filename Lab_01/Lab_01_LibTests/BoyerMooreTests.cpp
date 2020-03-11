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
