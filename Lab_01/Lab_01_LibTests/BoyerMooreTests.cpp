#include <vector>

#include <gtest/gtest.h>

#include "BoyerMoore.h"

using namespace testing;

TEST(BoyerMooreTests, BoyerMooreTest1)
{
    auto bm = new BoyerMoore("rgsgfdsq125rerdsgs", "r", false);
    bm->Calculate();
    auto answer = bm->GetAnswer();

    ASSERT_EQ(answer->size(), 3);
    EXPECT_EQ(answer->at(0), 0);
    EXPECT_EQ(answer->at(1), 11);
    EXPECT_EQ(answer->at(2), 13);

    delete bm;
}

TEST(BoyerMooreTests, BoyerMooreTest2)
{
    auto bm = new BoyerMoore("123123", "23", false);
    bm->Calculate();
    auto answer = bm->GetAnswer();

    ASSERT_EQ(answer->size(), 2);
    EXPECT_EQ(answer->at(0), 1);
    EXPECT_EQ(answer->at(1), 4);

    delete bm;
}

TEST(BoyerMooreTests, BoyerMooreTest3)
{
    auto bm = new BoyerMoore("ABAAABCDBBABCDDEBCABC", "ABC", false);
    bm->Calculate();
    auto answer = bm->GetAnswer();

    ASSERT_EQ(answer->size(), 3);
    EXPECT_EQ(answer->at(0), 4);
    EXPECT_EQ(answer->at(1), 10);
    EXPECT_EQ(answer->at(2), 18);

    delete bm;
}

TEST(BoyerMooreTests, BoyerMooreTest4)
{
    auto bm = new BoyerMoore("GCATCGCAGAGAGTATACAGTACG", "GCAGAGAG", false);
    bm->Calculate();
    auto answer = bm->GetAnswer();

    ASSERT_EQ(answer->size(), 1);
    EXPECT_EQ(answer->at(0), 5);

    delete bm;
}

TEST(BoyerMooreTests, BoyerMooreTest5)
{
    auto bm = BoyerMoore("GCATCGCAGAGAGTATACAGTACG", "GcagAGAG", true);
    bm.Calculate();
    auto answer = bm.GetAnswer();

    ASSERT_EQ(answer->size(), 1);
    EXPECT_EQ(answer->at(0), 5);
}
