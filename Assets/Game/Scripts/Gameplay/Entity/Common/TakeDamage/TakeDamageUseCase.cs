using Atomic.Entities;
using Modules.Gameplay;
using UnityEngine;

namespace Game.Gameplay
{
    public static class TakeDamageUseCase
    {
        public static bool TryTakeDamageUseCase(IEntity entity, TakeDamageArgs args)
        {
            if (!entity.HasDamageableTag())
            {
                return false;
            }

            if (!entity.TryGetHealth(out var health))
            {
                Debug.LogError($"Missing {typeof(Health)} on {entity}");
                return false;
            }

            if (!health.Reduce(args.Damage))
            {
                return false;
            }

            entity.GetDamageTakenEvent().Invoke(args);
            return true;
        }
    }
}
