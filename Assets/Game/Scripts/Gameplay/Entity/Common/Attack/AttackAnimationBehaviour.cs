using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class AttackAnimationBehaviour : IEntityInit, IEntityDispose
    {
        private static readonly int Attack = Animator.StringToHash("Attack");

        private Animator _animator;
        private IReactive _attackEvent;

        public void Init(in IEntity entity)
        {
            _animator = entity.GetAnimator();
            _attackEvent = entity.GetAttackEvent();
            _attackEvent.Subscribe(this.OnAttack);
        }

        public void Dispose(in IEntity entity)
        {
            _attackEvent.Unsubscribe(this.OnAttack);
        }

        private void OnAttack()
        {
            _animator.SetTrigger(Attack);
        }
    }
}
