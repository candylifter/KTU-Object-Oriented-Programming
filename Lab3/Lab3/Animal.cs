using System;

namespace Lab3
{
    class Animal
    {
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Owner { get; set; }
        public string Phone { get; set; }
        public DateTime VaccinationDate { get; set; }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Animal);
        }

        public bool Equals(Animal animal)
        {
            if (Object.ReferenceEquals(animal, null))
            {
                return false;
            }

            if (this.GetType() != animal.GetType())
            {
                return false;
            }

            return Name == animal.Name;
        }

        public static bool operator ==(Animal lhs, Animal rhs)
        {
            if (Object.ReferenceEquals(lhs, null))
            {
                if (Object.ReferenceEquals(rhs, null))
                {
                    return true;
                }

                return false;
            }

            return lhs.Equals(rhs);
        }

        public static bool operator !=(Animal lhs, Animal rhs)
        {
            return !(lhs == rhs);
        }
    }
}
