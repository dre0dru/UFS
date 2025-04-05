using Atomic.Elements;
using Atomic.Entities;
using Game.Gameplay.Common.Health;
using UnityEngine;

namespace Game.Gameplay
{
    //TODO разбить на move/aim или на move/rotation? но и спамить инсталлерами тоже неохота
    public class CharacterMovementInstaller: SceneEntityInstaller
    {
        [SerializeField]
        private float _rotationSpeed = 15.0f;

        public override void Install(IEntity entity)
        {
            entity.AddMovementDirection(new ReactiveVector2());
            entity.AddMovementCondition(new AndExpression(() => HealthUseCase.IsAlive(entity)));

            entity.SetRotationSpeed(new Const<float>(_rotationSpeed));
            entity.AddRotationCondition(new AndExpression(() => HealthUseCase.IsAlive(entity)));

            entity.AddAimingDirection(new ReactiveVector2());

            entity.AddBehaviour<RotationFromMovementDirectionBehaviour>();
            entity.AddBehaviour<RotationFromAimingDirectionBehaviour>();
        }
    }
}
