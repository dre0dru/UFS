using UnityEngine;

namespace Game.Scripts.Components
{
    public class PushComponent : AddAreaForceComponent
    {
        public interface IPushCondition
        {
            bool CanPush();
        }

        [SerializeField]
        private Transform _root;

        private IPushCondition _pushCondition;

        public void Construct(IPushCondition pushCondition)
        {
            _pushCondition = pushCondition;
        }

        public void Push()
        {
            if (!_pushCondition.CanPush())
            {
                return;
            }

            ApplyForce((_forcePoint.position - _root.position).normalized);
        }
    }
}
