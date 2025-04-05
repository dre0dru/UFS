using Atomic.Elements;
using Atomic.Entities;
using Modules.Gameplay;
using UnityEngine;

namespace Game.Gameplay
{
    //TODO потом для зобми может переиспользовать?
    public class HealthInstaller : SceneEntityInstaller
    {
        [SerializeField]
        private Health _health;

        public override void Install(IEntity entity)
        {
            entity.AddDamageableTag();
            entity.SetHealth(_health);
            entity.SetDamageTakenEvent(new BaseEvent<TakeDamageArgs>());
            entity.SetDeathTakenEvent(new BaseEvent<TakeDamageArgs>());
            entity.AddBehaviour<DeathBehaviour>();
        }
    }
}
