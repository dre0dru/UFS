using System;
using Game.Scripts.UI.Animations;
using Game.Scripts.UI.Popups;
using Modules.Planets;
using UnityEngine;
using Zenject;

namespace Game.Scripts.UI.Planets
{
    //Mvp Passive View
    public class PlanetViewPresenter : IInitializable, IDisposable
    {
        private readonly PlanetView _planetView;
        private readonly IPlanet _planet;
        private readonly IMoneyCollectAnimationService _moneyCollectAnimationService;
        private readonly PlanetPopupOpener _planetPopupOpener;

        public PlanetViewPresenter(PlanetView planetView, IPlanet planet,
            IMoneyCollectAnimationService moneyCollectAnimationService, PlanetPopupOpener planetPopupOpener)
        {
            _planet = planet;
            _moneyCollectAnimationService = moneyCollectAnimationService;
            _planetPopupOpener = planetPopupOpener;
            _planetView = planetView;
        }

        void IInitializable.Initialize()
        {
            _planetView.SetUnlockedState(_planet.IsUnlocked);
            _planetView.SetIncomeReadyState(_planet.IsIncomeReady);
            _planetView.SetUnlockPriceText(_planet.Price.ToString());
            SetIcon();

            Subscribe();
        }

        void IDisposable.Dispose()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            _planetView.Clicked += OnPlanetClicked;
            _planetView.Held += OnPlanetHeld;

            _planet.OnUnlocked += OnUnlocked;
            _planet.OnIncomeTimeChanged += OnIncomeTimeChanged;
            _planet.OnIncomeReady += OnIncomeReady;
        }

        private void Unsubscribe()
        {
            _planetView.Clicked -= OnPlanetClicked;
            _planetView.Held -= OnPlanetHeld;

            _planet.OnUnlocked -= OnUnlocked;
            _planet.OnIncomeTimeChanged -= OnIncomeTimeChanged;
            _planet.OnIncomeReady -= OnIncomeReady;
        }

        private void OnIncomeTimeChanged(float remainingTime)
        {
            _planetView.SetProgress(_planet.IncomeProgress);
            _planetView.SetProgressBarText(ToTimerHours(remainingTime));
        }

        private void OnIncomeReady(bool isReady)
        {
            _planetView.SetIncomeReadyState(isReady);
        }

        private void OnUnlocked()
        {
            _planetView.SetUnlockedState(_planet.IsUnlocked);
            SetIcon();
        }

        private void SetIcon()
        {
            _planetView.SetIcon(_planet.GetIcon(_planet.IsUnlocked));
        }

        private void OnPlanetClicked()
        {
            if (_planet.CanUnlock)
            {
                _planet.Unlock();
                return;
            }

            if (_planet.IsIncomeReady)
            {
                _planet.GatherIncome();
                _moneyCollectAnimationService.StartAnimation(_planetView.MoneyAnimationStartPoint);
            }
        }

        private void OnPlanetHeld()
        {
            if (!_planet.IsUnlocked)
            {
                return;
            }

            _planetPopupOpener.OpenFor(_planet);
        }

        private static string ToTimerHours(float inputSeconds)
        {
            var time = inputSeconds;
            var hours = ((int)time / 60 / 60) % 24;
            var minutes = (((int)time / 60) % 60);
            var seconds = (int)time % 60;

            string result = string.Empty;

            if (hours > 0)
            {
                result += $"{hours}h:";
            }

            if (minutes > 0 || hours > 0)
            {
                result += $"{minutes}m:";
            }

            result += $"{seconds}s";

            return result;
        }
    }
}
