using UnityEngine;

namespace Game.Scripts.Components
{
    //Надо было вместо таких компонентов все это через медиатор соединять, то есть через Objects,
    //а не плодить кучу компонентов вида Действие_OnCollisiton/OnTrigger
    public class TossOnTriggerComponent : MonoBehaviour
    {
        [SerializeField]
        private TossComponent _tossComponent;

        [SerializeField]
        private TriggerSensorComponent _triggerSensorComponent;

        private void Awake()
        {
            _triggerSensorComponent.TriggerEntered += OnTriggerEntered;
        }

        private void OnDestroy()
        {
            _triggerSensorComponent.TriggerEntered -= OnTriggerEntered;
        }

        private void OnTriggerEntered(Collider2D obj)
        {
            _tossComponent.Toss();
        }
    }
}
