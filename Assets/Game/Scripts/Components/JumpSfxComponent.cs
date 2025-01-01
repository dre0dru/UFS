using Game.Scripts.Common;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class JumpSfxComponent : SfxComponent
    {
        [SerializeField]
        private JumpComponent _jumpComponent;

        private void Awake()
        {
            _jumpComponent.Jumped += PlaySfx;
        }

        private void OnDestroy()
        {
            _jumpComponent.Jumped -= PlaySfx;
        }
    }
}
