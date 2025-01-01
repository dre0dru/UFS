using System;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class KillOnTriggerEnterComponent : MonoBehaviour
    {
        [SerializeField]
        private TriggerSensorComponent _sensor;

        public event Action Killed;

        private void Awake()
        {
            _sensor.TriggerEntered += TryToKill;
        }

        private void OnDestroy()
        {
            _sensor.TriggerEntered -= TryToKill;
        }

        private void TryToKill(Collider2D enteredCollider)
        {
            if (!enteredCollider.gameObject.TryGetComponent<HealthComponent>(out var component))
            {
                return;
            }

            component.Kill();
            Killed?.Invoke();
        }
    }
}
