using System;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class DealDamageOnCollisionComponent : MonoBehaviour
    {
        [SerializeField]
        private CollisionSensorComponent _collisionSensorComponent;

        [SerializeField]
        private int _damage = 1;

        public event Action DamageDealt;

        private void Awake()
        {
            _collisionSensorComponent.CollisionEntered += TryDealDamage;
        }

        private void OnDestroy()
        {
            _collisionSensorComponent.CollisionEntered -= TryDealDamage;
        }

        private void TryDealDamage(Collision2D collision)
        {
            if (!collision.gameObject.TryGetComponent<HealthComponent>(out var component))
            {
                return;
            }

            component.TakeDamage(_damage);
            DamageDealt?.Invoke();

        }
    }
}
