using System;
using System.Collections.Generic;
using Modules;
using SnakeGame;
using UnityEngine;

namespace Game.Coins
{
    public class CoinsSpawner
    {
        private readonly CoinsPool _coinsPool;
        private readonly IWorldBounds _worldBounds;
        private readonly ISnake _snake;

        private readonly List<Coin> _coins = new List<Coin>();

        public event Action Emptied;

        public CoinsSpawner(CoinsPool coinsPool, IWorldBounds worldBounds, ISnake snake)
        {
            _coinsPool = coinsPool;
            _worldBounds = worldBounds;
            _snake = snake;
        }

        public void Spawn(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var position = GetSpawnPosition();

                var coin = _coinsPool.Spawn(position);
                _coins.Add(coin);
            }
        }

        public bool TryDespawnCoin(Vector2Int position, out ICoin despawnedCoin)
        {
            despawnedCoin = default;

            if (!TryGetCoinByPosition(position, out var coin))
            {
                return false;
            }

            despawnedCoin = coin;
            Despawn(coin);
            return true;
        }

        private void Despawn(Coin coin)
        {
            _coins.Remove(coin);
            _coinsPool.Despawn(coin);

            if (_coins.Count == 0)
            {
                Emptied?.Invoke();
            }
        }

        private Vector2Int GetSpawnPosition()
        {
            var spawnPosition = _worldBounds.GetRandomPosition();

            while (!IsEmpty(spawnPosition))
            {
                spawnPosition = _worldBounds.GetRandomPosition();
            }

            return spawnPosition;

            bool IsEmpty(Vector2Int position)
            {
                //в идеале бы тут проверять все тело, но в интерфейсе нет нужных апи
                if (position == _snake.HeadPosition)
                {
                    return false;
                }

                return !TryGetCoinByPosition(position, out _);
            }
        }

        private bool TryGetCoinByPosition(Vector2Int position, out Coin coin)
        {
            coin = default;

            for (int i = 0; i < _coins.Count; i++)
            {
                coin = _coins[i];

                if (coin.Position == position)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
