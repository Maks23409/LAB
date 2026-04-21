using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PR4
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")] 
    [JsonDerivedType(typeof(Dog), "dog")]
    [JsonDerivedType(typeof(Cat), "cat")]
    public abstract class Animal { public string Name { get; set; } = ""; }
    public class Dog : Animal { public int BarkVolume { get; set; } }
    public class Cat : Animal { public int Lives { get; set; } }

    public class Task5
    {
        public static void Run()
        {
            var animals = new List<Animal> { new Dog { Name = "Рекс" }, new Cat { Name = "Мурка" } };
            string json = JsonSerializer.Serialize(animals);
            var restored = JsonSerializer.Deserialize<List<Animal>>(json);

            restored?.ForEach(a => Console.WriteLine($"Тип: {a.GetType().Name}, Ім'я: {a.Name}"));
        }
    }
}