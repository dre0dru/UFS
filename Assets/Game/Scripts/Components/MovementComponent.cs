using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class MovementComponent : MonoBehaviour
    {
        public interface IMovementCondition
        {
            bool CanMove();
        }

        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private float _speed = 5;

        [SerializeField]
        private bool _xAxisOnly;

        private IMovementCondition _movementCondition;

        public Vector2 MovementDirection {get; private set;}

        public event Action<bool> DirectionChanged;

        private void FixedUpdate()
        {
            Move();
        }

        public void Construct(IMovementCondition movementCondition)
        {
            _movementCondition = movementCondition;
        }

        [Button]
        public void SetMovementDirection(Vector2 movementDirection)
        {
            MovementDirection = movementDirection.normalized;
            var sign = Mathf.Sign(MovementDirection.x);

            if (Mathf.Abs(MovementDirection.x) > 0)
            {
                DirectionChanged?.Invoke(sign > 0);
            }
        }

        private void Move()
        {
            if (!_movementCondition.CanMove())
            {
                SetMovementDirection(Vector2.zero);
                return;
            }

            SetMovementVelocity(MovementDirection * _speed);
        }

        private void SetMovementVelocity(Vector2 movementVelocity)
        {
            if (_xAxisOnly)
            {
                var velocity = _rigidbody.velocity;
                velocity.x = movementVelocity.x;
                _rigidbody.velocity = velocity;
            }
            else
            {
                _rigidbody.velocity = movementVelocity;
            }
        }
    }
}
