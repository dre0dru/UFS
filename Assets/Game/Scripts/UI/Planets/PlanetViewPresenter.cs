using System;
using System.Text;
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
        private readonly StringBuilder _sb;
        private readonly PlanetView _planetView;
        private readonly IPlanet _planet;
        private readonly IMoneyCollectAnimator _moneyCollectAnimator;
        private readonly PlanetPopupOpener _planetPopupOpener;

        public PlanetViewPresenter(PlanetView planetView, IPlanet planet,
            IMoneyCollectAnimator moneyCollectAnimator, PlanetPopupOpener planetPopupOpener)
        {
            _planet = planet;
            _moneyCollectAnimator = moneyCollectAnimator;
            _planetPopupOpener = planetPopupOpener;
            _planetView = planetView;
            _sb = new StringBuilder();
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
            _planet.OnGathered += OnGathered;
        }

        private void Unsubscribe()
        {
            _planetView.Clicked -= OnPlanetClicked;
            _planetView.Held -= OnPlanetHeld;

            _planet.OnUnlocked -= OnUnlocked;
            _planet.OnIncomeTimeChanged -= OnIncomeTimeChanged;
            _planet.OnIncomeReady -= OnIncomeReady;
            _planet.OnGathered -= OnGathered;
        }

        private void OnGathered(int amount)
        {
            _moneyCollectAnimator.PlayCollectAnimation(_planetView.MoneyAnimationStartPoint);
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

        private string ToTimerHours(float inputSeconds)
        {
            var timespan = TimeSpan.FromSeconds(inputSeconds);

            var hours = timespan.Hours;
            var minutes = timespan.Minutes;
            var seconds = timespan.Seconds;

            _sb.Clear();

            if (hours > 0)
            {
                _sb.Append(hours).Append("h:");
            }

            if (minutes > 0 || hours > 0)
            {
                _sb.Append(minutes).Append("m:");
            }

            _sb.Append(seconds).Append("s");

            return _sb.ToString();
        }
    }
}
