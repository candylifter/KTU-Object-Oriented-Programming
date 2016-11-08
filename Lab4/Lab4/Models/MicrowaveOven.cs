namespace Lab4
{
    public class MicrowaveOven : Device
    {
        public double Power { get; set; }
        public int ProgramCount { get; set; }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as MicrowaveOven);
        }

        public bool Equals(MicrowaveOven other)
        {
            return Manufacturer == other.Manufacturer
                   && Model == other.Model
                   && EnergyClass == other.EnergyClass
                   && Color == other.Color
                   && Price == other.Price
                   && Power == other.Power
                   && ProgramCount == other.ProgramCount;
        }

        public override string ToString()
        {
            return string.Format(
                   @"Manufacturer: {0}, Model: {1}, Energy class: {2}, Color: {3}, Price: {4} Eur, Power: {5}, Program count: {6}",
                    Manufacturer, Model, EnergyClass, Color, Price, Power, ProgramCount);
        }
    }
}
