using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI.Money
{
    public class MoneyView : MonoBehaviour
    {
        [SerializeField]
        private Image _icon;

        [SerializeField]
        private TextMeshProUGUI _countText;

        [SerializeField]
        private Transform _targetParticleTransform;

        private TweenerCore<int, int, NoOptions> _animationTween;
        private int _currentFakeValue;
        private Func<int, string> _countFormatter;

        public Transform TargetParticleTransform => _targetParticleTransform;

        public void SetCountFormatter(Func<int, string> countFormatter)
        {
            _countFormatter = countFormatter;
        }

        public void SetCountText(int count)
        {
            _currentFakeValue = count;
            SetCountTextFormatted(count);
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
                        SetCountText(_currentFakeValue);
                    }, to, 1.0f
                ).OnComplete(() =>
                {
                    SetCountText(_currentFakeValue);
                });
            }
        }

        private void SetCountTextFormatted(int count)
        {
            _countText.text = _countFormatter?.Invoke(count);
        }
    }
}
