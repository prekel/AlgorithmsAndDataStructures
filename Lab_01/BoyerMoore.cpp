#include "BoyerMoore.h"

#include <algorithm>

void BoyerMoore::PreBmBc()
{
    bmBc->resize(sigma);
    auto m = x->length();
    for (auto i = 0; i < sigma; i++)
    {
        bmBc->at(i) = m;
    }
}

bool BoyerMoore::IsPrefix(int p)
{
    auto j = 0;
    auto m = x->length();
    for (auto i = p; i < m; i++)
    {
        if (x->at(i) != x->at(j))
        {
            return false;
        }
        j++;
    }
    return true;
}

int BoyerMoore::SuffixLength(int p)
{
    auto len = 0;
    auto i = p;
    auto j = x->length() - 1;
    while (i >= 0 && x->at(i) == x->at(j))
    {
        len++;
        i--;
        j--;
    }
    return len;
}

void BoyerMoore::PreBmGs()
{
    auto lastPrefixPosition = x->length();
    auto m = x->length();
    for (int i = (int)x->length() - 1; i >= 0; i--)
    {
        if (IsPrefix(i + 1))
        {
            lastPrefixPosition = i + 1;
        }
        bmGs->at(m - 1 - i) = lastPrefixPosition - i + m - 1;
    }
    for (auto i = 0; i <= m - 2; i++)
    {
        auto slen = SuffixLength(i);
        bmGs->at(slen) = m - 1 - i + slen;
    }
}

void BoyerMoore::BM()
{
    auto m = x->length();
    auto n = y->length();

    if (m == 0)
    {
        answer->push_back(-1);
        return;
    }

    PreBmBc();
    PreBmGs();

    for (auto i = m - 1; i <= n - 1; i++)
    {
        auto j = m - 1;
        while (x->at(j) == y->at(i))
        {
            if (j == 0)
            {
                answer->push_back(i);
            }
            i--;
            j--;
        }
        i += std::max(bmGs->at(m - 1 - j), bmBc->at(y->at(i)));
    }
    if (answer->empty())
    {
        answer->push_back(-1);
    }
}
