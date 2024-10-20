using Modules.Players;
using Modules.Pools;
using UnityEngine;

namespace Modules.Enemies
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        [Header("Spawn")]
        [SerializeField]
        private EnemyPositions _enemyPositions;

        [SerializeField]
        private PlayerService _playerService;

        [SerializeField]
        private Transform _worldTransform;

        [Header("Pool")]
        [SerializeField]
        private GameObjectPool _pool;

        public GameObject SpawnEnemy()
        {
            var enemy = _pool.Get();
            enemy.transform.SetParent(_worldTransform);

            var spawnPosition = _enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;

            var attackPosition = _enemyPositions.RandomAttackPosition();
            enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);

            enemy.GetComponent<EnemyAttackAgent>().SetTarget(_playerService.Player);
            return enemy;
        }

        public void DespawnEnemy(GameObject enemy)
        {
            _pool.Release(enemy);
        }
    }
}
