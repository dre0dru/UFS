using Game.Scripts.Components;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Common
{
    public class SfxComponent : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private AudioClip _audioClip;

        [Button]
        public void PlaySfx()
        {
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}
