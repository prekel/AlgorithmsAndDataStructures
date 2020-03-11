#ifndef BOYERMOORE_H
#define BOYERMOORE_H

#include <string>
#include <vector>

class BoyerMoore
{
private:
    int sigma;
    std::string* y; // строка
    std::string* x; // образец

    std::vector<int>* bmBc;
    std::vector<int>* bmGs;
    std::vector<int>* answer;

public:
    BoyerMoore(std::string y, std::string x, int sigma);

    void PreBmBc();

    bool IsPrefix(int p);

    int SuffixLength(int p);

    void PreBmGs();

    void BM();

    void Calculate();

    std::vector<int>* GetBmBc()
    {
        return bmBc;
    }

    std::vector<int>* GetBmGs()
    {
        return bmGs;
    }

    std::vector<int>* GetAnswer()
    {
        return answer;
    }

    ~BoyerMoore();
};

#endif //BOYERMOORE_H
