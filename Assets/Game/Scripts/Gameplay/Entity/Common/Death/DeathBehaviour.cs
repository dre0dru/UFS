using Atomic.Elements;
using Atomic.Entities;
using Modules.Gameplay;

namespace Game.Gameplay
{
    public class DeathBehaviour : IEntityInit, IEntityEnable, IEntityDisable
    {
        private Health _health;
        private IEvent<TakeDamageArgs> _deathTakenEvent;

        public void Init(in IEntity entity)
        {
            _health = entity.GetHealth();
            _deathTakenEvent = entity.GetDeathTakenEvent();
        }

        public void Enable(in IEntity entity)
        {
            _health.OnHealthEmpty += OnHealthEmpty;
        }

        public void Disable(in IEntity entity)
        {
            _health.OnHealthEmpty -= OnHealthEmpty;
        }

        private void OnHealthEmpty()
        {
            _deathTakenEvent.Invoke(new TakeDamageArgs(null, 0));
        }
    }
}
