using UnityEngine;

namespace Game.Scripts.Common
{
    public class VfxComponent : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem _particleSystem;

        public void PlayVfx()
        {
            _particleSystem.Play();
        }
    }
}
