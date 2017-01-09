using System;

namespace Lab2.Individual.Step3
{
    public class Fridge
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public double Capacity { get; set; }
        public string EnergyClass { get; set; }
        public string InstallationType { get; set; }
        public string Color { get; set; }
        public bool HasFreezer { get; set; }
        public double Price { get; set; }
        public double Width { get; set; }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Fridge);
        }

        public bool Equals(Fridge fridge)
        {
            //tikrina, ar objektas egzistuoja
            if (Object.ReferenceEquals(fridge, null))
            {
                return false;
            }

            //Tikrina, ar tokia pati klasė
            if (this.GetType() != fridge.GetType())
                return false;

            // Grąžiname true, jei objektų laukai (savybės) sutampa.
            return (Manufacturer == fridge.Manufacturer) && (Model == fridge.Model);
        }

        public override int GetHashCode()
        {
            return Manufacturer.GetHashCode() ^ Model.GetHashCode();
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

        public static bool operator ==(Fridge lhs, Fridge rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Fridge lhs, Fridge rhs)
        {
            return !(lhs == rhs);
        }

        public override string ToString()
        {
            return string.Format(
                "Manufacturer: {0}, Model: {1}, Energy class: {2}, Color: {3}, Price: {4} Eur, Capacity: {5} l, Installation type: {6}, Has freezer?: {7}, Width: {8}",
                Manufacturer, Model, EnergyClass, Color, Price, Capacity, InstallationType, HasFreezer, Width);
        }
    }
}
