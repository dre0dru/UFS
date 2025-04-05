using Atomic.Entities;

namespace Game.Gameplay
{
    public static class ItemsUseCase
    {
        public static void TryPickupItem(IEntity target, IEntity item)
        {
            if (!item.TryGetPickupCondition(out var condition) ||
                !condition.Invoke(target))
            {
                return;
            }

            item.DisableItemPickup();

            if (!item.TryGetPickupItemAction(out var action))
            {
                return;
            }

            action?.Invoke(target);
        }

        private static void DisableItemPickup(this IEntity target)
        {
            target.GetTriggerReceiver().enabled = false;
            target.GetAnimationTransform().gameObject.SetActive(false);
        }
    }
}
