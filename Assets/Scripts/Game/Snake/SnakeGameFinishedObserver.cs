using System;
using Modules;
using Zenject;

namespace Game.Snake
{
    public class SnakeGameFinishedObserver: IInitializable, IDisposable
    {
        private readonly GameFinisher _gameFinisher;
        private readonly ISnake _snake;

        public SnakeGameFinishedObserver(GameFinisher gameFinisher, ISnake snake)
        {
            _gameFinisher = gameFinisher;
            _snake = snake;
        }

        public void Initialize()
        {
            _gameFinisher.GameFinished += OnGameFinished;
        }

        public void Dispose()
        {
            _gameFinisher.GameFinished -= OnGameFinished;
        }

        private void OnGameFinished(bool isWin)
        {
            _snake.SetActive(false);
        }
    }
}
