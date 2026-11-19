using System;
using System.Collections.Generic;
using System.Text;

namespace Module1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            DeliveryService service = new DeliveryService();

            Bike bike = new Bike();
            Car car = new Car();
            Truck truck = new Truck();
            List<ITransport> transports = new List<ITransport> { bike, car, truck };

            IPayment cash = new CashPayment();
            IPayment card = new CardPayment();

            Order order1 = new Order(1, "Ноутбук", 2.5, 6);
            Order order2 = new Order(2, "Набір посуду", 14, 18);
            Order order3 = new Order(3, "Сейф", 180, 25);
            Order order4 = new Order(4, "Кавомашина", 8, 14);

            service.AddOrder(order1);
            service.AddOrder(order2);
            service.AddOrder(order3);
            service.AddOrder(order4);

            service.ShowAvailableTransports(order1, transports);
            service.ShowAvailableTransports(order3, transports);
            service.ShowAvailableTransports(order4, transports);

            Console.WriteLine();
            service.AssignOrder(1, bike);
            service.AssignOrder(4, bike);
            service.AssignOrder(3, car);
            service.AssignOrder(2, car);
            service.AssignOrder(3, truck);

            service.ShowActiveOrders();

            Console.WriteLine();
            service.DeliverOrder(4, cash);
            service.DeliverOrder(1, card);
            service.DeliverOrder(2, cash);
            service.DeliverOrder(3, card);

            Console.WriteLine();
            service.AssignOrder(4, bike);
            service.AssignOrder(4, car);
            service.DeliverOrder(4, card);

            service.ShowActiveOrders();
            service.ShowHistory();
        }
    }
}
