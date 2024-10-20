using System;
using Modules.Components;
using UnityEngine;

namespace Modules.Enemies
{
    public sealed class EnemyAttackAgent : MonoBehaviour
    {
        [SerializeField]
        private WeaponComponent _weaponComponent;

        [SerializeField]
        private EnemyMoveAgent _moveAgent;

        [SerializeField]
        private float _countdown;

        private GameObject _target;
        private float _currentTime;

        public event Action<Vector2, Vector2> OnShoot;

        private void FixedUpdate()
        {
            if (!CanShoot())
            {
                return;
            }

            ShootByCountdown();
        }

        private void Reset()
        {
            _currentTime = _countdown;
        }

        public void SetTarget(GameObject target)
        {
            _target = target;
        }

        private bool CanShoot()
        {
            return _moveAgent.IsDestinationReached &&
                   _target.GetComponent<HealthComponent>().IsAlive();
        }

        private void ShootByCountdown()
        {
            _currentTime -= Time.fixedDeltaTime;
            if (_currentTime <= 0)
            {
                Shoot();
                _currentTime += _countdown;
            }
        }

        private void Shoot()
        {
            var startPosition = _weaponComponent.Position;
            var vector = (Vector2)_target.transform.position - startPosition;
            var direction = vector.normalized;
            OnShoot?.Invoke(startPosition, direction);
        }
    }
}
