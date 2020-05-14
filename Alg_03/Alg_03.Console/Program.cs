using System;
using System.Linq;
using System.Text;
using Alg_03.Core;

namespace Alg_03.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Console.InputEncoding = Encoding.UTF8;
            System.Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                System.Console.WriteLine("Введите элементы через пробел:");
                try
                {
                    var a = System.Console.ReadLine()
                        .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                        .Select(p => Int32.Parse(p))
                        .ToList();
                    var s = new InclusionSort<int>();
                    s.Sort(a);
                    System.Console.WriteLine(String.Join(" ", a));
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
