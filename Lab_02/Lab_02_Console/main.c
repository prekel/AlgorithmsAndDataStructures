/// \file
/// \brief Главная функция программы
/// \details Главная функция программы.
#include <stdio.h>
#include <malloc.h>

#include "Lib.h"

int main(int argc, char** argv)
{
    printf("Enter count: ");
    int count;
    scanf("%d", &count);

    int* a = (int*) malloc(count * sizeof(int));

    for (int i = 0; i < count; i++)
    {
        printf("Enter element %d: ", i);
        scanf("%d", &a[i]);
    }

    int max = MaxInArray(a, count);
    double aver = AverageInArray(a, count);

    printf("Max: %d\n", max);
    printf("Average: %lf\n", aver);

    free(a);

    return 0;
}
