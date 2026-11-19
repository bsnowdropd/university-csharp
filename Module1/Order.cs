namespace Module1
{
    internal class Order
    {
        public int Id { get; }
        public string Description { get; }
        public double Weight { get; }
        public double Distance { get; }
        public ITransport? AssignedTransport { get; set; }
        public double DeliveryCost { get; set; }
        public string? PaymentMethod { get; set; }
        public bool IsDelivered { get; set; }

        public Order(int id, string description, double weight, double distance)
        {
            Id = id;
            Description = description;
            Weight = weight;
            Distance = distance;
        }

        public override string ToString()
        {
            if (IsDelivered)
            {
                return $"#{Id} {Description} ({Weight} кг, {Distance} км) - Доставлено ({AssignedTransport?.Name}, {DeliveryCost:F2} грн, {PaymentMethod})";
            }

            string transport = AssignedTransport == null ? "не призначено" : AssignedTransport.Name;
            return $"#{Id} {Description} ({Weight} кг, {Distance} км) - Активне (транспорт: {transport})";
        }
    }
}
