using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Game.Scripts.UI.Animations;
using Modules.Money;
using Modules.UI;
using Zenject;

namespace Game.Scripts.UI.Money
{
    //Mvp Passive View
    public class MoneyViewPresenter : IInitializable, IDisposable
    {
        private readonly MoneyView _moneyView;
        private readonly IMoneyStorage _moneyStorage;
        private readonly IMoneyCollectAnimationService _moneyCollectAnimationService;

        private TweenerCore<int, int, NoOptions> _animationTween;
        private int _currentFakeValue;

        public MoneyViewPresenter(MoneyView moneyView, IMoneyStorage moneyStorage,
            IMoneyCollectAnimationService moneyCollectAnimationService)
        {
            _moneyView = moneyView;
            _moneyStorage = moneyStorage;
            _moneyCollectAnimationService = moneyCollectAnimationService;
        }

        void IInitializable.Initialize()
        {
            _currentFakeValue = _moneyStorage.Money;
            SetMoneyCount(_currentFakeValue);

            Subscribe();
        }

        void IDisposable.Dispose()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            _moneyStorage.OnMoneyChanged += OnMoneyChanged;
            _moneyCollectAnimationService.AnimationFinished += OnMoneyCollectAnimationFinished;
        }

        private void Unsubscribe()
        {
            _moneyStorage.OnMoneyChanged -= OnMoneyChanged;
            _moneyCollectAnimationService.AnimationFinished -= OnMoneyCollectAnimationFinished;
        }

        private void OnMoneyChanged(int newValue, int prevValue)
        {
            if (newValue < prevValue)
            {
                _currentFakeValue = newValue;
                SetMoneyCount(newValue);
            }
        }

        private void OnMoneyCollectAnimationFinished()
        {
            SetMoneyCountAnimated(_moneyStorage.Money);
        }

        private void SetMoneyCount(int count)
        {
            _moneyView.SetCountText(count.ToString());
        }

        public void SetMoneyCountAnimated(int to)
        {
            if (_animationTween?.IsPlaying() ?? false)
            {
                _animationTween.ChangeEndValue(to);
            }
            else
            {
                _animationTween = DOTween.To(
                    () => _currentFakeValue,
                    x =>
                    {
                        _currentFakeValue = x;
                        SetMoneyCount(_currentFakeValue);
                    }, to, 1.0f
                ).OnComplete(() =>
                {
                    SetMoneyCount(_currentFakeValue);
                });
            }
        }
    }
}
