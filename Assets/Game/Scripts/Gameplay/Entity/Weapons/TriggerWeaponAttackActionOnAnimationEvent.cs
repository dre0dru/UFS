using System;
using Atomic.Entities;
using Modules.Gameplay;

namespace Game.Gameplay
{
    //TODO вот непонятно, в какую папку положить
    //С одной стороны чисто для оружия нужно (Weapon), с другой стороны
    //используется чисто в Character инсталлере
    public class TriggerWeaponAttackOnAnimationBehaviour : IEntityInit, IEntityDispose
    {
        private readonly string _animEvent;

        private IEntity _weapon;
        private AnimationEventReceiver _animationReceiver;

        public TriggerWeaponAttackOnAnimationBehaviour(string animEvent)
        {
            _animEvent = animEvent;
        }

        public void Init(in IEntity entity)
        {
            _weapon = entity.GetWeapon();
            _animationReceiver = entity.GetAnimationEventReceiver();
            _animationReceiver.OnEvent += OnEvent;
        }

        public void Dispose(in IEntity entity)
        {
            _animationReceiver.OnEvent -= OnEvent;
        }

        private void OnEvent(string name)
        {
            if (name == _animEvent)
            {
                _weapon.GetAttackAction().Invoke();
            }
        }
    }
}
