using System;
using UnityEngine;

namespace Modules.Players
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField]
        private Transform _spawnPoint;

        [SerializeField]
        private GameObject _playerPrefab;

        [SerializeField]
        private Transform _worldTransform;

        public GameObject SpawnPlayer()
        {
            return Instantiate(_playerPrefab, _spawnPoint.position, _spawnPoint.rotation, _worldTransform);
        }
    }
}
