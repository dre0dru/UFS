using Atomic.Presenters;
using Game.Gameplay;
using Modules.Gameplay;
using UnityEngine;

namespace Game.UI
{
    public class AmmoStatPresenter: Presenter
    {
        [SerializeField]
        private StatView _statView;

        private Ammo _ammo;

        protected override void OnInit()
        {
            var context = MainContext.Instance;
            _ammo = context.GetPlayer().GetWeapon().GetAmmo();
        }

        protected override void OnShow()
        {
            _ammo.OnStateChanged += Refresh;
            Refresh();
        }
        
        protected override void OnHide()
        {
            _ammo.OnStateChanged -= Refresh;
        }

        private void Refresh()
        {
            // _statView.SetProgress(_ammo.GetPercent());
            _statView.SetText(_ammo.GetCount().ToString());
        }
    }
}
