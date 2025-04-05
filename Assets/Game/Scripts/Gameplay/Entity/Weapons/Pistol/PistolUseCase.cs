using Atomic.Contexts;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public static class PistolUseCase
    {
        public static void Fire(IContext context, IEntity pistol)
        {
            if (!pistol.GetAttackCondition().Invoke())
            {
                return;
            }

            pistol.GetAmmo().Spend();
            pistol.GetAttackCooldown().Reset();
            pistol.GetAttackEvent().Invoke();

            var firePoint = pistol.GetFirePoint();
            var spreadAngle = pistol.GetSpreadAngle().Value;

            var spread = Quaternion.Euler(
                Random.Range(-spreadAngle, spreadAngle),
                Random.Range(-spreadAngle, spreadAngle),
                0
            );

            var direction = spread * firePoint.forward;
            var rotation = Quaternion.LookRotation(direction, Vector3.up);

            var bulletPrefab = pistol.GetProjectilePrefab();
            SceneEntity.Instantiate(bulletPrefab, firePoint.position, rotation);
        }
    }
}
