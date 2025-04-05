using Atomic.Contexts;
using UnityEngine;

namespace Game.Gameplay
{
    public static class ControlsUseCase
    {
        public static void InvokeAttack(IContext context)
        {
            if (!context.TryGetPlayer(out var player) ||
                !player.TryGetAttackAction(out var attackAction))
            {
                return;
            }

            attackAction.Invoke();
        }

        public static void SetAimingDirection(IContext context, Vector2 direction)
        {
            if (!context.TryGetPlayer(out var player) ||
                !player.TryGetAimingDirection(out var aimingDirection))
            {
                return;
            }

            aimingDirection.Value = direction;
        }

        public static void SetMovementDirection(IContext context, Vector2 direction)
        {
            if (!context.TryGetPlayer(out var player) ||
                !player.TryGetMovementDirection(out var movementDirection))
            {
                return;
            }

            movementDirection.Value = direction;
        }
    }
}
