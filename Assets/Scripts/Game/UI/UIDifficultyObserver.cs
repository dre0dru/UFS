using System;
using Modules;
using SnakeGame;
using Zenject;

namespace Game.UI
{
    public class UIDifficultyObserver : IInitializable, IDisposable
    {
        private readonly IGameUI _gameUI;
        private readonly IDifficulty _difficulty;

        public UIDifficultyObserver(IGameUI gameUI, IDifficulty difficulty)
        {
            _gameUI = gameUI;
            _difficulty = difficulty;
        }

        public void Initialize()
        {
            _difficulty.OnStateChanged += OnDifficultyChanged;
        }

        public void Dispose()
        {
            _difficulty.OnStateChanged -= OnDifficultyChanged;
        }


        private void OnDifficultyChanged()
        {
            _gameUI.SetDifficulty(_difficulty.Current, _difficulty.Max);
        }
    }
}
