using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public static class MovementUseCase
    {
        public static bool CanMove(IEntity entity)
        {
            if (!entity.TryGetMovementCondition(out var condition))
            {
                return false;
            }

            return condition.Value;
        }

        public static bool IsMoving(IEntity entity)
        {
            return CanMove(entity) && entity.GetMovementDirection().Value != Vector2.zero;
        }

        public static void MoveDirection(IEntity entity, Vector2 direction, float dt)
        {
            var movement = direction * (entity.GetMovementSpeed().Value * dt);
            entity.GetTransform().position += new Vector3(movement.x, 0, movement.y);
        }
    }
}
