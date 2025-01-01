using System;
using Game.Scripts.Common;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class AddAreaForceComponent : MonoBehaviour
    {
        [SerializeField]
        protected Transform _forcePoint;

        [SerializeField]
        private Timer _cooldownTimer = new(1.0f);

        [SerializeField]
        private float _areaRadius = 2.0f;

        [SerializeField]
        private float _force = 3.0f;

        [SerializeField]
        private LayerMask _layerMask;

        private readonly Collider2D[] _collidersCache = new Collider2D[5];

        public event Action ForceApplied;

        private void Update()
        {
            _cooldownTimer.Tick(Time.deltaTime);
        }

        public void ApplyForce(Vector2 direction)
        {
            if (!_cooldownTimer.IsTimerUp)
            {
                return;
            }

            var count = Physics2D.OverlapCircleNonAlloc(_forcePoint.position, _areaRadius, _collidersCache, _layerMask);

            for (int i = 0; i < count; i++)
            {
                var collider = _collidersCache[i];

                collider.attachedRigidbody?.AddForce(direction * _force);
            }

            _cooldownTimer.Reset();
            ForceApplied?.Invoke();
        }
    }
}
