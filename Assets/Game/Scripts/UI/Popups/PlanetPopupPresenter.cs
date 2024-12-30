using System;
using Modules.Money;
using Modules.Planets;
using UnityEngine;
using Zenject;

namespace Game.Scripts.UI.Popups
{
    public class PlanetPopupPresenter : IPlanetPopupPresenter
    {
        //Знаю, что можно оптимизировать через паттерн легковес, но в PM презентеры использую
        //как одноразовые сущности для конкретной вьюшки
        public class Factory : PlaceholderFactory<IPlanet, PlanetPopupPresenter>
        {
        }

        private readonly IMoneyStorage _moneyStorage;
        private readonly IPlanet _planet;

        public string HeaderText => _planet.Name;
        public Sprite Icon => _planet.GetIcon(true);
        public string PopulationText => $"Population: {_planet.Population}";
        public string LevelText => $"Level: {_planet.Level}/{_planet.MaxLevel}";
        public string IncomeText => $"Income: {_planet.MinuteIncome / 60}/sec";
        public string UpgradePriceText => $"{_planet.Price}";
        public bool CanUpgrade => _planet.CanUpgrade;
        public bool IsMaxLevel => _planet.IsMaxLevel;
        public string UpgradeButtonText => IsMaxLevel ? "Max Level Reached" : "Upgrade";

        public event Action InfoChanged;

        public PlanetPopupPresenter(IMoneyStorage moneyStorage, IPlanet planet)
        {
            _moneyStorage = moneyStorage;
            _planet = planet;

            Subscribe();
        }

        void IDisposable.Dispose()
        {
            Unsubscribe();
        }

        public void Upgrade()
        {
            if (!_planet.CanUpgrade)
            {
                return;
            }

            _planet.Upgrade();
        }

        private void Subscribe()
        {
            _moneyStorage.OnMoneyChanged += OnMoneyChanged;
            _planet.OnUpgraded += OnPlanetUpgraded;
            _planet.OnPopulationChanged += OnPlanetPopulationChanged;
            _planet.OnIncomeChanged += OnPlanetIcomeChanged;
        }

        private void Unsubscribe()
        {
            _moneyStorage.OnMoneyChanged -= OnMoneyChanged;
            _planet.OnUpgraded -= OnPlanetUpgraded;
            _planet.OnPopulationChanged -= OnPlanetPopulationChanged;
            _planet.OnIncomeChanged -= OnPlanetIcomeChanged;
        }

        private void OnPlanetUpgraded(int obj)
        {
            InvokeInfoChanged();
        }

        private void OnPlanetPopulationChanged(int obj)
        {
            InvokeInfoChanged();
        }

        private void OnPlanetIcomeChanged(int obj)
        {
            InvokeInfoChanged();
        }

        private void OnMoneyChanged(int newvalue, int prevvalue)
        {
            InvokeInfoChanged();
        }

        private void InvokeInfoChanged()
        {
            InfoChanged?.Invoke();
        }
    }
}
