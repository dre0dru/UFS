using System;
using Game.Scripts.Components;
using UnityEngine;

namespace Game.Scripts.Objects
{
    public class Trap : MonoBehaviour
    {
        [SerializeField]
        private DealDamageOnCollisionComponent _dealDamageOnCollisionComponent;

        [SerializeField]
        private HealthComponent _healthComponent;

        private void Awake()
        {
            _dealDamageOnCollisionComponent.DamageDealt += _healthComponent.Kill;
        }

        private void OnDestroy()
        {
            _dealDamageOnCollisionComponent.DamageDealt -= _healthComponent.Kill;
        }
    }
}
