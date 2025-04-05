using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class HandsInstaller : SceneEntityInstaller
    {
        [SerializeField]
        private float _attackDistance = 0.2f;

        [SerializeField]
        private LayerMask _attackLayer;

        public override void Install(IEntity entity)
        {
            entity.AddMeleeTag();
            entity.AddAttackDistance(_attackDistance.AsСonst());
            entity.AddRaycastLayer(_attackLayer.AsСonst());

            entity.AddAttackAction(new BaseAction(
                () => HandsUseCase.Attack(entity))
            );

            entity.AddTransform(transform);
        }
    }
}
