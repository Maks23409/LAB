using System;
using System.IO;
using System.Linq;

namespace PR3._1
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Length > 0)
            {
                AnalyzeCLI(args[0]);
                return;
            }

            while (true)
            {
                Console.WriteLine("\n=== Практична №3 ===");
                Console.WriteLine("1. Завдання 1 (Аналізатор)");
                Console.WriteLine("2. Завдання 2 (Інспектор)");
                Console.WriteLine("3. Завдання 3 (Найбільший файл)");
                Console.WriteLine("4. Завдання 4 (Очищення кешу)");
                Console.WriteLine("0. Вихід");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();
                if (choice == "0") break;

                switch (choice)
                {
                    case "1":
                        Task1_Analyzer.Run();
                        break;
                    case "2":
                        Console.Write("Введіть шлях: ");
                        Task2_Inspector.Run(Console.ReadLine() ?? "");
                        break;
                    case "3":
                        Console.Write("Введіть шлях: ");
                        Task3_Searcher.Run(Console.ReadLine() ?? "");
                        break;
                    case "4":
                        Console.Write("Введіть шлях до кешу: ");
                        Task4_Cleaner.RunRecursive(Console.ReadLine() ?? "");
                        break;
                }
            }
        }

        static void AnalyzeCLI(string path)
        {
            if (!Directory.Exists(path)) return;
            DirectoryInfo di = new DirectoryInfo(path);
            var files = di.GetFiles("*.*", SearchOption.AllDirectories);

            Console.WriteLine($"Folders: {di.GetDirectories("*", SearchOption.AllDirectories).Length}");
            Console.WriteLine($"Files: {files.Length}");
            Console.WriteLine($"Total size: {files.Sum(f => f.Length) / 1024 / 1024} MB");
            var max = files.OrderByDescending(f => f.Length).FirstOrDefault();
            Console.WriteLine($"Largest file: {max?.Name ?? "N/A"}");
        }
    }
}
