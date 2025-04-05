using Atomic.Elements;
using Atomic.Presenters;
using Game.Gameplay;
using Modules.Gameplay;
using UnityEngine;

namespace Game.UI
{
    public class HealthScreenPresenter : Presenter
    {
        [SerializeField]
        private HealthScreen _healthScreen;

        private IEvent<TakeDamageArgs> _takeDamageEvent;
        private Health _health;

        protected override void OnInit()
        {
            var player = MainContext.Instance.GetPlayer();

            _takeDamageEvent = player.GetDamageTakenEvent();
            _health = player.GetHealth();
        }

        protected override void OnShow()
        {
            _takeDamageEvent.Subscribe(OnTakeDamageEvent);
            _health.OnStateChanged += OnHealthChanged;
        }

        protected override void OnHide()
        {
            _takeDamageEvent.Unsubscribe(OnTakeDamageEvent);
            _health.OnStateChanged += OnHealthChanged;
        }

        private void OnTakeDamageEvent(TakeDamageArgs args)
        {
            _healthScreen.TakeDamage(args.Damage);
        }

        private void OnHealthChanged()
        {
            _healthScreen.ChangePercent(_health.GetPercent());
        }
    }
}
