using System;
using SnakeGame;
using Zenject;

namespace Game.UI
{
    public class UIGameFinishedObserver : IInitializable, IDisposable
    {
        private readonly GameFinisher _gameFinisher;
        private readonly IGameUI _gameUI;

        public UIGameFinishedObserver(GameFinisher gameFinisher, IGameUI gameUI)
        {
            _gameFinisher = gameFinisher;
            _gameUI = gameUI;
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
            _gameUI.GameOver(isWin);
        }
    }
}
