using System;
using Game.Coins;
using Modules;
using UnityEngine;
using Zenject;

namespace Game.Snake
{
    public class SnakeCoinCollisionObserver : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly IScore _score;
        private readonly CoinsSpawner _coinsSpawner;

        public SnakeCoinCollisionObserver(ISnake snake, IScore score, CoinsSpawner coinsSpawner)
        {
            _snake = snake;
            _score = score;
            _coinsSpawner = coinsSpawner;
        }

        public void Initialize()
        {
            _snake.OnMoved += OnSnakeMoved;
        }

        public void Dispose()
        {
            _snake.OnMoved -= OnSnakeMoved;
        }

        private void OnSnakeMoved(Vector2Int position)
        {
            if (!_coinsSpawner.TryDespawnCoin(position, out var coin))
            {
                return;
            }

            _snake.Expand(coin.Bones);
            _score.Add(coin.Score);
        }
    }
}
