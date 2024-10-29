using System.Collections;
using System.Collections.Generic;
using Game.Components;
using UnityEngine;

namespace Game.Enemies
{
    public sealed class EnemySpawnController : MonoBehaviour
    {
        [SerializeField]
        private EnemySpawner _enemySpawner;

        [SerializeField]
        private int _maxSpawnedEnemies = 7;

        [SerializeField]
        private float _enemySpawnDelay = 1;

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
                yield return new WaitForSeconds(_enemySpawnDelay);

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
            }
        }

        private void OnDestroyed(GameObject enemy)
        {
            if (_activeEnemies.Remove(enemy))
            {
                enemy.GetComponent<HealthComponent>().OnDeath -= OnDestroyed;

                _enemySpawner.DespawnEnemy(enemy);
            }
        }
    }
}
