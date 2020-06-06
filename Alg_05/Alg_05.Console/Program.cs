using System;
using System.IO;
using System.Text;

using Alg_05.Core;

namespace Alg_05.Console
{
    internal static class Program
    {
        private static void OutputBinaryFile(FileStream s)
        {
            System.Console.Write($"{Path.GetFileName(s.Name)}: ");
            var br = new BinaryReader(s);
            br.BaseStream.Seek(0, SeekOrigin.Begin);
            while (br.BaseStream.Position != br.BaseStream.Length)
            {
                System.Console.Write(br.ReadInt32());
                System.Console.Write(" ");
            }

            System.Console.WriteLine();
        }

        private static void Main(string[] args)
        {
            System.Console.InputEncoding = Encoding.UTF8;
            System.Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                try
                {
                    System.Console.WriteLine("Ввести данные в файл или произвести сортировку (1/2)?");
                    var ans = Int32.Parse(System.Console.ReadLine());
                    System.Console.WriteLine("Введите название файла:");
                    var path = System.Console.ReadLine();
                    switch (ans)
                    {
                        case 1:
                        {
                            using var bw = new BinaryWriter(new FileStream(path, FileMode.Create));
                            System.Console.WriteLine("Введите элементы через Enter:");
                            while (true)
                            {
                                var l = System.Console.ReadLine();
                                if (l == "")
                                {
                                    break;
                                }

                                var elem = Int32.Parse(l);
                                bw.Write(elem);
                            }

                            break;
                        }
                        case 2:
                        {
                            using var msh = new MergeSortFileHelper(path,
                                Path.GetFileNameWithoutExtension(path),
                                Path.GetExtension(path),
                                $"{Path.GetFileNameWithoutExtension(path)}_Result{Path.GetExtension(path)}");
                            msh.Sort.Sort();

                            OutputBinaryFile(msh.InputFile);
                            foreach (var i in msh.Files)
                            {
                                OutputBinaryFile(i);
                            }

                            OutputBinaryFile(msh.OutputFile);

                            break;
                        }
                        default:
                            throw new ApplicationException("Введите 1 или 2!");
                    }

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
