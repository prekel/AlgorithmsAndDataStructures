#include "BoyerMoore.h"

#include <algorithm>
#include <utility>

void BoyerMoore::FullSuffixMatch()
{
    int n = x.size();       //find length of pattern
    int i = n;
    int j = n + 1;
    borderArray->at(i) = j;

    while (i > 0)
    {
        //search right when (i-1)th and (j-1)th item are not same
        while (j <= n && x[i - 1] != x[j - 1])
        {
            if (shiftArray->at(j) == 0)
            {
                shiftArray->at(j) = j - i;
            }     //shift pattern from i to j
            j = borderArray->at(j);       //update border
        }
        i--;
        j--;
        borderArray->at(i) = j;
    }
}

void BoyerMoore::PartialSuffixMatch()
{
    int n = x.size();    //find length of pattern
    int j;
    j = borderArray->at(0);

    for (int i = 0; i < n; i++)
    {
        if (shiftArray->at(i) == 0)
        {
            shiftArray->at(
                    i) = j;
        }        //when shift is 0, set shift to border value
        if (i == j)
            j = borderArray->at(j);    //update border value
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

    borderArray->assign(m + 1, 0);
    shiftArray->assign(m + 1, 0);

    FullSuffixMatch();
    PartialSuffixMatch();

    //int patLen = pattern.size();
    //int strLen = mainString.size();
    //int borderArray[patLen+1];
    //int shiftArray[patLen + 1];

    for (int i = 0; i <= m; i++)
    {
        shiftArray->at(i) = 0;     //set all shift array to 0
    }

    FullSuffixMatch();
    PartialSuffixMatch();
    int shift = 0;

    while (shift <= (n - m))
    {
        int j = m - 1;
        while (j >= 0 && x[j] == y[shift + j])
        {
            j--;         //reduce j when pattern and main string character is matching
        }

        if (j < 0)
        {
            answer->push_back(shift);
            //(*index)++;
            //array[(*index)] = shift;
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

BoyerMoore::BoyerMoore(std::string y, std::string x, int sigma)
{
    this->y = std::move(y);
    this->x = std::move(x);
    this->sigma = sigma;

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
