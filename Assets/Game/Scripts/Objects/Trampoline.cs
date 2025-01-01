using System;
using Game.Scripts.Components;
using UnityEngine;

namespace Game.Scripts.Objects
{
    public class Trampoline : MonoBehaviour, TossComponent.ITossCondition
    {
        [SerializeField]
        private TossComponent _tossComponent;

        private void Awake()
        {
            _tossComponent.Construct(this);
        }

        public bool CanToss()
        {
            return true;
        }
    }
}
