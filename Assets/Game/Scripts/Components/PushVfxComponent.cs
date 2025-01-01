using Game.Scripts.Common;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class PushVfxComponent : VfxComponent
    {
        [SerializeField]
        private PushComponent _pushComponent;

        private void Awake()
        {
            _pushComponent.ForceApplied += PlayVfx;
        }

        private void OnDestroy()
        {
            _pushComponent.ForceApplied -= PlayVfx;
        }
    }
}
