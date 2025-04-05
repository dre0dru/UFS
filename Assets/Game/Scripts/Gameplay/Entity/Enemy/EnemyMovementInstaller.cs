using Atomic.Elements;
using Atomic.Entities;
using Game.Gameplay.Common.Health;
using UnityEngine;

namespace Game.Gameplay
{
    public class EnemyMovementInstaller : SceneEntityInstaller
    {
        [SerializeField]
        private float _rotationSpeed = 15.0f;

        [SerializeField]
        private float _attackDistance = 0.2f;

        public override void Install(IEntity entity)
        {
            entity.AddMovementDirection(new ReactiveVector2());
            entity.AddMovementCondition(new AndExpression(() => HealthUseCase.IsAlive(entity),
                () => EnemyUseCase.IsAttackTargetAlive(entity),
                () => !EnemyUseCase.IsAttackTargetReached(entity)));

            entity.SetRotationSpeed(new Const<float>(_rotationSpeed));
            entity.AddRotationCondition(new AndExpression(() => HealthUseCase.IsAlive(entity)));

            entity.AddAttackDistance(_attackDistance.AsСonst());

            entity.AddBehaviour<RotationFromMovementDirectionBehaviour>();
            entity.AddBehaviour<DirectionFromTargetBehaviour>();
        }
    }
}
