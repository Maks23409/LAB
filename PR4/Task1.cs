using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace PR4
{
    public class TaskItem 
    {
        public string Title { get; set; } = "";
        public bool IsCompleted { get; set; }
    }

    public class Task1
    {
        public static void Run()
        {
            string path = "tasks.json";
            List<TaskItem> tasks = File.Exists(path)
                ? JsonSerializer.Deserialize<List<TaskItem>>(File.ReadAllText(path)) ?? new()
                : new();

            Console.WriteLine($"Завантажено задач: {tasks.Count}");
            tasks.Add(new TaskItem { Title = "Task " + (tasks.Count + 1), IsCompleted = false });

            var options = new JsonSerializerOptions { WriteIndented = true }; 
            File.WriteAllText(path, JsonSerializer.Serialize(tasks, options));
            Console.WriteLine("Стан збережено у tasks.json.");
        }
    }
}