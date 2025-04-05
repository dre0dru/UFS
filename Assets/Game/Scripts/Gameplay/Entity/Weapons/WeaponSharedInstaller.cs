using System;
using Atomic.Elements;
using Atomic.Entities;
using Modules.Gameplay;
using UnityEngine;

namespace Game.Gameplay
{
    //Должен идти первым, так как остальные инсталлеры зависят от данных  в нем
    public class WeaponSharedInstaller: SceneEntityInstaller
    {
        [SerializeField]
        private Transform _firePoint;

        [SerializeField]
        private Cooldown _attackCooldown = new(1f, 1f);

        [SerializeField]
        private int _damage = 1;

        public override void Install(IEntity entity)
        {
            //TODO не забывать про такой вариант апдейта вместо бехавиора
            entity.WhenUpdate(_attackCooldown.Tick);

            entity.AddDamage(new Const<int>(_damage));
            entity.AddFirePoint(_firePoint);

            entity.AddAttackCooldown(_attackCooldown);
            entity.AddAttackEvent(new BaseEvent());
            entity.AddAttackCondition(new AndExpression(
                () => entity.GetAttackCooldown().IsExpired())
            //TODO либо сюда, либо потом отдельно для пистолета надо еще проверять патроны?
            );
        }
    }
}
