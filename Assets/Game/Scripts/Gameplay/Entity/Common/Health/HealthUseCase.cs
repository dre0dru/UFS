using Atomic.Entities;

namespace Game.Gameplay.Common.Health
{
    public static class HealthUseCase
    {
        public static bool IsAlive(IEntity entity)
        {
            if (!entity.TryGetHealth(out var health))
            {
                return false;
            }

            return health.Exists();
        }

        public static bool IsNotFull(IEntity entity)
        {
            if (!entity.TryGetHealth(out var health))
            {
                return false;
            }

            return !health.IsFull();
        }
    }
}
