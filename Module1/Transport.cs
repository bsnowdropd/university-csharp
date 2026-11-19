namespace Module1
{
    internal interface ITransport
    {
        string Name { get; }
        bool IsAvailable { get; set; }
        double CalculateCost(Order order);
        bool CanTake(Order order);
    }

    internal abstract class Transport : ITransport
    {
        public string Name { get; }
        public double MaxWeight { get; }
        public bool IsAvailable { get; set; } = true;

        protected Transport(string name, double maxWeight)
        {
            Name = name;
            MaxWeight = maxWeight;
        }

        public abstract double CalculateCost(Order order);

        public virtual bool CanTake(Order order)
        {
            return order.Weight <= MaxWeight;
        }
    }

    internal class Bike : Transport
    {
        public Bike() : base("Велосипед", 10) { }

        public override double CalculateCost(Order order)
        {
            return 20 + 5 * order.Distance;
        }

        public override bool CanTake(Order order)
        {
            return base.CanTake(order) && order.Distance <= 10;
        }
    }

    internal class Car : Transport
    {
        public Car() : base("Автомобіль", 150) { }

        public override double CalculateCost(Order order)
        {
            return 50 + 8 * order.Distance + 1 * order.Weight;
        }
    }

    internal class Truck : Transport
    {
        public Truck() : base("Вантажівка", 2000) { }

        public override double CalculateCost(Order order)
        {
            return 200 + 15 * order.Distance + 0.5 * order.Weight;
        }
    }
}
