using Atomic.Contexts;
using Atomic.Presenters;
using Game.Gameplay;
using Modules.Common;
using Modules.Gameplay;
using UnityEngine;

namespace Game.UI
{
    public class AimingControlPresenter: Presenter
    {
        [SerializeField]
        private Joystick _joystick;

        [SerializeField]
        private Cooldown _attackCooldown = new Cooldown(0.5f, 0.5f);

        private bool _isPointerDown;
        private IContext _context;

        private void Update()
        {
            ProcessAiming();
            ProcessAttack();
        }

        protected override void OnInit()
        {
            _context = MainContext.Instance;
        }

        protected override void OnShow()
        {
            _joystick.PointerUp += OnPointerUp;
            _joystick.PointerDown += OnPointerDown;
        }

        protected override void OnHide()
        {
            _joystick.PointerUp -= OnPointerUp;
            _joystick.PointerDown -= OnPointerDown;
        }

        private void ProcessAiming()
        {
            if (_isPointerDown)
            {
                ControlsUseCase.SetAimingDirection(_context, _joystick.Direction);
            }
            else
            {
                ControlsUseCase.SetAimingDirection(_context, Vector2.zero);
            }
        }

        private void ProcessAttack()
        {
            if (!_isPointerDown )
            {
                return;
            }

            if (!_attackCooldown.IsExpired())
            {
                _attackCooldown.Tick(Time.deltaTime);
                return;
            }

            ControlsUseCase.InvokeAttack(_context);
            _attackCooldown.Reset();
        }

        private void OnPointerDown()
        {
            _isPointerDown = true;
            _attackCooldown.Reset();
        }

        private void OnPointerUp()
        {
            _isPointerDown = false;
        }
    }
}
