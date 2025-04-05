using Atomic.Entities;

namespace Game.Gameplay
{
    public class RotationFromMovementDirectionBehaviour: IEntityFixedUpdate
    {
        public void OnFixedUpdate(in IEntity entity, in float deltaTime)
        {
            if (AimingUseCase.IsAiming(entity))
            {
                return;
            }

            var direction = entity.GetMovementDirection().Value;
            var animTransform = entity.GetAnimationTransform();
            RotationUseCase.RotateTransformToDirection(entity, direction, animTransform, deltaTime);
        }
    }
}
