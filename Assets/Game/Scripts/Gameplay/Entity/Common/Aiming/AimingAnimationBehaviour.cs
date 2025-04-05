using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class AimingAnimationBehaviour: IEntityInit, IEntityUpdate
    {
        private static readonly int AimX = Animator.StringToHash("AimX");
        private static readonly int AimZ = Animator.StringToHash("AimZ");
        private static readonly int IsAiming = Animator.StringToHash("IsAiming");

        private Animator _animator;

        public void Init(in IEntity entity)
        {
            _animator = entity.GetAnimator();
        }

        public void OnUpdate(in IEntity entity, in float deltaTime)
        {
            var aimDirection = entity.GetAimingDirection().Value;

            _animator.SetFloat(AimX, aimDirection.x);
            _animator.SetFloat(AimZ, aimDirection.y);
            _animator.SetBool(IsAiming, AimingUseCase.IsAiming(entity));
        }
    }
}
