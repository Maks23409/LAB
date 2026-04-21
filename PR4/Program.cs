using System;

namespace PR4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== ПРАКТИЧНА РОБОТА №4 ===");
                Console.WriteLine("1. Завдання 1 | 2. Завдання 2 | 3. Завдання 3");
                Console.WriteLine("4. Завдання 4 | 5. Завдання 5 | 6. Завдання 6");
                Console.WriteLine("7. Завдання 7 | 8. Завдання 8 | 0. Вихід");
                Console.Write("\nОберіть номер: ");

                string choice = Console.ReadLine();
                Console.WriteLine("\n--- Результат ---");

                switch (choice)
                {
                    case "1": Task1.Run(); break;
                    case "2": Task2.Run(); break;
                    case "3": Task3.Run(); break;
                    case "4": Task4.Run(); break;
                    case "5": Task5.Run(); break;
                    case "6": Task6.Run(); break;
                    case "7": Task7.Run(); break;
                    case "8": Task8.Run(); break;
                    case "0": return;
                    default: Console.WriteLine("Невірний вибір."); break;
                }
                Console.WriteLine("\nНатисніть Enter для продовження...");
                Console.ReadLine();
            }
        }
    }
}