using System;
using Game.Scripts.Common;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class TossSfxComponent : SfxComponent
    {
        [SerializeField]
        private TossComponent _tossComponent;

        private void Awake()
        {
            _tossComponent.ForceApplied += PlaySfx;
        }

        private void OnDestroy()
        {
            _tossComponent.ForceApplied -= PlaySfx;
        }
    }
}
