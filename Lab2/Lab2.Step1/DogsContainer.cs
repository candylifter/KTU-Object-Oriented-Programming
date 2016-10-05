using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Step1
{
    class DogsContainer
    {
        private Dog[] Dogs { get; set; }
        public int Count { get; private set; }

        public DogsContainer(int size)
        {
            Dogs = new Dog[size];
        }

        public void AddDog(Dog dog)
        {
            Dogs[Count] = dog;
            Count++;
        }

        public Dog GetDog(int index)
        {
            return Dogs[index];
        }

        public void RemoveDog(Dog dog)
        {
            int i = 0;
            while (i < Count)
            {
                if (Dogs[i].Equals(dog))
                {
                    Count--;
                    for (int j = i; j < Count; j++)
                    {
                        Dogs[j] = Dogs[j + 1];
                    }
                    break;
                }
                i++;
            }
        }

        public bool Contains(Dog dog)
        {
            return Dogs.Contains(dog);
        }

        public void SortDogs()
        {
            for (int i = 0; i < Count - 1; i++)
            {
                Dog minValueDog = Dogs[i];
                int minValueIndex = i;
                for (int j = i + 1; j < Count; j++)
                {
                    if (Dogs[j] <= minValueDog)
                    {
                        minValueDog = Dogs[j];
                        minValueIndex = j;
                    }
                }
                Dogs[minValueIndex] = Dogs[i];
                Dogs[i] = minValueDog;
            }
        }
    }
}
