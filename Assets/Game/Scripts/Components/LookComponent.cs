using System;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class LookComponent : MonoBehaviour
    {
        [SerializeField]
        private MovementComponent _movementComponent;

        [SerializeField]
        private Transform _transform;

        private void Awake()
        {
            _movementComponent.DirectionChanged += OnDirectionChanged;
        }

        private void OnDestroy()
        {
            _movementComponent.DirectionChanged -= OnDirectionChanged;
        }

        private void OnDirectionChanged(bool isMovingRight)
        {
            _transform.localScale = new Vector3(isMovingRight ? 1 : -1,
                _transform.localScale.y, _transform.localScale.z);
        }
    }
}
