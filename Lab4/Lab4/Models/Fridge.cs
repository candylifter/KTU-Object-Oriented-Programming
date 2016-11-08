namespace Lab4
{
    public class Fridge : Device
    {
        public double Capacity { get; set; }
        public string InstallationType { get; set; }
        public bool HasFreezer { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Depth { get; set; }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Fridge);
        }

        public bool Equals(Fridge other)
        {
            return Manufacturer == other.Manufacturer
                   && Model == other.Model
                   && EnergyClass == other.EnergyClass
                   && Color == other.Color
                   && Price == other.Price
                   && Capacity == other.Capacity
                   && InstallationType == other.InstallationType
                   && HasFreezer == other.HasFreezer
                   && Height == other.Height
                   && Width == other.Width
                   && Depth == other.Depth;
        }

        public static bool operator <=(Fridge lhs, Fridge rhs)
        {
            return lhs.Price <= rhs.Price;
        }

        public static bool operator <(Fridge lhs, Fridge rhs)
        {
            return lhs.Price < rhs.Price;
        }

        public static bool operator >(Fridge lhs, Fridge rhs)
        {
            return lhs.Price > rhs.Price;
        }

        public static bool operator >=(Fridge lhs, Fridge rhs)
        {
            return lhs.Price >= rhs.Price;
        }

        public override string ToString()
        {
            return string.Format(
                    "Manufacturer: {0}, Model: {1}, Energy class: {2}, Color: {3}, Price: {4} Eur, Capacity: {5} l, Installation type: {6}, Has freezer?: {7}, Height: {8}, Width: {9}, Depth: {10}",
                    Manufacturer, Model, EnergyClass, Color, Price, Capacity, InstallationType, HasFreezer, Height,Width, Depth);
        }
    }
}
