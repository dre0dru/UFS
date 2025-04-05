using Atomic.Elements;
using Atomic.Entities;

namespace Game.Gameplay
{
    public class IncreaseScoreOnDeathBehaviour : IEntityInit, IEntityEnable, IEntityDisable
    {
        private IEvent<TakeDamageArgs> _deathTakenEvent;
        private MainContext _context;

        public void Init(in IEntity entity)
        {
            _context = MainContext.Instance;
            _deathTakenEvent = entity.GetDeathTakenEvent();
        }

        public void Enable(in IEntity entity)
        {
            _deathTakenEvent.Subscribe(OnDeath);
        }

        public void Disable(in IEntity entity)
        {
            _deathTakenEvent.Unsubscribe(OnDeath);
        }

        private void OnDeath(TakeDamageArgs obj)
        {
            _context.GetScore().Value++;
        }
    }
}
