using System;
using System.Collections.Generic;
using System.Text.Json;

namespace PR4
{
    public class Inventory { public List<string> Items { get; set; } = new(); }
    public class Player { public string Name { get; set; } = ""; public Inventory? Inventory { get; set; } }

    public class Task106 
    {
        public static void Run() {}
    }

    public class Task6
    {
        public static void Run()
        {
            string json = "{\"Name\":\"Hero\"}"; 
            Player p = JsonSerializer.Deserialize<Player>(json) ?? new();

            p.Inventory ??= new Inventory(); 
            Console.WriteLine($"Гравець: {p.Name}, Речей: {p.Inventory.Items.Count}");
        }
    }
}