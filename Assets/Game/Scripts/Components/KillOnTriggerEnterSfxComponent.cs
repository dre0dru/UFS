using System;
using Game.Scripts.Common;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class KillOnTriggerEnterSfxComponent : SfxComponent
    {
        [SerializeField]
        private KillOnTriggerEnterComponent _killOnTriggerEnterComponent;

        private void Awake()
        {
            _killOnTriggerEnterComponent.Killed += PlaySfx;
        }

        private void OnDestroy()
        {
            _killOnTriggerEnterComponent.Killed -= PlaySfx;
        }
    }
}
