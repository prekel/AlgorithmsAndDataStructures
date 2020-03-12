#include <algorithm>

#include "BoyerMoore.h"

void BoyerMoore::FullSuffixMatch()
{
    int n = x.size();
    int i = n;
    int j = n + 1;
    borderArray->at(i) = j;

    while (i > 0)
    {

        while (j <= n && x[i - 1] != x[j - 1])
        {
            if (shiftArray->at(j) == 0)
            {
                shiftArray->at(j) = j - i;
            }
            j = borderArray->at(j);
        }
        i--;
        j--;
        borderArray->at(i) = j;
    }
}

void BoyerMoore::PartialSuffixMatch()
{
    int n = x.size();
    int j;
    j = borderArray->at(0);

    for (int i = 0; i < n; i++)
    {
        if (shiftArray->at(i) == 0)
        {
            shiftArray->at(i) = j;
        }
        if (i == j)
        {
            j = borderArray->at(j);
        }
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
    if (m == 1)
    {
        for (auto i = 0; i < n; i++)
        {
            if (y[i] == x[0])
            {
                answer->push_back(i);
            }
        }
        return;
    }

    borderArray->assign(m + 1, 0);
    shiftArray->assign(m + 1, 0);

    FullSuffixMatch();
    PartialSuffixMatch();

    int shift = 0;

    while (shift <= (n - m))
    {
        int j = m - 1;
        while (j >= 0 && x[j] == y[shift + j])
        {
            j--;
        }

        if (j < 0)
        {
            answer->push_back(shift);
            shift += shiftArray->at(0);
        }
        else
        {
            shift += shiftArray->at(j + 1);
        }
    }

    if (answer->empty())
    {
        answer->push_back(-1);
    }
}

BoyerMoore::BoyerMoore(std::string y, std::string x)
{
    this->y = std::move(y);
    this->x = std::move(x);

    borderArray = new std::vector<int>();
    shiftArray = new std::vector<int>();
    answer = new std::vector<int>();
}

void BoyerMoore::Calculate()
{
    BM();
}

BoyerMoore::~BoyerMoore()
{
    delete borderArray;
    delete shiftArray;
    delete answer;
}
