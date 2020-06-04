using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Alg_07.Core;

namespace Alg_07.Console
{
    public class Program
    {
        private static string SearchAndOut(Action<int, Action<Vertex<int>>> search, int start, Graph<int> g)
        {
            var res = new List<int>();
            search(start, v => res.Add(v.Value));
            return String.Join(" ", res);
        }

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
                        "Вводите через Enter 2 номера вершины и вес через пробел, обозначающих дугу: ");

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

                    System.Console.WriteLine("Введите из какой вершины искать пути: ");
                    var a = Int32.Parse(System.Console.ReadLine());

                    var d = new Dijkstra<int>(g, g.V[a]);
                    d.Calc();

                    System.Console.WriteLine();
                    System.Console.WriteLine("от ->расстояние-> до: список дуг");

                    foreach (var (vertex, path) in d.Paths)
                    {
                        System.Console.WriteLine(
                            $"{a} ->{d.Distances[vertex]}-> {vertex.Value}: {String.Join(", ", path)}");
                    }

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
