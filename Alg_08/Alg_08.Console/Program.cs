using System;
using System.Linq;
using System.Text;

using Alg_08.Core;

namespace Alg_08.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Console.InputEncoding = Encoding.UTF8;
            System.Console.OutputEncoding = Encoding.UTF8;

            var g = new Graph<int>();

            while (true)
            {
                try
                {
                    System.Console.WriteLine("Введите номера вершин через пробел: ");
                    var a = System.Console.ReadLine()
                        .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                        .Select(Int32.Parse)
                        .Distinct()
                        .Select(g.AddVertex)
                        .ToList();

                    break;
                }
                catch (Exception e)
                {
                    System.Console.Error.WriteLine($"Ошибка: {e.Message}\n");
                }
            }

            while (true)
            {
                try
                {
                    System.Console.WriteLine(
                        "Введите через Enter 2 номера вершины и вес через пробел, обозначающих ребро: ");

                    while (true)
                    {
                        var es = System.Console.ReadLine();
                        if (es == "")
                        {
                            break;
                        }

                        var esp = es.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToList();

                        if (esp.Count == 3)
                        {
                            g.AddEdge(Int32.Parse(esp[0]), Int32.Parse(esp[1]), Double.Parse(esp[2]));
                        }
                    }

                    break;
                }
                catch (Exception e)
                {
                    System.Console.Error.WriteLine($"Ошибка: {e.Message}\n");
                }
            }

            while (true)
            {
                try
                {
                    System.Console.WriteLine($"Вершины графа: {g.V}");
                    System.Console.WriteLine($"Рёбра графа: {g.E}");

                    System.Console.WriteLine();

                    var p = new Prim<int>(g);
                    p.Calc();

                    System.Console.WriteLine($"Вес минимального остовного дерева: {p.MstWeight}");
                    System.Console.WriteLine($"Рёбра минимального остовного дерева: {String.Join(", ", p.Mst)}");

                    break;
                }
                catch (Exception e)
                {
                    System.Console.Error.WriteLine($"Ошибка: {e.Message}\n");
                }
            }

            System.Console.ReadKey();
        }
    }
}
