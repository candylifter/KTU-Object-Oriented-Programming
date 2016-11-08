using System;

namespace Lab3
{
    class AnimalMarked : Animal
    {
        public int ChipId { get; set; }

        public override int GetHashCode()
        {
            return ChipId.GetHashCode() ^ Name.GetHashCode();
        }

        public bool Equals(AnimalMarked animal)
        {
            if (Object.ReferenceEquals(animal, null))
            {
                return false;
            }

            if (this.GetType() != animal.GetType())
            {
                return false;
            }

            return (ChipId == animal.ChipId) && (Name == animal.Name);
        }

        public static bool operator <=(AnimalMarked lhs, AnimalMarked rhs)
        {
            return (lhs.ChipId <= rhs.ChipId);
        }

        public static bool operator >=(AnimalMarked lhs, AnimalMarked rhs)
        {
            return (lhs.ChipId >= rhs.ChipId);
        }
    }
}
