using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class HandsUseCase
    {
        public static void Attack(IEntity fists)
        {
            if (!fists.GetAttackCondition().Invoke())
            {
                return;
            }

            fists.GetAttackCooldown().Reset();
            fists.GetAttackEvent().Invoke();

            var firePoint = fists.GetFirePoint();
            var attackDistance = fists.GetAttackDistance().Value;
            var damage = fists.GetDamage().Value;
            var layer = fists.GetRaycastLayer().Value;

            foreach (var collider in Physics.OverlapSphere(firePoint.position, attackDistance, layer))
            {
                //TODO оказыватся есть готовый TryGetEntity!!!
                if (collider.TryGetEntity(out var target) && target.HasPlayerTag())
                {
                    TakeDamageUseCase.TryTakeDamageUseCase(target, new TakeDamageArgs(fists, damage));
                }
            }
        }
    }
}
