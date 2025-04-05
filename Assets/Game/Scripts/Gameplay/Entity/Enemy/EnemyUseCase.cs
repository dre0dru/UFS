using Atomic.Entities;
using Game.Gameplay.Common.Health;
using UnityEngine;

namespace Game.Gameplay
{
    public class EnemyUseCase
    {
        public static bool IsAttackTargetReached(IEntity entity)
        {
            if (!HasAttackTarget(entity, out var target))
            {
                return false;
            }

            var transform = entity.GetTransform();
            var targetTransfform = target.GetTransform();

            return Vector3.Distance(targetTransfform.position, transform.position) < entity.GetAttackDistance().Value;
        }

        public static bool IsAttackTargetAlive(IEntity entity)
        {
            if (!HasAttackTarget(entity, out var target))
            {
                return false;
            }

            return HealthUseCase.IsAlive(target);
        }

        public static bool HasAttackTarget(IEntity entity, out IEntity target)
        {
            target = default;

            if (entity.TryGetAttackTarget(out var attackTarget))
            {
                target = attackTarget.Value;
                return target != null;
            }

            return false;
        }

        public static void SetAttackTarget(IEntity entity, IEntity target)
        {
            if (!entity.TryGetAttackTarget(out var attackTarget))
            {
                return;
            }

            attackTarget.Value = target;
        }
    }
}
