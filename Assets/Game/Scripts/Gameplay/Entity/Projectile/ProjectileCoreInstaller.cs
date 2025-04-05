using Atomic.Elements;
using Atomic.Entities;
using Modules.Gameplay;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class ProjectileCoreInstaller : SceneEntityInstaller
    {
        [SerializeField]
        private Cooldown _lifeTime = new(3f, 3f);

        [SerializeField]
        private float _moveSpeed = 45f;

        [SerializeField]
        private int _damage = 1;

        [SerializeField]
        private CollisionEventReceiver _collisionEventReceiver;

        [SerializeField]
        private Transform _root;

        public override void Install(IEntity entity)
        {
            entity.AddProjectileTag();
            entity.AddTransform(_root);

            entity.AddDamage(_damage.AsСonst());

            entity.AddLifetime(_lifeTime);
            entity.AddDestroyAction(new BaseAction(() => SceneEntity.Destroy(entity)));

            entity.AddMovementSpeed(_moveSpeed.AsСonst());
            entity.AddCollisionReceiver(_collisionEventReceiver);
            entity.AddMovementDirection(new BaseVariable<Vector2>(new Vector2(_root.forward.x, _root.forward.z).normalized));

            entity.AddBehaviour<DirectionalMovementBehaviour>();
            entity.AddBehaviour<ProjectileDestroyAfterLifetimeBehaviour>();
            entity.AddBehaviour<ProjectileCollisionBehaviour>();


        }
    }
}
