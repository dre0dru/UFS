using Atomic.Entities;
using Modules.Gameplay;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class ItemPickupOnTriggerEnterBehaviour : IEntityInit, IEntityDispose
    {
        private TriggerEventReceiver _trigger;
        private IEntity _item;
        
        public void Init(in IEntity entity)
        {
            _item = entity;
            _trigger = entity.GetTriggerReceiver();
            _trigger.OnEntered += OnTriggerEntered;
        }

        public void Dispose(in IEntity entity)
        {
            _trigger.OnEntered -= OnTriggerEntered;
        }

        private void OnTriggerEntered(Collider collider)
        {
            //TODO небольшой костыль
            //только сейчас узнал, что enabled = false у компонента не отрубает
            //OnTriggerXXX эвенты
            if (!_trigger.enabled)
            {
                return;
            }

            //TODO не забывать про EntityProxy, удобнейшая штука
            if (!collider.TryGetComponent<IEntity>(out var target))
            {
                return;
            }

            ItemsUseCase.TryPickupItem(target, _item);
        }
    }
}
