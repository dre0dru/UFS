using Game.Bullets;
using Game.Components;
using UnityEngine;

namespace Game.Players
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField]
        private Transform _spawnPoint;

        [SerializeField]
        private GameObject _playerPrefab;

        [SerializeField]
        private Transform _worldTransform;

        [SerializeField]
        private BulletSystem _bulletSystem;

        public GameObject SpawnPlayer()
        {
            var player = Instantiate(_playerPrefab, _spawnPoint.position, _spawnPoint.rotation, _worldTransform);
            player.GetComponent<WeaponComponent>().Construct(_bulletSystem);

            return player;
        }
    }
}
