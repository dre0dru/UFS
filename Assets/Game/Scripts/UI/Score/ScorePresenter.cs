using Atomic.Elements;
using Atomic.Presenters;
using Game.Gameplay;
using UnityEngine;

namespace Game.Scripts.UI.Score
{
    public class ScorePresenter : Presenter
    {
        [SerializeField]
        private ScoreView _scoreView;

        private IReactiveValue<int> _score;

        protected override void OnInit()
        {
            var context = MainContext.Instance;
            _score = context.GetScore();
        }

        protected override void OnShow()
        {
            _score.Subscribe(SetScote);
            SetScote(_score.Value);
        }

        protected override void OnHide()
        {
            _score.Unsubscribe(SetScote);
        }

        private void SetScote(int score)
        {
            _scoreView.SetScore(score.ToString());
        }
    }
}
