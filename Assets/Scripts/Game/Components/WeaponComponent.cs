using Game.Bullets;
using UnityEngine;

namespace Game.Components
{
    public sealed class WeaponComponent : MonoBehaviour
    {
        [SerializeField]
        private BulletSystem _bulletSystem;

        [SerializeField]
        private BulletConfig _bulletConfig;

        [SerializeField]
        private Transform _firePoint;

        public void Construct(BulletSystem bulletSystem)
        {
            _bulletSystem = bulletSystem;
        }

        public void Shoot(GameObject target)
        {
            Shoot(target.transform.position - _firePoint.position);
        }

        public void Shoot(Vector2 direction)
        {
            _bulletSystem.ShootBullet(new BulletArgs
            {
                BulletConfig = _bulletConfig,
                Position = _firePoint.position,
                Direction = direction
            });
        }
    }
}
