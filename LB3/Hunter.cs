using System;

namespace LB3
{
    internal class Hunter
    {
        public const int ArrowPrice = 5;
        private readonly Random _random = new Random();

        public string Name { get; }
        public int Health { get; private set; }
        public int Gold { get; private set; }
        public int Arrows { get; private set; }
        public int PreyCount { get; private set; }

        public Hunter(string name, int health, int gold, int arrows)
        {
            Name = name;
            Health = health;
            Gold = gold;
            Arrows = arrows;
        }

        public void Hunt()
        {
            if (Health <= 0)
            {
                Console.WriteLine($"{Name} не може полювати (0 HP).");
                return;
            }

            if (Arrows <= 0)
            {
                Console.WriteLine($"У {Name} немає стріл.");
                return;
            }

            Arrows--;
            if (_random.Next(1, 101) <= 70)
            {
                int reward = _random.Next(10, 26);
                int damage = _random.Next(3, 15);
                PreyCount++;
                Gold += reward;
                Health = Math.Max(0, Health - damage);
                Console.WriteLine($"{Name} вполював здобич! +1 здобич, +{reward} золота, -{damage} HP.");
            }
            else
            {
                int damage = _random.Next(10, 25);
                Health = Math.Max(0, Health - damage);
                Console.WriteLine($"{Name} промахнувся і втратив {damage} HP.");
            }
        }

        public void BuyArrows(int count)
        {
            if (count <= 0)
            {
                Console.WriteLine("Кількість має бути більшою за 0.");
                return;
            }

            int cost = count * ArrowPrice;
            if (Gold < cost)
            {
                Console.WriteLine($"Недостатньо золота (потрібно {cost}, є {Gold}).");
                return;
            }

            Gold -= cost;
            Arrows += count;
            Console.WriteLine($"{Name} купив {count} стріл за {cost} золота.");
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} | Здоров'я: {Health} | Золото: {Gold} | Стріли: {Arrows} | Здобич: {PreyCount}");
        }
    }
}
