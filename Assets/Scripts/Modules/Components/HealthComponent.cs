using System;
using UnityEngine;

namespace Modules.Components
{
    public sealed class HealthComponent : MonoBehaviour
    {
        [SerializeField]
        private int _health;

        public event Action<GameObject> OnDeath;

        public bool IsAlive()
        {
            return _health > 0;
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                OnDeath?.Invoke(gameObject);
            }
        }
    }
}
