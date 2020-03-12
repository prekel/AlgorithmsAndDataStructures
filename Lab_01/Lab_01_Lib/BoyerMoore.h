#ifndef BOYERMOORE_H
#define BOYERMOORE_H

#include <string>
#include <vector>

class BoyerMoore
{
private:
    std::string y; // строка
    std::string x; // образец

    std::vector<int>* borderArray;
    std::vector<int>* shiftArray;
    std::vector<int>* answer;

    void FullSuffixMatch();
    void PartialSuffixMatch();
    void BM();
public:
    BoyerMoore(std::string y, std::string x);

    void Calculate();
    std::vector<int>* GetAnswer()
    {
        return answer;
    }

    ~BoyerMoore();
};

#endif //BOYERMOORE_H
