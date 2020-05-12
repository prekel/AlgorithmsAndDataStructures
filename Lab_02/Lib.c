#include "Lib.h"

int MaxInArray(const int* array, int count)
{
    int max = array[0];
    for (int i = 0; i < count; i++)
    {
        if (max < array[i])
        {
            max = array[i];
        }
    }
    return max;
}

int MinInArray(const int* array, int count)
{
    int min = array[0];
    for (int i = 0; i < count; i++)
    {
        if (min > array[i])
        {
            min = array[i];
        }
    }
    return min;
}

double AverageInArray(const int* array, int count)
{
    double sum = 0;
    for (int i = 0; i < count; i++)
    {
        sum += array[i];
    }
    return sum / count;
}
