using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace PR4
{
    public class Student 
    {
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public double AverageScore { get; set; }
    }

    public class Task2
    {
        public static void Run()
        {
            var students = new List<Student>
            {
                new Student { Name = "Олег", Age = 20, AverageScore = 4.5 },
                new Student { Name = "Анна", Age = 19, AverageScore = 4.8 },
                new Student { Name = "Іван", Age = 21, AverageScore = 3.9 },
                new Student { Name = "Марія", Age = 22, AverageScore = 5.0 },
                new Student { Name = "Петро", Age = 20, AverageScore = 4.2 }
            };

            string json = JsonSerializer.Serialize(students);
            File.WriteAllText("students.json", json);

            var restored = JsonSerializer.Deserialize<List<Student>>(File.ReadAllText("students.json"));
            restored?.ForEach(s => Console.WriteLine($"{s.Name}, бал: {s.AverageScore}"));
        }
    }
}