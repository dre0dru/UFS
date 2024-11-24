using System;
using Game.Coins;
using Modules;
using Zenject;

namespace Game.Difficulty
{
    public class DifficultyController : IInitializable, IDisposable
    {
        private readonly GameFinisher _gameFinisher;
        private readonly IDifficulty _difficulty;
        private readonly CoinsSpawner _coinsSpawner;

        public DifficultyController(GameFinisher gameFinisher, IDifficulty difficulty, CoinsSpawner coinsSpawner)
        {
            _gameFinisher = gameFinisher;
            _difficulty = difficulty;
            _coinsSpawner = coinsSpawner;
        }

        public void Initialize()
        {
            _coinsSpawner.Emptied += OnCoinsEmptied;

            OnCoinsEmptied();
        }

        public void Dispose()
        {
            _coinsSpawner.Emptied -= OnCoinsEmptied;
        }

        private void OnCoinsEmptied()
        {
            if (!_difficulty.Next(out var difficulty))
            {
                _gameFinisher.FinishGame(true);
                return;
            }
        }
    }
}
