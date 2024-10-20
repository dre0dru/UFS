using System.Collections;
using System.Collections.Generic;
using Modules.Bullets;
using Modules.Components;
using UnityEngine;

namespace Modules.Enemies
{
    //Опять же нарушаю SRP (две ответственности: спавн по таймеру и атака пулями), как в BulletSystem ради упрощения,
    //так как деление на 3 класса (коллекция врагов, спавнер по таймеру, атакер пулями) имхо усложнит чтение/понимание
    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField]
        private EnemySpawner _enemySpawner;

        [SerializeField]
        private BulletSystem _bulletSystem;

        [SerializeField]
        private BulletConfig _bulletConfig;

        [SerializeField]
        private int _maxSpawnedEnemies = 7;

        private readonly HashSet<GameObject> _activeEnemies = new();

        private void Start()
        {
            StartCoroutine(SpawnEnemiesRoutine());
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }

        private IEnumerator SpawnEnemiesRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);

                if (_activeEnemies.Count < _maxSpawnedEnemies)
                {
                    SpawnEnemy();
                }
            }
        }

        private void SpawnEnemy()
        {
            var enemy = _enemySpawner.SpawnEnemy();

            if (_activeEnemies.Add(enemy))
            {
                enemy.GetComponent<HealthComponent>().OnDeath += OnDestroyed;
                enemy.GetComponent<EnemyAttackAgent>().OnShoot += OnShoot;
            }
        }

        private void OnDestroyed(GameObject enemy)
        {
            if (_activeEnemies.Remove(enemy))
            {
                enemy.GetComponent<HealthComponent>().OnDeath -= OnDestroyed;
                enemy.GetComponent<EnemyAttackAgent>().OnShoot -= OnShoot;

                _enemySpawner.DespawnEnemy(enemy);
            }
        }

        private void OnShoot(Vector2 position, Vector2 direction)
        {
            _bulletSystem.ShootBullet(new BulletArgs
            {
                BulletConfig = _bulletConfig,
                Position = position,
                Direction = direction
            });
        }
    }
}
