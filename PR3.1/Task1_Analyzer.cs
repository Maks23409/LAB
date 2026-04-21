using System;
using System.IO;

namespace PR3._1
{
    public class Task1_Analyzer
    {
        public static void Run()
        {
            string inputPath = "story.txt";
            string outputPath = "report.txt";

            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "Це приклад тексту для аналізу.\nДругий рядок файлу.");
            }

            int lineCount = 0;
            int wordCount = 0;
            long charCount = 0;

            using (StreamReader reader = new StreamReader(inputPath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lineCount++;
                    charCount += line.Length;
                    wordCount += line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
                }
            }

            File.WriteAllText(outputPath, $"Кількість рядків: {lineCount}\nКількість слів: {wordCount}\nКількість символів: {charCount}");
            Console.WriteLine("Статистику успішно збережено в report.txt");
        }
    }
}
