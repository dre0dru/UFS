using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class TakeDamageColorChangeComponent : MonoBehaviour
    {
        [SerializeField]
        private HealthComponent _healthComponent;

        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        [SerializeField]
        private float _animationDuration = 2.0f;

        [SerializeField]
        private int _animationLoopsCount = 3;

        [SerializeField]
        private Color _color = Color.white;

        private Color _initialColor;
        private TweenerCore<Color, Color, ColorOptions> _tween;

        private void Awake()
        {
            _initialColor = _spriteRenderer.color;
            _healthComponent.TookDamage += AnimateColorChange;
        }

        private void OnDestroy()
        {
            _healthComponent.TookDamage -= AnimateColorChange;
        }

        [Button]
        private void AnimateColorChange()
        {
            _tween?.Kill(true);

            var animationDuration = _animationDuration / _animationLoopsCount;

            _tween = _spriteRenderer
                .DOColor(_color, animationDuration)
                .SetLoops(_animationLoopsCount, LoopType.Yoyo)
                .OnComplete(() => _spriteRenderer.color = _initialColor);
        }
    }
}
