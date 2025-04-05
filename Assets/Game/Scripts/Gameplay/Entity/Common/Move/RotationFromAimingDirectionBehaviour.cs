using Atomic.Entities;

namespace Game.Gameplay
{
    public class RotationFromAimingDirectionBehaviour: IEntityFixedUpdate
    {
        public void OnFixedUpdate(in IEntity entity, in float deltaTime)
        {
            if (!AimingUseCase.IsAiming(entity))
            {
                return;
            }

            var direction = entity.GetAimingDirection().Value;
            var animTransform = entity.GetAnimationTransform();
            RotationUseCase.RotateTransformToDirection(entity, direction, animTransform, deltaTime);
        }
    }
}
