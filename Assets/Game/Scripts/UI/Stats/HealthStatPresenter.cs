using Atomic.Presenters;
using Game.Gameplay;
using Modules.Gameplay;
using UnityEngine;

namespace Game.UI
{
    public class HealthStatPresenter : Presenter
    {
        [SerializeField]
        private StatView _statView;

        private Health _health;

        protected override void OnInit()
        {
            var context = MainContext.Instance;
            _health = context.GetPlayer().GetHealth();
        }

        protected override void OnShow()
        {
            _health.OnStateChanged += Refresh;
            Refresh();
        }

        protected override void OnHide()
        {
            _health.OnStateChanged -= Refresh;
        }

        private void Refresh()
        {
            _statView.SetProgress(_health.GetPercent());
            _statView.SetText(_health.GetCurrent().ToString());
        }
    }
}
