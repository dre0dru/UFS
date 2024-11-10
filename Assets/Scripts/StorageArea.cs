using System;

namespace Homework
{
    public class StorageArea
    {
        public int Capacity { get; }
        public int Load { get; private set; }
        public bool IsFull => Load == Capacity;
        public bool IsEmpty => Load == 0;

        public StorageArea(int capacity) : this(capacity, 0)
        {

        }

        public StorageArea(int capacity, int initialLoad)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException("Capacity can't be negative or zero");
            }

            if (initialLoad < 0)
            {
                throw new ArgumentException("Load can't be negative");
            }

            if (initialLoad > capacity)
            {
                throw new ArgumentException("Load can't be greater than capacity");
            }

            Load = initialLoad;
            Capacity = capacity;
        }

        public int Add(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount can't be below or equal to zero");
            }

            var availableCapacity = Capacity - Load;
            var amountToAdd = Math.Min(amount, availableCapacity);

            Load += amountToAdd;

            return amount - amountToAdd;
        }

        public int Remove(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount can't be below or equal to zero");
            }

            var removedCount = Math.Min(Load, amount);
            Load -= removedCount;

            return removedCount;
        }
    }
}
