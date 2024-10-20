using Modules.Components;
using UnityEngine;

namespace Modules.Bullets
{
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField]
        private BulletPool _bulletPool;

        [SerializeField]
        private Transform _worldTransform;

        public Bullet SpawnBullet(BulletArgs args)
        {
            var bullet = GetBullet()
                .SetPosition(args.Position)
                .SetColor(args.BulletConfig.Color)
                .SetPhysicsLayer((int)args.BulletConfig.PhysicsLayer)
                .SetDamage(args.BulletConfig.Damage)
                .SetVelocity(args.Direction * args.BulletConfig.Speed);

            bullet.GetComponent<TeamComponent>().Team = args.BulletConfig.Team;

            return bullet;
        }

        public void DespawnBullet(Bullet bullet)
        {
            ReleaseBullet(bullet);
        }

        private Bullet GetBullet()
        {
            var bullet = _bulletPool.Get();
            bullet.transform.SetParent(_worldTransform);

            return bullet;
        }

        private void ReleaseBullet(Bullet bullet)
        {
            _bulletPool.Release(bullet);
        }
    }
}
