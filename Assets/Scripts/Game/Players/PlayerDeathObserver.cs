using Game.Components;
using UnityEngine;

namespace Game.Players
{
    public class PlayerDeathObserver : MonoBehaviour
    {
        [SerializeField]
        private GameFinisher _gameFinisher;

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
            _gameFinisher.FinishGame();
        }
    }
}
