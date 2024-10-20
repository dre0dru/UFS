using System;
using Modules.Components;
using Modules.Players;
using UnityEngine;

namespace Game
{
    public class PlayerDeathObserver : MonoBehaviour
    {
        [SerializeField]
        private GameManager _gameManager;

        [SerializeField]
        private PlayerService _playerService;

        private HealthComponent _playerHealth;

        private void Start()
        {
            _playerHealth = _playerService.Player.GetComponent<HealthComponent>();
            _playerHealth.OnDeath += OnCharacterDeath;
        }

        private void OnDestroy()
        {
            _playerHealth.OnDeath -= OnCharacterDeath;
        }

        private void OnCharacterDeath(GameObject _)
        {
            _gameManager.FinishGame();
        }
    }
}
