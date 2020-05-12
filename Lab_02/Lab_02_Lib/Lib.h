/// \file
/// \brief Объявления функций для алгоритмов
/// \details Объявления функций для алгоритмов поиска наибольшего
/// значения и среднего.

#ifndef LIB_H
#define LIB_H

/// Ищет значение максимального элемента в массиве.
/// \param array Указатель на массив.
/// \param count Кол-во элементов в массиве.
/// \return Максимальный элемент в массиве.
int MaxInArray(const int* array, int count);

/// Вычисляет среднее арифметическое значение элементов массива.
/// \param array Указатель на массив.
/// \param count Кол-во элементов в массиве.
/// \return Среднее арифметическое значение.
double AverageInArray(const int* array, int count);

#endif //LIB_H
