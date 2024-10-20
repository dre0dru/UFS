using UnityEngine;

namespace Modules.Players
{
    public class PlayerService : MonoBehaviour
    {
        [SerializeField]
        private PlayerSpawner _playerSpawner;

        private GameObject _player;

        public GameObject Player => _player;

        private void Awake()
        {
            _player = _playerSpawner.SpawnPlayer();
        }
    }
}
