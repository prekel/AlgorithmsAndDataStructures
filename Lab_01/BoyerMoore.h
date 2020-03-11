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

    void PreBmBc();
    bool IsPrefix(int p);
    int SuffixLength(int p);
    void PreBmGs();
    void BM();

public:
    BoyerMoore(std::string y, std::string x);
    void Calculate();
};


#endif //BOYERMOORE_H
