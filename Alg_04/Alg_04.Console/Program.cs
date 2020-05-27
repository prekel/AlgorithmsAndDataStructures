using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Alg_04.Core;

namespace Alg_04.Console
{
    public class Program
    {
        private static void SortAndOut(AbstractSort<int> sort, IList<int> ar)
        {
            sort.Sort(ar);
            System.Console.WriteLine(String.Join(" ", ar));
            System.Console.WriteLine(
                $"Кол-во сравнений: {sort.CompareCount}, присваиваний: {sort.AssignmentCount}");
        }

        public static void Main(string[] args)
        {
            System.Console.InputEncoding = Encoding.UTF8;
            System.Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                try
                {
                    System.Console.WriteLine("Введите элементы через пробел: ");
                    var a = System.Console.ReadLine()
                        .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                        .Select(Int32.Parse)
                        .ToList();
                    var b = a.ToList();

                    var s1 = new ShakerSort<int>();
                    var s2 = new FastSort<int>();

                    System.Console.WriteLine("По возрастанию? [Y(Д)/n(н)]: ");
                    var ans = System.Console.ReadLine();
                    if (ans != "" && ans != "Y" && ans != "Д")
                    {
                        s1.Order = AbstractSort<int>.SortOrder.Descending;
                        s2.Order = AbstractSort<int>.SortOrder.Descending;
                    }

                    System.Console.WriteLine("Шейкерная сортирвка: ");
                    SortAndOut(s1, a);

                    System.Console.WriteLine("Быстрая сортировка: ");
                    SortAndOut(s2, b);

                    System.Console.ReadKey();

                    break;
                }
                catch (Exception e)
                {
                    System.Console.Error.WriteLine($"Ошибка: {e.Message}\n");
                }
            }
        }
    }
}
