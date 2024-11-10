using System;

namespace Homework
{
    //Имхо в ТЗ несостыковка, либо я не так что-то понял.
    //Сказано, что новый цикл не начинается, если нет места для выгрузки результата конверсии.
    //Но мелким текстом приписано, что конвертер может выдать "сдачу", если попытается
    //выгрузить больше, чем есть места.
    //Я это понял так: если зона *выгрузки* неполная (Capacity != Load) и там не хватает места для OutputPerCycle,
    //то мы все равно начинаем цикл и выгружаем результат работы конвертера,
    //просто получим "сдачу" и след цикл уже не начнем, потому что
    //зона выгрузки полная в прямом смысле (Capacity == Load).
    public sealed class Converter
    {
        private readonly StorageArea _loadingArea;
        private readonly StorageArea _unloadingArea;
        private readonly int _intakePerCycle;
        private readonly int _outputPerCycle;
        private readonly float _cycleTimeSeconds;

        public bool IsEnabled { get; private set; }
        public int Load { get; private set; }
        public bool IsInProgress => Load >= _intakePerCycle;
        //сдача согласно ТЗ, но непонятно, что с ней делать, не описано
        public int OutputOverflow { get; private set; }

        private float _currentCycleTime;


        public Converter(StorageArea loadingArea, StorageArea unloadingArea, int intakePerCycle, int outputPerCycle, float cycleTimeSeconds)
        {
            _loadingArea = loadingArea ?? throw new ArgumentNullException(nameof(loadingArea), "Loading area can't be null");
            _unloadingArea = unloadingArea ?? throw new ArgumentNullException(nameof(unloadingArea), "Unloading area can't be null");

            if (intakePerCycle <= 0)
                throw new ArgumentException("Intake can't be negative or below zero", nameof(intakePerCycle));

            if (outputPerCycle <= 0)
                throw new ArgumentException("Output can't be negative or below zero", nameof(outputPerCycle));

            if (cycleTimeSeconds <= 0)
                throw new ArgumentException("Cycle time can't be negative or below zero", nameof(cycleTimeSeconds));

            _cycleTimeSeconds = cycleTimeSeconds;
            _outputPerCycle = outputPerCycle;
            _intakePerCycle = intakePerCycle;
            _unloadingArea = unloadingArea;
            _loadingArea = loadingArea;
        }

        public void Enable()
        {
            if (IsEnabled)
            {
                return;
            }

            IsEnabled = true;
            _currentCycleTime = 0;
            TryBeginConversion();
        }

        public void Process(float dt)
        {
            if (IsInProgress || TryBeginConversion())
            {
                _currentCycleTime += dt;

                while (_currentCycleTime >= _cycleTimeSeconds)
                {
                    _currentCycleTime -= _cycleTimeSeconds;

                    OutputResources();

                    if (!TryBeginConversion())
                    {
                        break;
                    }
                }
            }
        }

        public void Disable()
        {
            if (!IsEnabled)
            {
                return;
            }

            IsEnabled = false;

            if (Load > 0)
            {
                _loadingArea.Add(Load);
                Load = 0;
            }
        }

        private bool TryBeginConversion()
        {
            if (_loadingArea.Load < _intakePerCycle || _unloadingArea.IsFull)
            {
                return false;
            }

            Load = _loadingArea.Remove(_intakePerCycle);
            return true;
        }

        private void OutputResources()
        {
            Load -= _intakePerCycle;
            OutputOverflow += _unloadingArea.Add(_outputPerCycle);
        }
    }
}
