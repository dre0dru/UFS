using UnityEngine;

namespace Game.Scripts.Components
{
    public class TossComponent : AddAreaForceComponent
    {
        public interface ITossCondition
        {
            bool CanToss();
        }

        private ITossCondition _tossCondition;

        public void Construct(ITossCondition tossCondition)
        {
            _tossCondition = tossCondition;
        }

        public void Toss()
        {
            if (!_tossCondition.CanToss())
            {
                return;
            }

            ApplyForce(Vector2.up);
        }
    }
}
