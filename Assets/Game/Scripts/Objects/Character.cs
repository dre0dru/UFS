using System;
using Game.Scripts.Components;
using UnityEngine;

namespace Game.Scripts.Objects
{
    public class Character : MonoBehaviour, MovementComponent.IMovementCondition, JumpComponent.IJumpCondition,
        PushComponent.IPushCondition, TossComponent.ITossCondition
    {
        [SerializeField]
        private MovementComponent _movementComponent;

        [SerializeField]
        private HealthComponent _healthComponent;

        [SerializeField]
        private JumpComponent _jumpComponent;

        [SerializeField]
        private GroundCheckComponent _groundCheckComponent;

        [SerializeField]
        private TossComponent _tossComponent;

        [SerializeField]
        private PushComponent _pushComponent;

        private void Awake()
        {
            _movementComponent.Construct(this);
            _jumpComponent.Construct(this);
            _tossComponent.Construct(this);
            _pushComponent.Construct(this);

            _jumpComponent.Jumped += _groundCheckComponent.Unground;
        }

        private void OnDestroy()
        {
            _jumpComponent.Jumped -= _groundCheckComponent.Unground;
        }

        public bool CanMove()
        {
            return _healthComponent.IsAlive;
        }

        public bool CanJump()
        {
            return _groundCheckComponent.IsGrounded && _healthComponent.IsAlive;
        }

        public bool CanPush()
        {
            return _healthComponent.IsAlive;
        }

        public bool CanToss()
        {
            return _groundCheckComponent.IsGrounded && _healthComponent.IsAlive;
        }
    }
}
