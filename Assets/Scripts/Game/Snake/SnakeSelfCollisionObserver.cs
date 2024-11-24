using System;
using Modules;
using Zenject;

namespace Game.Snake
{
    public class SnakeSelfCollisionObserver: IInitializable, IDisposable
    {
        private readonly GameFinisher _gameFinisher;
        private readonly ISnake _snake;

        public SnakeSelfCollisionObserver(GameFinisher gameFinisher, ISnake snake)
        {
            _gameFinisher = gameFinisher;
            _snake = snake;
        }

        public void Initialize()
        {
            _snake.OnSelfCollided += OnSelfCollided;
        }

        public void Dispose()
        {
            _snake.OnSelfCollided -= OnSelfCollided;
        }

        private void OnSelfCollided()
        {
            _gameFinisher.FinishGame(false);
        }
    }
}
