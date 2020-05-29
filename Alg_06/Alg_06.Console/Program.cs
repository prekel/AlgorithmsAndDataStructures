using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Alg_06.Core;

namespace Alg_06.Console
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

            while (true)
            {
                try
                {
                    var g = new Graph<int>();

                    System.Console.WriteLine("Введите номера вершин через пробел: ");
                    var a = System.Console.ReadLine()
                        .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                        .Select(Int32.Parse)
                        .Select(g.AddVertex)
                        .ToList();

                    System.Console.WriteLine("Вводите через Enter 2 номера вершины через пробел, обозначающих ребро: ");

                    while (true)
                    {
                        var es = System.Console.ReadLine();
                        if (es == "")
                        {
                            break;
                        }

                        var esp = es.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                            .Select(Int32.Parse)
                            .ToList();

                        if (esp.Count == 2)
                        {
                            g.AddEdge(esp[0], esp[1]);
                        }
                    }

                    System.Console.WriteLine("С какой вершины начать обход?");
                    var s = Int32.Parse(System.Console.ReadLine());

                    System.Console.WriteLine($"Поиск в глубину: {SearchAndOut(g.Dfs, s, g)}");
                    System.Console.WriteLine($"Поиск в ширину: {SearchAndOut(g.Bfs, s, g)}");

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
