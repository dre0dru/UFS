using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    //TODO сложно назвать стандартным применением рут моушена, но это из-за непоняток
    //с тем, как применяется рут моушн в проекте
    public class ApplyRootMotionBehaviour : IEntityInit, IEntityUpdate
    {
        private Transform _rootTransform;
        private Transform _animationTransform;

        public void Init(in IEntity entity)
        {
            _rootTransform = entity.GetTransform();
            _animationTransform = entity.GetAnimationTransform();
        }

        public void OnUpdate(in IEntity entity, in float deltaTime)
        {
            _rootTransform.position += _animationTransform.localPosition;
            _animationTransform.localPosition = Vector3.zero;
        }
    }
}
