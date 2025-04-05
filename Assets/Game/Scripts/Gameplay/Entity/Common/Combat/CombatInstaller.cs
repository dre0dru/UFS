using Atomic.Elements;
using Atomic.Entities;
using Game.Gameplay.Common.Health;
using UnityEngine;

namespace Game.Gameplay
{
    public class CombatInstaller : SceneEntityInstaller
    {
        [SerializeField]
        private SceneEntity _weapon;

        public override void Install(IEntity entity)
        {
            InstallWeapon(entity);
            InstallCombat(entity);
        }

        private void InstallWeapon(IEntity entity)
        {
            entity.AddWeapon(_weapon);
        }

        private void InstallCombat(IEntity entity)
        {
            entity.AddAttackEvent(new BaseEvent());

            entity.AddAttackCondition(new AndExpression(
                () => HealthUseCase.IsAlive(entity),
                () => _weapon.GetAttackCondition().Invoke()
            ));

            entity.AddAttackAction(new BaseAction(() =>
            {
                if (entity.GetAttackCondition().Invoke())
                {
                    entity.GetAttackEvent().Invoke();
                }
            }));
        }
    }
}
