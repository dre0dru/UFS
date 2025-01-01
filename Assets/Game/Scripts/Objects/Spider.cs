using Game.Scripts.Components;
using UnityEngine;

namespace Game.Scripts.Objects
{
    public class Spider : MonoBehaviour, MovementComponent.IMovementCondition, PushComponent.IPushCondition
    {
        [SerializeField]
        private MovementComponent _movementComponent;

        [SerializeField]
        private PushComponent _pushComponent;

        [SerializeField]
        private HealthComponent _healthComponent;

        private void Awake()
        {
            _movementComponent.Construct(this);
            _pushComponent.Construct(this);
        }

        public bool CanMove()
        {
            return _healthComponent.IsAlive;
        }

        public bool CanPush()
        {
            return _healthComponent.IsAlive;
        }
    }
}
