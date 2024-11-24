using System;
using Modules;
using SnakeGame;
using UnityEngine;
using Zenject;

namespace Game.Snake
{
    public class SnakeBoundsCollisionObserver : IInitializable, IDisposable
    {
        private readonly GameFinisher _gameFinisher;
        private readonly IWorldBounds _worldBounds;
        private readonly ISnake _snake;

        public SnakeBoundsCollisionObserver(GameFinisher gameFinisher, IWorldBounds worldBounds, ISnake snake)
        {
            _gameFinisher = gameFinisher;
            _worldBounds = worldBounds;
            _snake = snake;
        }

        public void Initialize()
        {
            _snake.OnMoved += OnSnakeMoved;
        }

        public void Dispose()
        {
            _snake.OnMoved -= OnSnakeMoved;
        }

        private void OnSnakeMoved(Vector2Int newPos)
        {
            if (!_worldBounds.IsInBounds(newPos))
            {
                _gameFinisher.FinishGame(false);
            }
        }
    }
}
