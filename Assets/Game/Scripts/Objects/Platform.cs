using System;
using Game.Scripts.Components;
using UnityEngine;

namespace Game.Scripts.Objects
{
    public class Platform : MonoBehaviour, MovementComponent.IMovementCondition
    {
        [SerializeField]
        private MovementComponent _movementComponent;

        private void Awake()
        {
            _movementComponent.Construct(this);
        }

        public bool CanMove()
        {
            return true;
        }
    }
}
