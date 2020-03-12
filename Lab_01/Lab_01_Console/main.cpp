#include <cstdio>
#include <iostream>
#include <algorithm>

#ifdef _MSC_VER
#include <Windows.h>
#elif _WIN32
#include <windows.h>
#endif

#include "BoyerMoore.h"

int main(int argc, char** argv)
{
#ifdef _WIN32
    SetConsoleOutputCP(CP_UTF8);
    SetConsoleCP(CP_UTF8);
#endif

    std::cout << "Введите строку (в которой проводится поиск): ";
    std::string y;
    std::getline(std::cin, y);

    std::cout << "Введите образ (который ищется в строке): ";
    std::string x;
    std::getline(std::cin, x);

    std::cout << "Чувствительно к регистру? [Y/n]: ";
    std::string t;
    std::getline(std::cin, t);

    auto bm = BoyerMoore(y, x, t[0] == 'N' || t[0] == 'n');
    bm.Calculate();
    auto ans = bm.GetAnswer();

    std::cout << "Индексы образа в строке: ";
    for (auto i : *ans)
    {
        std::cout << i << ((i == ans->back()) ? "" : ", ");
    }
    std::cout << std::endl;

    std::cout << "Строка с помеченными образами: ";
    for (auto i = 0, j = -1; i < y.size(); i++)
    {
        if (std::count(ans->begin(), ans->end(), i))
        {
            std::cout << "[";
            j = x.size() - 1;
        }
        std::cout << y[i];
        if (j-- == 0)
        {
            std::cout << "]";
        }
    }
    std::cout << std::endl;

    return 0;
}
