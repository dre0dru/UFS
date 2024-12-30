using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Game.Scripts.UI.Animations;
using Modules.Money;
using Modules.UI;
using UnityEngine;
using Zenject;

namespace Game.Scripts.UI.Money
{
    //Mvp Passive View
    public class MoneyViewPresenter : IInitializable, IDisposable, IMoneyCollectAnimator
    {
        private const float DefaultAnimationDuration = 0.5f;

        private readonly MoneyView _moneyView;
        private readonly IMoneyStorage _moneyStorage;
        private readonly ParticleAnimator _particleAnimator;
        public MoneyViewPresenter(MoneyView moneyView, IMoneyStorage moneyStorage,
            ParticleAnimator particleAnimator)
        {
            _moneyView = moneyView;
            _moneyStorage = moneyStorage;
            _particleAnimator = particleAnimator;
        }

        void IInitializable.Initialize()
        {
            _moneyView.SetCountFormatter(FormatMoneyCount);
            SetMoneyCount(_moneyStorage.Money);

            Subscribe();
        }

        void IDisposable.Dispose()
        {
            Unsubscribe();
        }

        public void PlayCollectAnimation(Vector3 startPosition)
        {
            _particleAnimator.Emit(startPosition, _moneyView.TargetParticleTransform.position,
                DefaultAnimationDuration, OnMoneyCollectAnimationFinished);
        }

        private void Subscribe()
        {
            _moneyStorage.OnMoneyChanged += OnMoneyChanged;
        }

        private void Unsubscribe()
        {
            _moneyStorage.OnMoneyChanged -= OnMoneyChanged;
        }

        private void OnMoneyChanged(int newValue, int prevValue)
        {
            if (newValue < prevValue)
            {
                SetMoneyCount(newValue);
            }
        }

        private void OnMoneyCollectAnimationFinished()
        {
            _moneyView.SetMoneyCountAnimated(_moneyStorage.Money);
        }

        private void SetMoneyCount(int count)
        {
            _moneyView.SetCountText(count);
        }

        private string FormatMoneyCount(int count)
        {
            return count.ToString();
        }
    }
}
