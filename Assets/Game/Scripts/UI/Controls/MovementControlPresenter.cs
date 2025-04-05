using Atomic.Contexts;
using Atomic.Presenters;
using Game.Gameplay;
using Modules.Common;
using UnityEngine;

namespace Game.UI
{
    public class MovementControlPresenter : Presenter
    {
        [SerializeField]
        private Joystick _joystick;

        private bool _isPointerDown;
        private IContext _context;

        private void Update()
        {
            if (_isPointerDown)
            {
                ControlsUseCase.SetMovementDirection(_context, _joystick.Direction);
            }
            else
            {
                ControlsUseCase.SetMovementDirection(_context, Vector2.zero);
            }
        }

        protected override void OnInit()
        {
            _context = MainContext.Instance;
        }

        protected override void OnShow()
        {
            _joystick.PointerDown += OnPointerDown;
            _joystick.PointerUp += OnPointerUp;
        }

        protected override void OnHide()
        {
            _joystick.PointerDown -= OnPointerDown;
            _joystick.PointerUp -= OnPointerUp;
        }

        private void OnPointerDown()
        {
            _isPointerDown = true;
        }

        private void OnPointerUp()
        {
            _isPointerDown = false;
        }
    }
}
