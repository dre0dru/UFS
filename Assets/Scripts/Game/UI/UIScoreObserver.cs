using System;
using Modules;
using SnakeGame;
using Zenject;

namespace Game.UI
{
    public class UIScoreObserver : IInitializable, IDisposable
    {
        private readonly IGameUI _gameUI;
        private readonly IScore _score;

        public UIScoreObserver(IGameUI gameUI, IScore score)
        {
            _gameUI = gameUI;
            _score = score;
        }

        public void Initialize()
        {
            _score.OnStateChanged += OnScoreChanged;

            OnScoreChanged(_score.Current);
        }

        public void Dispose()
        {
            _score.OnStateChanged -= OnScoreChanged;
        }

        private void OnScoreChanged(int score)
        {
            _gameUI.SetScore(score.ToString());
        }
    }
}
