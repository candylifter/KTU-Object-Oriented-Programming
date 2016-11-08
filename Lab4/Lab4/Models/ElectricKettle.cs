namespace Lab4
{
    public class ElectricKettle : Device
    {
        public double Power { get; set; }
        public double Capacity { get; set; }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as ElectricKettle);
        }

        public bool Equals(ElectricKettle other)
        {
            return Manufacturer == other.Manufacturer
                   && Model == other.Model
                   && EnergyClass == other.EnergyClass
                   && Color == other.Color
                   && Price == other.Price
                   && Power == other.Power
                   && Capacity == other.Capacity;
        }

        public override string ToString()
        {
            return string.Format(
                   @"Manufacturer: {0}, Model: {1}, Energy class: {2}, Color: {3}, Price: {4} Eur, Power: {5}, Capactiy: {6}",
                    Manufacturer, Model, EnergyClass, Color, Price, Power, Capacity);
        }
    }
}
