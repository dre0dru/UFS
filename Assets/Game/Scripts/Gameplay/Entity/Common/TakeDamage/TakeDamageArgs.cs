using Atomic.Entities;
using Sirenix.OdinInspector;

namespace Game.Gameplay
{
    public class TakeDamageArgs
    {
        [ShowInInspector]
        public int Damage { get; private set; }
        [ShowInInspector]
        public IEntity Source { get; private set; }

        public TakeDamageArgs(IEntity source, int damage)
        {
            Source = source;
            Damage = damage;
        }
    }
}
