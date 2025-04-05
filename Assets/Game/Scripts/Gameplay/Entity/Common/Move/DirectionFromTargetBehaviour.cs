using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class DirectionFromTargetBehaviour : IEntityFixedUpdate
    {
        public void OnFixedUpdate(in IEntity entity, in float deltaTime)
        {
            if (!entity.TryGetMovementDirection(out var movementDirection))
            {
                return;
            }

            if (!EnemyUseCase.HasAttackTarget(entity, out var target))
            {
                movementDirection.Value = Vector2.zero;
                return;
            }

            var direction = target.GetTransform().position - entity.GetTransform().position;

            movementDirection.Value = new Vector2(direction.x, direction.z).normalized;
        }
    }
}
