using System;
using System.Text;

namespace LB3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Hunter hunter1 = new Hunter("Тарас", 100, 25, 5);
            Hunter hunter2 = new Hunter("Назар", 100, 20, 5);

            Console.WriteLine("Початкова інформація:");
            hunter1.ShowInfo();
            hunter2.ShowInfo();

            while (true)
            {
                Console.WriteLine("\n1. Тарас: полювати");
                Console.WriteLine("2. Тарас: купити стріли (5 зол.)");
                Console.WriteLine("3. Назар: полювати");
                Console.WriteLine("4. Назар: купити стріли (5 зол.)");
                Console.WriteLine("5. Показати інформацію");
                Console.WriteLine("0. Завершити змагання");
                Console.Write("Вибір: ");

                string? choice = Console.ReadLine();
                if (choice == null || choice == "0") break;

                switch (choice)
                {
                    case "1":
                        hunter1.Hunt();
                        break;
                    case "2":
                        BuyArrowsFor(hunter1);
                        break;
                    case "3":
                        hunter2.Hunt();
                        break;
                    case "4":
                        BuyArrowsFor(hunter2);
                        break;
                    case "5":
                        hunter1.ShowInfo();
                        hunter2.ShowInfo();
                        break;
                    default:
                        Console.WriteLine("Невідома команда.");
                        break;
                }
            }

            Console.WriteLine("\nРезультати змагання:");
            hunter1.ShowInfo();
            hunter2.ShowInfo();

            if (hunter1.PreyCount > hunter2.PreyCount)
            {
                Console.WriteLine($"Переможець: {hunter1.Name}!");
            }
            else if (hunter2.PreyCount > hunter1.PreyCount)
            {
                Console.WriteLine($"Переможець: {hunter2.Name}!");
            }
            else
            {
                Console.WriteLine("Нічия!");
            }
        }

        static void BuyArrowsFor(Hunter hunter)
        {
            Console.Write("Скільки стріл купити: ");
            if (int.TryParse(Console.ReadLine(), out int count))
            {
                hunter.BuyArrows(count);
            }
            else
            {
                Console.WriteLine("Некоректне число.");
            }
        }
    }
}
