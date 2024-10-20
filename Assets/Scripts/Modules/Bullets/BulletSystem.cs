using System.Collections.Generic;
using Modules.Level;
using UnityEngine;

namespace Modules.Bullets
{
    //Да, две ответственности: нанесение урона и проверка на выход за пределы уровня
    //Но разбивать на 3 класса из-за этого (коллекция пуль, проверщик на пределы, дамагер) выглядит излишним
    //Класс и так маленький и легко читается, но он нарушает SRP, плюс не попадает ни в один из
    //шаблонов GRASP
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
                bullet.OnCollisionEntered += OnBulletCollision;
            }
        }

        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            bullet.DealDamage(collision.gameObject);
            RemoveBullet(bullet);
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
                bullet.OnCollisionEntered -= OnBulletCollision;
                _bulletSpawner.DespawnBullet(bullet);
            }
        }
    }
}
