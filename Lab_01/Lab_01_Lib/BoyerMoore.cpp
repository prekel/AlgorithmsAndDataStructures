#include "BoyerMoore.h"

#include <algorithm>
#include <utility>

void BoyerMoore::PreBmBc()
{
    auto m = x.length();
    bmBc->assign(sigma, m);
    for (auto i = 0; i < m - 1; i++)
    {
        bmBc->at(x[i]) = m - 1 - i;
    }
}

bool BoyerMoore::IsPrefix(int p)
{
    int m = x.length();
    int suffixlen = m - p;
    for (int i = 0; i < suffixlen; i++) {
        if (x[i] != x[p+i]) {
            return false;
        }
    }
    return true;
}

int BoyerMoore::SuffixLength(int p)
{
    auto m = x.length();
    int i = 0;
    //for (i = 0; (x->at(p - i) == x->at(m - 1 - i)) && (i < p); i++);
    while ((x.at(p - i) == x.at(m - 1 - i)) && (i < p))
    {
        i++;
    }
    return i;
}

void BoyerMoore::PreBmGs()
{
    int p;

    int m = x.length();
    size_t last_prefix_index = m - 1;
    bmGs->assign(m, 0);
    // first loop
    for (p = m - 1; p >= 0; p--)
    {
        if (IsPrefix(p + 1))
        {
            last_prefix_index = p + 1;
        }
        bmGs->at(p) = last_prefix_index + (m - 1 - p);
    }

    // second loop
    for (p = 0; p < m - 1; p++)
    {
        size_t slen = SuffixLength(p);
        if (x[p - slen] != x[m - 1 - slen])
        {
            bmGs->at(m - 1 - slen) = m - 1 - p + slen;
        }
    }
    //int m = x.length();
//    auto lastPrefixPosition = m;
//    bmGs->assign(m, 0);
//    for (auto i = m - 1; i >= 0; i--)
//    {
//        if (IsPrefix(i + 1))
//        {
//            lastPrefixPosition = i + 1;
//        }
//        bmGs->at(m - 1 - i) = lastPrefixPosition - i + m - 1;
//    }
//    for (auto i = 0; i <= m - 2; i++)
//    {
//        auto slen = SuffixLength(i);
//        bmGs->at(slen) = m - 1 - i + slen;
//    }
}

void BoyerMoore::BM()
{
    auto m = x.length();
    auto n = y.length();

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
        while (x[j] == y[i])
        {
            if (j == 0)
            {
                answer->push_back(i);
            }
            i--;
            j--;
        }
        i += std::max(bmGs->at(m - 1 - j), bmBc->at(y.at(i)));
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
