using System;
using System.IO;

namespace PR3._1
{
    public class Task4_Cleaner
    {
        public static void RunRecursive(string path)
        {
            int count = 0;
            long size = 0;

            if (!Directory.Exists(path)) return;

            CleanRecursive(new DirectoryInfo(path), ref count, ref size);
            Console.WriteLine($"[Рекурсія] Видалено: {count}, Розмір: {size} bytes");
        }

        private static void CleanRecursive(DirectoryInfo di, ref int count, ref long size)
        {
            foreach (var file in di.GetFiles())
            {
                size += file.Length;
                file.Delete();
                count++;
            }
            foreach (var dir in di.GetDirectories()) CleanRecursive(dir, ref count, ref size);
        }

        public static void RunIterative(string path)
        {
            if (!Directory.Exists(path)) return;

            int count = 0;
            long size = 0;
            var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

            foreach (var f in files)
            {
                FileInfo fi = new FileInfo(f);
                size += fi.Length;
                fi.Delete();
                count++;
            }
            Console.WriteLine($"[Цикл] Видалено: {count}, Розмір: {size} bytes");
        }
    }
}

