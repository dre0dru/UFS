using Game.Scripts.Components;
using UnityEngine;

namespace Game.Scripts.Objects
{
    public class Snake : MonoBehaviour, MovementComponent.IMovementCondition, TossComponent.ITossCondition
    {
        [SerializeField]
        private MovementComponent _movementComponent;

        [SerializeField]
        private TossComponent _tossComponent;

        [SerializeField]
        private HealthComponent _healthComponent;

        private void Awake()
        {
            _movementComponent.Construct(this);
            _tossComponent.Construct(this);
        }

        public bool CanMove()
        {
            return _healthComponent.IsAlive;
        }

        public bool CanToss()
        {
            return _healthComponent.IsAlive;
        }
    }
}
