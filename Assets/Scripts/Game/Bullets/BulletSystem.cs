using System.Collections.Generic;
using Modules.Level;
using UnityEngine;

namespace Game.Bullets
{
    public sealed class BulletSystem : MonoBehaviour
    {
        [SerializeField]
        private LevelBounds _levelBounds;

        [SerializeField]
        private BulletSpawner _bulletSpawner;

        private readonly HashSet<Bullet> _activeBullets = new();
        private readonly List<Bullet> _bulletsCache = new();

        private void FixedUpdate()
        {
            CheckBulletsOutOfBounds();
        }

        public void ShootBullet(BulletArgs args)
        {
            var bullet = _bulletSpawner.SpawnBullet(args);

            if (_activeBullets.Add(bullet))
            {
                bullet.OnDestroyed += RemoveBullet;
            }
        }

        private void CheckBulletsOutOfBounds()
        {
            _bulletsCache.Clear();
            _bulletsCache.AddRange(_activeBullets);

            for (int i = 0, count = _bulletsCache.Count; i < count; i++)
            {
                var bullet = _bulletsCache[i];
                if (!_levelBounds.InBounds(bullet.transform.position))
                {
                    RemoveBullet(bullet);
                }
            }
        }

        private void RemoveBullet(Bullet bullet)
        {
            if (_activeBullets.Remove(bullet))
            {
                bullet.OnDestroyed -= RemoveBullet;
                _bulletSpawner.DespawnBullet(bullet);
            }
        }
    }
}
