using System;
using Game.Scripts.Common;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class JumpComponent : MonoBehaviour
    {
        public interface IJumpCondition
        {
            bool CanJump();
        }

        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private float _jumpForce = 10;

        [SerializeField]
        private Timer _cooldownTimer = new(0.5f);

        private IJumpCondition _jumpCondition;

        public event Action Jumped;

        public void Construct(IJumpCondition condition)
        {
            _jumpCondition = condition;
        }

        private void Update()
        {
            _cooldownTimer.Tick(Time.deltaTime);
        }

        public void Jump()
        {
            if (!_jumpCondition.CanJump() || !_cooldownTimer.IsTimerUp)
            {
                return;
            }

            ResetVerticalVelocity();
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _cooldownTimer.Reset();

            Jumped?.Invoke();
        }

        private void ResetVerticalVelocity()
        {
            var velocity = _rigidbody.velocity;
            velocity.y = 0;
            _rigidbody.velocity = velocity;
        }
    }
}
