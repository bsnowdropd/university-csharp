using System;

namespace Module1
{
    internal interface IPayment
    {
        string MethodName { get; }
        void Pay(double amount, Order order);
    }

    internal class CashPayment : IPayment
    {
        public string MethodName => "Готівка";

        public void Pay(double amount, Order order)
        {
            Console.WriteLine($"Оплата готівкою: {amount:F2} грн (замовлення #{order.Id}).");
        }
    }

    internal class CardPayment : IPayment
    {
        public string MethodName => "Картка";

        public void Pay(double amount, Order order)
        {
            Console.WriteLine($"Оплата карткою: {amount:F2} грн (замовлення #{order.Id}).");
        }
    }
}
