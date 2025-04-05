using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class DeathAnimationBehaviour : IEntityInit, IEntityDispose
    {
        private static readonly int Death = Animator.StringToHash("Death");

        private Animator _animator;
        private IEvent<TakeDamageArgs> _deathEvent;

        public void Init(in IEntity entity)
        {
            _animator = entity.GetAnimator();
            _deathEvent = entity.GetDeathTakenEvent();
            _deathEvent.Subscribe(OnDeath);
        }

        public void Dispose(in IEntity entity)
        {
            _deathEvent.Unsubscribe(OnDeath);
        }

        private void OnDeath(TakeDamageArgs args)
        {
            _animator.SetTrigger(Death);
        }
    }
}
