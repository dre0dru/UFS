using Modules.Components;
using UnityEngine;

namespace Modules.Bullets
{
    internal static class BulletExtensions
    {
        internal static void DealDamage(this Bullet bullet, GameObject other)
        {
            if (!other.TryGetComponent(out TeamComponent otherTeam) ||
                !bullet.TryGetComponent(out TeamComponent bulletTeam))
            {
                return;
            }

            if (bulletTeam == otherTeam)
            {
                return;
            }

            if (other.TryGetComponent(out HealthComponent healthComponent))
            {
                healthComponent.TakeDamage(bullet.Damage);
            }
        }
    }
}
