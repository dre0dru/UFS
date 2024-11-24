using System;
using Modules;
using Zenject;

namespace Game.Coins
{
    public class CoinsDifficultyObserver : IInitializable, IDisposable
    {
        private readonly IDifficulty _difficulty;
        private readonly CoinsSpawner _coinsSpawner;

        public CoinsDifficultyObserver(IDifficulty difficulty, CoinsSpawner coinsSpawner)
        {
            _difficulty = difficulty;
            _coinsSpawner = coinsSpawner;
        }

        public void Initialize()
        {
            _difficulty.OnStateChanged += SpawnCoins;
        }

        public void Dispose()
        {
            _difficulty.OnStateChanged -= SpawnCoins;
        }

        private void SpawnCoins()
        {
            _coinsSpawner.Spawn(_difficulty.Current);
        }
    }
}
