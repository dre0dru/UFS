using System;
using Atomic.Entities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Gameplay
{
    public class PistolAudioInstaller : SceneEntityInstaller
    {
        [SerializeField] 
        private AudioSource _audioSource;
        
        [SerializeField]
        private Vector2 _minMaxPitch = new Vector2(.9f, 1.1f);

        public override void Install(IEntity entity)
        {
            entity.AddAudioSource(_audioSource);
            entity.GetAttackEvent().Subscribe(() =>
            {
                _audioSource.pitch = Random.Range(_minMaxPitch.x, _minMaxPitch.y);
                _audioSource.Play();
            });
            
        }
    }
}
