using UnityEngine;

namespace Game.Bullets
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
                .SetVelocity(args.Direction * args.BulletConfig.Speed)
                .SetTeam(args.BulletConfig.Team);

            return bullet;
        }

        public void DespawnBullet(Bullet bullet)
        {
            _bulletPool.Release(bullet);
        }

        private Bullet GetBullet()
        {
            var bullet = _bulletPool.Get();
            bullet.transform.SetParent(_worldTransform);

            return bullet;
        }
    }
}
