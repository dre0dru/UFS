using System;
using Modules.UI;
using UnityEngine;

namespace Game.Scripts.UI.Animations
{
    public class MoneyCollectAnimationService : IMoneyCollectAnimationService
    {
        private const float DefaultAnimationDuration = 0.5f;

        private readonly ParticleAnimator _particleAnimator;
        private readonly Transform _targetParticleTransform;

        public event Action AnimationFinished;

        public MoneyCollectAnimationService(ParticleAnimator particleAnimator, Transform targetParticleTransform)
        {
            _particleAnimator = particleAnimator;
            _targetParticleTransform = targetParticleTransform;
        }

        public void StartAnimation(Vector3 startPosition)
        {
            _particleAnimator.Emit(startPosition, _targetParticleTransform.position, DefaultAnimationDuration, () =>
            {
                AnimationFinished?.Invoke();
            });
        }
    }
}
