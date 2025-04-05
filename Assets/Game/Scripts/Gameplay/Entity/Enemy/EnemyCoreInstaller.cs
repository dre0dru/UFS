using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class EnemyCoreInstaller : SceneEntityInstaller
    {
        public override void Install(IEntity entity)
        {
            entity.AddEnemyTag();
            entity.AddTransform(transform);
            entity.AddAttackTarget(new BaseVariable<IEntity>());
            entity.AddBehaviour<IncreaseScoreOnDeathBehaviour>();
            entity.AddBehaviour<AttackTargetBehaviour>();
        }
    }
}
