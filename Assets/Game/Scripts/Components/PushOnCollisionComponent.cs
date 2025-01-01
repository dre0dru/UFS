using System;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class PushOnCollisionComponent : MonoBehaviour
    {
        [SerializeField]
        private PushComponent _pushComponent;

        [SerializeField]
        private DealDamageOnCollisionComponent _dealDamageOnCollisionComponent;

        private void Awake()
        {
            _dealDamageOnCollisionComponent.DamageDealt += _pushComponent.Push;
        }

        private void OnDestroy()
        {
            _dealDamageOnCollisionComponent.DamageDealt -= _pushComponent.Push;
        }
    }
}
