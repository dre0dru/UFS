using Atomic.Elements;
using Atomic.Entities;
using Modules.Gameplay;

namespace Game.Gameplay
{
    public sealed class ProjectileDestroyAfterLifetimeBehaviour : IEntityInit, IEntityFixedUpdate
    {
        private IAction _destroyAction;
        private Cooldown _lifetime;

        public void Init(in IEntity entity)
        {
            _destroyAction = entity.GetDestroyAction();
            _lifetime = entity.GetLifetime();
        }

        public void OnFixedUpdate(in IEntity entity, in float deltaTime)
        {
            _lifetime.Tick(deltaTime);

            if (_lifetime.IsExpired())
            {
                _destroyAction.Invoke();
            }
        }
    }
}
