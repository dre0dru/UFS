using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class HealthComponent : MonoBehaviour
    {
        private const int DefaultHealth = 5;

        [SerializeField]
        private int _maxHealth = DefaultHealth;

        [SerializeField]
        private int _currentHealth = DefaultHealth;

        public bool IsAlive => _currentHealth > 0;

        public event Action TookDamage;
        public event Action Died;

        [Button]
        public void TakeDamage(int amount)
        {
            if (!IsAlive)
            {
                return;
            }

            _currentHealth -= amount;

            TookDamage?.Invoke();

            if (!IsAlive)
            {
                Died?.Invoke();
            }
        }

        [Button]
        public void Kill()
        {
            TakeDamage(_currentHealth);
        }
    }
}
