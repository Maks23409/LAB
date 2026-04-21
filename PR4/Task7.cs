using System;
using System.Text.Json;

namespace PR4
{
    public class PlayerNew 
    {
        public string Name { get; set; } = "";
        public int Level { get; set; } = 1;
    }

    public class Task7
    {
        public static void Run()
        {
            string oldJson = "{\"Name\":\"OldPlayer\"}";
            var p = JsonSerializer.Deserialize<PlayerNew>(oldJson);
            Console.WriteLine($"Ім'я: {p?.Name}, Рівень (default): {p?.Level}");
        }
    }
}