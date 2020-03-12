#include "BoyerMoore.h"

#include <algorithm>
#include <utility>

void BoyerMoore::PreBmBc()
{
    auto m = x.length();
    bmBc->assign(sigma, m);
    for (auto i = 0; i < m - 2; i++)
    {
        bmBc->at(x[i]) = m - 1 - i;
    }
}

bool BoyerMoore::IsPrefix(int p)
{
    int m = x.length();
    for (int i = p, j = 0; i < m; ++i, ++j)
    {
        if (x[i] != x[j])
        {
            return false;
        }
    }
    return true;
}

int BoyerMoore::SuffixLength(int p)
{
    int m = x.length();
    auto len = 0;
    for (auto i = p, j = m - 1;
         i >= 0 && x[i] == x[j]; --i, --j)
    {
        len += 1;
    }
    return len;
}

void BoyerMoore::PreBmGs()
{
    int p;

    int m = x.length();

    bmGs->assign(m, 0);
    int lastPrefixPosition = m;
    for (int i = m; i > 0; --i)
    {
        if (IsPrefix(i))
        {
            lastPrefixPosition = i;
        }
        bmGs->at(m - i) = lastPrefixPosition - i + m;
    }
    for (int i = 0; i < m - 1; ++i)
    {
        int slen = SuffixLength(i);
        bmGs->at(slen) = m - 1 - i + slen;
    }
}

void BoyerMoore::BM()
{
    int m = x.length();
    int n = y.length();

    if (m == 0)
    {
        answer->push_back(-1);
        return;
    }

    PreBmBc();
    PreBmGs();

    int j = 0;
    int i;
    while (j <= n - m)
    {
        for (i = m - 1; i >= 0 && x[i] == y[i + j]; --i);
        if (i < 0)
        {
            answer->push_back(j);
            j += bmGs->at(0);
        }
        else
        {
            j += std::max(bmGs->at(i), bmBc->at(y[i + j]) - m + 1 + i);
        }
    }

    if (answer->empty())
    {
        answer->push_back(-1);
    }
}

BoyerMoore::BoyerMoore(std::string y, std::string x, int sigma)
{
    this->y = std::move(y);
    this->x = std::move(x);
    this->sigma = sigma;

    bmBc = new std::vector<int>();
    bmGs = new std::vector<int>();
    answer = new std::vector<int>();
}

void BoyerMoore::Calculate()
{
    BM();
}

BoyerMoore::~BoyerMoore()
{
    delete bmBc;
    delete bmGs;
    delete answer;
}
