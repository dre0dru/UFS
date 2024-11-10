using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace Homework
{
    public sealed class ConverterTests
    {
        public class ConverterParams
        {
            public int LoadingAreaCapacity = 5;
            public int LoadingAreaLoad = 3;
            public int UnloadingAreaCapacity = 5;
            public int UnloadingAreaLoad = 3;
            public int IntakePerCycle = 2;
            public int OutputPerCycle = 2;
            public float CycleTime = 1.0f;
        }

        private static (Converter converter, StorageArea loadingArea, StorageArea unloadingArea) CreateConverter(
            ConverterParams converterParams = default)
        {
            converterParams ??= new ConverterParams();

            var loadingArea = new StorageArea(converterParams.LoadingAreaCapacity, converterParams.LoadingAreaLoad);
            var unloadingArea =
                new StorageArea(converterParams.UnloadingAreaCapacity, converterParams.UnloadingAreaLoad);
            var converter = new Converter(loadingArea, unloadingArea,
                converterParams.IntakePerCycle, converterParams.OutputPerCycle, converterParams.CycleTime);

            return (converter, loadingArea, unloadingArea);
        }

        [Test]
        public void InstantiateConverter()
        {
            var (converter, _, _) = CreateConverter();

            Assert.AreEqual(0, converter.Load);
            Assert.AreEqual(false, converter.IsEnabled);
            Assert.AreEqual(false, converter.IsInProgress);
            Assert.AreEqual(0, converter.OutputOverflow);
        }

        [TestCaseSource(nameof(WhenNoStorageAreaThrowCases))]
        public void WhenNoStorageAreaThrow(StorageArea loadingArea, StorageArea unloadingArea)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new Converter(loadingArea, unloadingArea, 1, 1, 1);
            });
        }

        private static IEnumerable<TestCaseData> WhenNoStorageAreaThrowCases()
        {
            yield return new TestCaseData(
                new StorageArea(1), null
            ).SetName("No loading area");

            yield return new TestCaseData(
                null, new StorageArea(1)
            ).SetName("No unloading area");

            yield return new TestCaseData(
                null, null
            ).SetName("No areas");
        }

        [TestCase(0, 1, 1)]
        [TestCase(-1, 1, 1)]
        [TestCase(1, 0, 1)]
        [TestCase(1, -1, 1)]
        [TestCase(1, 1, 0)]
        [TestCase(1, 1, -1)]
        public void WhenInvalidParamsThrow(int intakePerCycle, int outputPerCycle, int cycleTimeSeconds)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Converter(new StorageArea(1), new StorageArea(1), intakePerCycle, outputPerCycle, cycleTimeSeconds);
            });
        }

        [TestCaseSource(nameof(WhenAreasHasSpaceConverterInProcessCases))]
        public void WhenAreasHasSpaceAndEnoughResourcesConverterInProcess(ConverterParams converterParams)
        {
            var (converter, loadingArea, unloadingArea) = CreateConverter(converterParams);

            converter.Enable();

            Assert.AreEqual(true, converter.IsEnabled);
            Assert.AreEqual(true, converter.IsInProgress);
            Assert.AreEqual(Mathf.Max(converterParams.LoadingAreaLoad - converterParams.IntakePerCycle, 0),
                loadingArea.Load);
            Assert.AreEqual(Mathf.Min(converterParams.IntakePerCycle, converterParams.LoadingAreaLoad), converter.Load);
        }

        private static IEnumerable<TestCaseData> WhenAreasHasSpaceConverterInProcessCases()
        {
            yield return new TestCaseData(
                new ConverterParams()
                {
                    LoadingAreaCapacity = 5,
                    LoadingAreaLoad = 3,
                    IntakePerCycle = 1,
                    UnloadingAreaCapacity = 5,
                    UnloadingAreaLoad = 0,
                    CycleTime = 1,
                    OutputPerCycle = 1,
                }
            ).SetName("Converter should load intake 1");

            yield return new TestCaseData(
                new ConverterParams()
                {
                    LoadingAreaCapacity = 5,
                    LoadingAreaLoad = 3,
                    IntakePerCycle = 2,
                    UnloadingAreaCapacity = 5,
                    UnloadingAreaLoad = 0,
                    CycleTime = 1,
                    OutputPerCycle = 1,
                }
            ).SetName("Converter should load intake 3");

            yield return new TestCaseData(
                new ConverterParams()
                {
                    LoadingAreaCapacity = 5,
                    LoadingAreaLoad = 5,
                    IntakePerCycle = 5,
                    UnloadingAreaCapacity = 5,
                    UnloadingAreaLoad = 0,
                    CycleTime = 1,
                    OutputPerCycle = 1,
                }
            ).SetName("Converter should load maximum area load");
        }

        [TestCaseSource(nameof(WhenAreasDontHaveSpaceConverterNotInProcessCases))]
        public void WhenAreasDontHaveSpaceOrNotEnoughResourcesConverterNotInProcess(ConverterParams converterParams)
        {
            var (converter, loadingArea, unloadingArea) = CreateConverter(converterParams);

            converter.Enable();

            Assert.AreEqual(true, converter.IsEnabled);
            Assert.AreEqual(false, converter.IsInProgress);
            Assert.AreEqual(converterParams.LoadingAreaLoad, loadingArea.Load);
            Assert.AreEqual(0, converter.Load);
        }

        private static IEnumerable<TestCaseData> WhenAreasDontHaveSpaceConverterNotInProcessCases()
        {
            yield return new TestCaseData(
                new ConverterParams()
                {
                    LoadingAreaCapacity = 5,
                    LoadingAreaLoad = 0,
                    IntakePerCycle = 1,
                    UnloadingAreaCapacity = 5,
                    UnloadingAreaLoad = 0,
                    CycleTime = 1,
                    OutputPerCycle = 1,
                }
            ).SetName("Not in process when loading area is empty");

            yield return new TestCaseData(
                new ConverterParams()
                {
                    LoadingAreaCapacity = 5,
                    LoadingAreaLoad = 3,
                    IntakePerCycle = 3,
                    UnloadingAreaCapacity = 5,
                    UnloadingAreaLoad = 5,
                    CycleTime = 1,
                    OutputPerCycle = 1,
                }
            ).SetName("Not in process when unloading area is full");

            yield return new TestCaseData(
                new ConverterParams()
                {
                    LoadingAreaCapacity = 5,
                    LoadingAreaLoad = 3,
                    IntakePerCycle = 3,
                    UnloadingAreaCapacity = 5,
                    UnloadingAreaLoad = 5,
                    CycleTime = 1,
                    OutputPerCycle = 1,
                }
            ).SetName("Not in process when not enough resources");
        }

        [TestCaseSource(nameof(CanOutputResourcesCorrectlyCases))]
        public void CanOutputResourcesCorrectlyPerCycleTime(ConverterParams converterParams, float deltaTime,
            int outputOverflow)
        {
            var (converter, loadingArea, unloadingArea) = CreateConverter(converterParams);

            converter.Enable();

            converter.Process(deltaTime);

            var totalCycles = Mathf.FloorToInt(deltaTime / converterParams.CycleTime);

            Assert.AreEqual(Mathf.Min(totalCycles * converterParams.OutputPerCycle, unloadingArea.Capacity),
                unloadingArea.Load);
            Assert.AreEqual(outputOverflow, converter.OutputOverflow);
        }

        private static IEnumerable<TestCaseData> CanOutputResourcesCorrectlyCases()
        {
            yield return new TestCaseData(
                new ConverterParams()
                {
                    LoadingAreaCapacity = 5,
                    LoadingAreaLoad = 5,
                    IntakePerCycle = 2,
                    UnloadingAreaCapacity = 5,
                    UnloadingAreaLoad = 0,
                    CycleTime = 1,
                    OutputPerCycle = 1,
                }, 1, 0
            ).SetName("Outputs correct amount to an empty unloading area in single cycle");

            yield return new TestCaseData(
                new ConverterParams()
                {
                    LoadingAreaCapacity = 5,
                    LoadingAreaLoad = 5,
                    IntakePerCycle = 2,
                    UnloadingAreaCapacity = 5,
                    UnloadingAreaLoad = 0,
                    CycleTime = 1,
                    OutputPerCycle = 1,
                }, 2, 0
            ).SetName("Outputs correct amount to an empty unloading area in two cycles");

            yield return new TestCaseData(
                new ConverterParams()
                {
                    LoadingAreaCapacity = 5,
                    LoadingAreaLoad = 5,
                    IntakePerCycle = 2,
                    UnloadingAreaCapacity = 5,
                    UnloadingAreaLoad = 0,
                    CycleTime = 1,
                    OutputPerCycle = 6,
                }, 1, 1
            ).SetName("Outputs with overflow to an empty unloading area in single cycle");
        }

        [TestCaseSource(nameof(WhenLoadingAreaHasNotEnoughResourcesShouldStopProcessingCases))]
        public void WhenLoadingAreaHasNotEnoughResourcesShouldStopProcessing(ConverterParams converterParams, float deltaTime)
        {
            var (converter, loadingArea, unloadingArea) = CreateConverter(converterParams);

            converter.Enable();

            converter.Process(deltaTime);

            Assert.AreEqual(false, converter.IsInProgress);
        }

        private static IEnumerable<TestCaseData> WhenLoadingAreaHasNotEnoughResourcesShouldStopProcessingCases()
        {
            yield return new TestCaseData(
                new ConverterParams()
                {
                    LoadingAreaCapacity = 5,
                    LoadingAreaLoad = 3,
                    IntakePerCycle = 2,
                    UnloadingAreaCapacity = 5,
                    UnloadingAreaLoad = 0,
                    CycleTime = 1,
                    OutputPerCycle = 1,
                }, 1
            ).SetName("Converter stops processing when not enough resources in loading area after one cycle");

            yield return new TestCaseData(
                new ConverterParams()
                {
                    LoadingAreaCapacity = 5,
                    LoadingAreaLoad = 5,
                    IntakePerCycle = 2,
                    UnloadingAreaCapacity = 5,
                    UnloadingAreaLoad = 0,
                    CycleTime = 1,
                    OutputPerCycle = 1,
                }, 2
            ).SetName("Converter stops processing when not enough resources in loading area after two cycles");
        }

        [TestCaseSource(nameof(WhenUnloadingAreaHasNotEnoughSpaceShouldStopProcessingCases))]
        public void WhenUnloadingAreaHasNotEnoughSpaceShouldStopProcessing(ConverterParams converterParams, float deltaTime, int outputOverflow)
        {
            var (converter, loadingArea, unloadingArea) = CreateConverter(converterParams);

            converter.Enable();

            converter.Process(deltaTime);

            Assert.AreEqual(false, converter.IsInProgress);
            Assert.AreEqual(outputOverflow, converter.OutputOverflow);
        }

        private static IEnumerable<TestCaseData> WhenUnloadingAreaHasNotEnoughSpaceShouldStopProcessingCases()
        {
            yield return new TestCaseData(
                new ConverterParams()
                {
                    LoadingAreaCapacity = 5,
                    LoadingAreaLoad = 5,
                    IntakePerCycle = 1,
                    UnloadingAreaCapacity = 1,
                    UnloadingAreaLoad = 0,
                    CycleTime = 1,
                    OutputPerCycle = 2,
                }, 1, 1
            ).SetName("Converter stops processing when not enough space in unloading area after one cycle");

            yield return new TestCaseData(
                new ConverterParams()
                {
                    LoadingAreaCapacity = 5,
                    LoadingAreaLoad = 5,
                    IntakePerCycle = 1,
                    UnloadingAreaCapacity = 3,
                    UnloadingAreaLoad = 0,
                    CycleTime = 1,
                    OutputPerCycle = 2,
                }, 2, 1
            ).SetName("Converter stops processing when not enough space in unloading area after two cycles");
        }

        [Test]
        public void WhenDisabledUnloadsAndStopsProcessing()
        {
            var converterParams = new ConverterParams()
            {
                LoadingAreaCapacity = 5,
                LoadingAreaLoad = 3,
                IntakePerCycle = 2
            };
            var (converter, loadingArea, unloadingArea) = CreateConverter(converterParams);

            converter.Enable();

            converter.Disable();

            Assert.AreEqual(false, converter.IsInProgress);
            Assert.AreEqual(false, converter.IsEnabled);
            Assert.AreEqual(converterParams.LoadingAreaLoad, loadingArea.Load);
            Assert.AreEqual(0, converter.Load);
        }

        [Test]
        public void WhenDisabledBurnsExcessiveReousrces()
        {
            var converterParams = new ConverterParams()
            {
                LoadingAreaCapacity = 5,
                IntakePerCycle = 2,
                LoadingAreaLoad = 3
            };
            var (converter, loadingArea, unloadingArea) = CreateConverter(converterParams);

            converter.Enable();

            loadingArea.Add(3);

            converter.Disable();

            Assert.AreEqual(true, loadingArea.IsFull);
            Assert.AreEqual(0, converter.Load);
            Assert.AreEqual(false, loadingArea.Load == (converterParams.LoadingAreaLoad - converterParams.IntakePerCycle + 3));
        }
    }
}
