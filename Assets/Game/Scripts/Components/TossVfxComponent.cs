using Game.Scripts.Common;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class TossVfxComponent : VfxComponent
    {
        [SerializeField]
        private TossComponent _tossComponent;

        private void Awake()
        {
            _tossComponent.ForceApplied += PlayVfx;
        }

        private void OnDestroy()
        {
            _tossComponent.ForceApplied -= PlayVfx;
        }
    }
}
