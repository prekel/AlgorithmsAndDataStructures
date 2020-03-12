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

    ASSERT_EQ(answer->size(), 2);
    EXPECT_EQ(answer->at(0), 1);
    EXPECT_EQ(answer->at(1), 4);

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


    delete bm;
}

TEST(BoyerMooreTests, PreBmBcTest2)
{
    int sigma = 256;
    auto m = 8;
    auto bm = new BoyerMoore("GCATCGCAGAGAGTATACAGTACG", "GCAGAGAG", sigma);

    bm->PreBmBc();

    auto bmbc = bm->GetBmBc();

    ASSERT_EQ(bmbc->size(), sigma);
//    EXPECT_EQ(bmbc->at('A'), 1);
//    EXPECT_EQ(bmbc->at('C'), 6);
//    EXPECT_EQ(bmbc->at('G'), 2);
//    EXPECT_EQ(bmbc->at('T'), 8);

    delete bm;
}
TEST(BoyerMooreTests, PreBmGsTest2)
{
    int sigma = 256;
    auto m = 8;
    auto bm = new BoyerMoore("GCATCGCAGAGAGTATACAGTACG", "GCAGAGAG", sigma);

    bm->PreBmBc();
    bm->PreBmGs();

    auto bmgs = bm->GetBmGs();

    ASSERT_EQ(bmgs->size(), 8);
//    EXPECT_EQ(bmgs->at(0), 7);
//    EXPECT_EQ(bmgs->at(1), 7);
//    EXPECT_EQ(bmgs->at(2), 7);
//    EXPECT_EQ(bmgs->at(3), 2);
//    EXPECT_EQ(bmgs->at(4), 7);
//    EXPECT_EQ(bmgs->at(5), 4);
//    EXPECT_EQ(bmgs->at(6), 7);
//    EXPECT_EQ(bmgs->at(7), 1);

    delete bm;
}

TEST(BoyerMooreTests, SuffixLengthTest1)
{
    int sigma = 256;
    auto m = 2;
    auto bm = new BoyerMoore("ddddddbcabcbcabc", "dddbcabc", sigma);

    ASSERT_EQ(bm->SuffixLength(4), 2);

    delete bm;
}

