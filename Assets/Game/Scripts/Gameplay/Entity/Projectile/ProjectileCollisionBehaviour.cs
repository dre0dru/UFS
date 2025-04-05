using Atomic.Elements;
using Atomic.Entities;
using Modules.Gameplay;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class ProjectileCollisionBehaviour : IEntityInit, IEntityDispose
    {
        private IEntity _entity;
        private CollisionEventReceiver _collisionReceiver;

        public void Init(in IEntity entity)
        {
            _entity = entity;
            _collisionReceiver = entity.GetCollisionReceiver();

            _collisionReceiver.OnEntered += OnEntered;
        }

        public void Dispose(in IEntity entity)
        {
            _collisionReceiver.OnEntered -= OnEntered;
        }

        private void OnEntered(Collision collision)
        {
            var damage = _entity.GetDamage().Value;
            var args = new TakeDamageArgs(_entity, damage);

            if (collision.collider.TryGetComponent(out IEntity target) &&
                TakeDamageUseCase.TryTakeDamageUseCase(target, args) &&
                _entity.TryGetDestroyAction(out var destroyAction))
            {
                destroyAction.Invoke();
            }
        }
    }
}
