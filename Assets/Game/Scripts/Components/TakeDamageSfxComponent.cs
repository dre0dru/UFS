using Game.Scripts.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class TakeDamageSfxComponent : SfxComponent
    {
        [SerializeField]
        private HealthComponent _healthComponent;

        private void Awake()
        {
            _healthComponent.TookDamage += PlaySfx;
        }

        private void OnDestroy()
        {
            _healthComponent.TookDamage -= PlaySfx;
        }
    }
}
