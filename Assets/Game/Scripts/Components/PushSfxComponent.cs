using System;
using Game.Scripts.Common;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class PushSfxComponent : SfxComponent
    {
        [SerializeField]
        private PushComponent _pushComponent;

        private void Awake()
        {
            _pushComponent.ForceApplied += PlaySfx;
        }

        private void OnDestroy()
        {
            _pushComponent.ForceApplied -= PlaySfx;
        }
    }
}
