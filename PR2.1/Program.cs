using System;

namespace PracticalWork2
{

    public class TemperatureSensor
    {

        public event Action<float> OnTemperatureChanged;

        private float _currentTemperature;

        public void SetTemperature(float newTemp)
        {
            Console.WriteLine($"\n>>> Датчик зафіксував температуру: {newTemp}°C");
            _currentTemperature = newTemp;


            OnTemperatureChanged?.Invoke(_currentTemperature);
        }
    }


    public class Display
    {
        public void Update(float temp) => Console.WriteLine($"[Екран]: Поточна температура {temp}°C");
    }

    public class AirConditioner
    {
        public void Update(float temp)
        {
            if (temp < 17) Console.WriteLine("[Кондиціонер]: Увімкнено ОБІГРІВ");
            else if (temp > 25) Console.WriteLine("[Кондиціонер]: Увімкнено ОХОЛОДЖЕННЯ");
            else Console.WriteLine("[Кондиціонер]: Вимкнено (комфортна зона)");
        }
    }

    public class SecuritySystem
    {
        public void Update(float temp)
        {
            if (temp > 40) Console.WriteLine("[БЕЗПЕКА]: УВАГА! Перегрів системи!");
            if (temp < 5) Console.WriteLine("[БЕЗПЕКА]: УВАГА! Ризик замерзання!");
        }
    }



    public class Player
    {
        public event Action<int> OnDamageReceived;
        public int Health { get; private set; } = 100;

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
            Console.WriteLine($"\n--- Гравця вдарили! Урон: {damage}. Залишилось HP: {Health} ---");


            OnDamageReceived?.Invoke(Health);
        }
    }


    public class UIHealthBar
    {
        public void OnHealthChanged(int hp) => Console.WriteLine($"[UI]: Смужка здоров'я оновлена: {hp}%");
    }

    public class SoundSystem
    {
        public void OnHealthChanged(int hp)
        {
            Console.WriteLine("[Звук]: *Ай!* (звук отримання урону)");
            if (hp <= 20 && hp > 0) Console.WriteLine("[Звук]: *Тук-тук... тук-тук...* (критичний стан)");
        }
    }

    public class AchievementSystem
    {
        public void OnHealthChanged(int hp)
        {
            if (hp <= 0) Console.WriteLine("[Досягнення]: 'Невдалий забіг' - отримано!");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;


            Console.WriteLine("=== ТЕСТ СИСТЕМИ КЛІМАТУ ===");
            TemperatureSensor sensor = new TemperatureSensor();

            Display display = new Display();
            AirConditioner ac = new AirConditioner();
            SecuritySystem security = new SecuritySystem();


            sensor.OnTemperatureChanged += display.Update;
            sensor.OnTemperatureChanged += ac.Update;
            sensor.OnTemperatureChanged += security.Update;


            sensor.SetTemperature(20);
            sensor.SetTemperature(30);
            sensor.SetTemperature(2);

            Console.WriteLine("\n\n---------------------------------");


            Console.WriteLine("=== ТЕСТ ІГРОВОЇ СИСТЕМИ ===");
            Player player = new Player();

            UIHealthBar ui = new UIHealthBar();
            SoundSystem sound = new SoundSystem();
            AchievementSystem achievements = new AchievementSystem();

            player.OnDamageReceived += ui.OnHealthChanged;
            player.OnDamageReceived += sound.OnHealthChanged;
            player.OnDamageReceived += achievements.OnHealthChanged;


            player.TakeDamage(30);
            player.TakeDamage(55);
            player.TakeDamage(20);

            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}