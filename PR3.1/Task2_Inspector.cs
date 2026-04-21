using System;
using System.IO;

namespace PR3._1
{
    public class Task2_Inspector
    {
        public static void Run(string path)
        {
            if (!Directory.Exists(path))
            {
                Console.WriteLine("Шлях не знайдено.");
                return;
            }

            Console.WriteLine("\n--- Підпапки: ---");
            foreach (var dir in Directory.GetDirectories(path))
            {
                Console.WriteLine($"[DIR] {Path.GetFileName(dir)}");
            }

            Console.WriteLine("\n--- Файли: ---");
            foreach (var file in Directory.GetFiles(path))
            {
                FileInfo info = new FileInfo(file);
                Console.WriteLine($"{info.Name} | {info.Length} bytes | {info.CreationTime}");
            }
        }
    }
}
