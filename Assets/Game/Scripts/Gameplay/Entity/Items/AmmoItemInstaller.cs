using Atomic.Elements;
using Atomic.Entities;
using Game.Gameplay.Common.Health;
using UnityEngine;

namespace Game.Gameplay
{
    public class AmmoItemInstaller : SceneEntityInstaller
    {
        [SerializeField]
        private int _addedAmmo = 10;

        public override void Install(IEntity entity)
        {
            entity.AddPickupCondition(new AndExpression<IEntity>(
                HealthUseCase.IsAlive,
                (target) => target.TryGetWeapon(out var weapon) && weapon.HasAmmo()));

            entity.AddPickupItemEvent(new BaseEvent());

            entity.AddPickupItemAction(new BaseAction<IEntity>(target =>
            {
                if (!entity.GetPickupCondition().Invoke(target))
                {
                    return;
                }

                if (!target.TryGetWeapon(out var weapon) || !weapon.TryGetAmmo(out var ammo))
                {
                    return;
                }

                ammo.Add(_addedAmmo);

                entity.GetPickupItemEvent().Invoke();
            }));

            entity.AddBehaviour<ItemPickupOnTriggerEnterBehaviour>();
        }
    }
}
