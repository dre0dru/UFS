using Atomic.Entities;
using Modules.Gameplay;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class CharacterAnimInstaller : SceneEntityInstaller
    {
        //TODO для синка анимации стельбы и выстрела из пистолета(?), не забыть заиспользовать
        private const string fireEvent = "fire_event";

        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private AnimationEventReceiver _animationReceiver;

        public override void Install(IEntity entity)
        {
            entity.SetAnimationTransform(transform);

            entity.SetAnimator(_animator);
            entity.SetAnimationEventReceiver(_animationReceiver);

            entity.AddBehaviour<MovementAnimationBehaviour>();
            entity.AddBehaviour<ApplyRootMotionBehaviour>();
            entity.AddBehaviour<AimingAnimationBehaviour>();
            entity.AddBehaviour<TakeDamageAnimationBehaviour>();
            entity.AddBehaviour<DeathAnimationBehaviour>();
            entity.AddBehaviour<AttackAnimationBehaviour>();
            entity.AddBehaviour(new TriggerWeaponAttackOnAnimationBehaviour(fireEvent));
        }
    }
}
