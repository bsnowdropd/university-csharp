using System;
using System.Collections.Generic;
using System.Linq;

namespace Module1
{
    internal class DeliveryService
    {
        private readonly List<Order> _activeOrders = new List<Order>();
        private readonly List<Order> _history = new List<Order>();

        public void AddOrder(Order order)
        {
            _activeOrders.Add(order);
        }

        public void ShowAvailableTransports(Order order, List<ITransport> transports)
        {
            Console.WriteLine($"\nВартість доставки для замовлення #{order.Id} ({order.Description}):");
            foreach (ITransport transport in transports)
            {
                if (transport.CanTake(order))
                {
                    Console.WriteLine($"  {transport.Name}: {transport.CalculateCost(order):F2} грн");
                }
            }
        }

        public void AssignOrder(int orderId, ITransport transport)
        {
            Order? order = _activeOrders.FirstOrDefault(o => o.Id == orderId);
            if (order == null)
            {
                Console.WriteLine($"Замовлення #{orderId} не знайдено.");
                return;
            }

            if (!transport.IsAvailable)
            {
                Console.WriteLine($"Транспорт \"{transport.Name}\" зараз зайнятий.");
                return;
            }

            if (!transport.CanTake(order))
            {
                Console.WriteLine($"Транспорт \"{transport.Name}\" не може взяти замовлення #{order.Id} через обмеження.");
                return;
            }

            transport.IsAvailable = false;
            order.AssignedTransport = transport;
            Console.WriteLine($"Замовлення #{order.Id} призначено на {transport.Name}.");
        }

        public void DeliverOrder(int orderId, IPayment payment)
        {
            Order? order = _activeOrders.FirstOrDefault(o => o.Id == orderId);
            if (order == null || order.AssignedTransport == null)
            {
                Console.WriteLine($"Неможливо доставити замовлення #{orderId}.");
                return;
            }

            ITransport transport = order.AssignedTransport;
            double cost = transport.CalculateCost(order);

            payment.Pay(cost, order);
            order.DeliveryCost = cost;
            order.PaymentMethod = payment.MethodName;
            order.IsDelivered = true;

            transport.IsAvailable = true;
            _activeOrders.Remove(order);
            _history.Add(order);
            Console.WriteLine($"Замовлення #{order.Id} доставлено, {transport.Name} вільний.");
        }

        public void ShowActiveOrders()
        {
            Console.WriteLine("\nАктивні замовлення:");
            if (_activeOrders.Count == 0)
            {
                Console.WriteLine("  немає");
                return;
            }

            foreach (Order order in _activeOrders)
            {
                Console.WriteLine($"  {order}");
            }
        }

        public void ShowHistory()
        {
            Console.WriteLine("\nІсторія доставок:");
            if (_history.Count == 0)
            {
                Console.WriteLine("  порожня");
                return;
            }

            foreach (Order order in _history)
            {
                Console.WriteLine($"  {order}");
            }
        }
    }
}
