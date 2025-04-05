using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class TakeDamageAnimationBehaviour : IEntityInit, IEntityDispose
    {
        private static readonly int TakeDamage = Animator.StringToHash("TakeDamage");

        private IEvent<TakeDamageArgs> _damageEvent;
        private Animator _animator;

        public void Init(in IEntity entity)
        {
            _animator = entity.GetAnimator();
            _damageEvent = entity.GetDamageTakenEvent();

            _damageEvent.Subscribe(OnDamageTaken);
        }

        public void Dispose(in IEntity entity)
        {
            _damageEvent.Unsubscribe(OnDamageTaken);
        }

        private void OnDamageTaken(TakeDamageArgs args)
        {
            _animator.SetTrigger(TakeDamage);
        }
    }
}
