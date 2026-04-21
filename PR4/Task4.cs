using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PR4
{
    public enum OrderStatus { Pending, Processing, Completed }
    public class Order { public int Id { get; set; } public OrderStatus Status { get; set; } }

    public class Task4
    {
        public static void Run()
        {
            Order order = new Order { Id = 1, Status = OrderStatus.Processing };
            var options = new JsonSerializerOptions();
            options.Converters.Add(new JsonStringEnumConverter()); 

            string json = JsonSerializer.Serialize(order, options);
            Console.WriteLine("Enum у форматі тексту:\n" + json);
        }
    }
}