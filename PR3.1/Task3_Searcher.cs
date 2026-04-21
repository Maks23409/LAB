using System;
using System.IO;
using System.Linq;

namespace PR3._1
{
    public class Task3_Searcher
    {
        public static void Run(string path)
        {
            if (!Directory.Exists(path)) return;

            DirectoryInfo di = new DirectoryInfo(path);
            var files = di.GetFiles("*.*", SearchOption.AllDirectories);

            var largest = files.OrderByDescending(f => f.Length).FirstOrDefault();

            if (largest != null)
            {
                Console.WriteLine($"Name: {largest.Name}");
                Console.WriteLine($"Size: {largest.Length} bytes");
                Console.WriteLine($"Path: {largest.FullName}");
            }
            else
            {
                Console.WriteLine("Файлів не знайдено.");
            }
        }
    }
}

