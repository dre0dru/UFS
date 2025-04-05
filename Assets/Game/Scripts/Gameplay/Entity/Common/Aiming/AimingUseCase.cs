using Atomic.Entities;

namespace Game.Gameplay
{
    public static class AimingUseCase
    {
        public static bool IsAiming(in IEntity entity)
        {
            if (!entity.TryGetAimingDirection(out var aimDirection))
            {
                return false;
            }

            return aimDirection.Value.sqrMagnitude > 0.1f;
        }
    }
}
