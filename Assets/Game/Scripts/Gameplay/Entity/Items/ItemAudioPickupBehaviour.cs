using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class ItemAudioPickupBehaviour : IEntityInit, IEntityDispose
    {
        private AudioSource _audioSource;

        public void Init(in IEntity entity)
        {
            _audioSource = entity.GetAudioSource();
            entity.GetPickupItemEvent().Subscribe(OnPickedUp);
        }

        public void Dispose(in IEntity entity)
        {
            entity.GetPickupItemEvent().Unsubscribe(OnPickedUp);
        }

        private void OnPickedUp()
        {
            _audioSource.Play();
        }
    }
}
