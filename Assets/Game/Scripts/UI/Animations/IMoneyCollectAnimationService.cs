using System;
using UnityEngine;

namespace Game.Scripts.UI.Animations
{
    public interface IMoneyCollectAnimationService
    {
        event Action AnimationFinished;
        void StartAnimation(Vector3 startPosition);
    }
}
