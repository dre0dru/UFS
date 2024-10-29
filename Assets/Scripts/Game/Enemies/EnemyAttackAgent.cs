using System;
using Game.Components;
using UnityEngine;

namespace Game.Enemies
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
            _weaponComponent.Shoot(_target);
        }
    }
}
