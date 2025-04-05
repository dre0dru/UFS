using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public static class RotationUseCase
    {
        public static void RotateTransformToDirection(IEntity entity, Vector2 direction, Transform target, float deltaTime)
        {
            if (direction == Vector2.zero)
            {
                return;
            }

            if (!entity.TryGetRotationCondition(out var rotateCondition) || !rotateCondition.Invoke())
            {
                return;
            }

            if (!entity.TryGetRotationSpeed(out var rotationSpeed))
            {
                return;
            }

            var targetRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.y), Vector3.up);
            target.rotation = Quaternion.Slerp(target.rotation, targetRotation, rotationSpeed.Value * deltaTime);
        }
    }
}
