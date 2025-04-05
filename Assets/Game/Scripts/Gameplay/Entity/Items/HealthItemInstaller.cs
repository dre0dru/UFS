using Atomic.Elements;
using Atomic.Entities;
using Game.Gameplay.Common.Health;
using UnityEngine;

namespace Game.Gameplay
{
    public class HealthItemInstaller : SceneEntityInstaller
    {
        [SerializeField]
        private int _addedHealth = 3;

        public override void Install(IEntity entity)
        {
            entity.AddPickupCondition(new AndExpression<IEntity>(
                HealthUseCase.IsAlive, HealthUseCase.IsNotFull));

            entity.AddPickupItemEvent(new BaseEvent());

            entity.AddPickupItemAction(new BaseAction<IEntity>(target =>
            {
                if (!entity.GetPickupCondition().Invoke(target))
                {
                    return;
                }

                if (!target.TryGetHealth(out var weapon))
                {
                    return;
                }

                weapon.Add(_addedHealth);

                entity.GetPickupItemEvent().Invoke();
            }));

            entity.AddBehaviour<ItemPickupOnTriggerEnterBehaviour>();
        }
    }
}
