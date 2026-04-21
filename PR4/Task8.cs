using System;
using System.Text.Json;

namespace PR4
{
    public class Task8
    {
        public static void Run()
        {
            string badJson = "{ \"Name\": \"Bad\" --- }"; 
            try
            {
                JsonSerializer.Deserialize<Student>(badJson);
            }
           catch (JsonException ex) 
            {
                Console.WriteLine("Помилка! JSON-файл пошкоджено.");
                Console.WriteLine("Деталі: " + ex.Message);
            }
        }
    }
}