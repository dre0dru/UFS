using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

namespace Homework
{
    public class StorageAreaTests
    {
        [TestCase(1, 1, true, false)]
        [TestCase(2, 1, false, false)]
        [TestCase(1, 0, false, true)]
        public void InstantiateStorageArea(int capacity, int initialLoad, bool isFull, bool isEmpty)
        {
            var storageArea = new StorageArea(capacity, initialLoad);

            Assert.AreEqual(capacity, storageArea.Capacity);
            Assert.AreEqual(initialLoad, storageArea.Load);
            Assert.AreEqual(isFull, storageArea.IsFull);
            Assert.AreEqual(isEmpty, storageArea.IsEmpty);
        }

        [TestCaseSource(nameof(WhenIncorrectInitialParamsThrowCases))]
        public void WhenIncorrectInitialParamsThrow(int capacity, int initialLoad)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new StorageArea(capacity, initialLoad);
            });
        }

        private static IEnumerable<TestCaseData> WhenIncorrectInitialParamsThrowCases()
        {
            yield return new TestCaseData(
                -1, 0
            ).SetName("Negative capacity");

            yield return new TestCaseData(
                0, -1
            ).SetName("Negative load");

            yield return new TestCaseData(
                1, 2
            ).SetName("Load > Capacity");

            yield return new TestCaseData(
                0, 0
            ).SetName("Zero capacity");
        }

        [TestCase(1)]
        [TestCase(5)]
        public void CanAddResources(int amount)
        {
            var capacity = 5;
            var initialLoad = 0;
            var storageArea = new StorageArea(capacity, initialLoad);

            storageArea.Add(amount);

            Assert.AreEqual(initialLoad + amount, storageArea.Load);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void WhenAddIncorrectParamsThrow(int amount)
        {
            var capacity = 5;
            var initialLoad = 0;
            var storageArea = new StorageArea(capacity, initialLoad);

            Assert.Throws<ArgumentException>(() =>
            {
                storageArea.Add(amount);
            });
        }

        [TestCase(1, 1)]
        [TestCase(5, 5)]
        [TestCase(6, 5)]
        public void CanRemoveResources(int amount, int expectedRemoved)
        {
            var capacity = 5;
            var initialLoad = 5;
            var storageArea = new StorageArea(capacity, initialLoad);

            var removedAmount = storageArea.Remove(amount);

            Assert.AreEqual(Mathf.Max(initialLoad - amount, 0), storageArea.Load);
            Assert.AreEqual(expectedRemoved, removedAmount);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void WhenRemoveIncorrectParamsThrow(int amount)
        {
            var capacity = 5;
            var initialLoad = 0;
            var storageArea = new StorageArea(capacity, initialLoad);

            Assert.Throws<ArgumentException>(() =>
            {
                storageArea.Remove(amount);
            });
        }

        [TestCase(1, 1, 0)]
        [TestCase(5, 5, 0)]
        [TestCase(6, 5, 1)]
        public void ShouldBurnExcessiveWhenAdding(int amount, int expectedLoad, int burnedAmount)
        {
            var capacity = 5;
            var initialLoad = 0;
            var storageArea = new StorageArea(capacity, initialLoad);

            var burned = storageArea.Add(amount);

            Assert.AreEqual(expectedLoad, storageArea.Load);
            Assert.AreEqual(burned, Mathf.Max(0, amount - capacity));
        }
    }
}
