using UnityEngine;

namespace Game.Scripts.Components
{
    //Надо было вместо таких компонентов все это через медиатор соединять, то есть через Objects,
    //а не плодить кучу компонентов вида Действие_OnCollisiton/OnTrigger
    public class TossOnCollisionComponent : MonoBehaviour
    {
        [SerializeField]
        private TossComponent _tossComponent;

        [SerializeField]
        private DealDamageOnCollisionComponent _dealDamageOnCollisionComponent;

        private void Awake()
        {
            _dealDamageOnCollisionComponent.DamageDealt += _tossComponent.Toss;
        }

        private void OnDestroy()
        {
            _dealDamageOnCollisionComponent.DamageDealt -= _tossComponent.Toss;
        }
    }
}
