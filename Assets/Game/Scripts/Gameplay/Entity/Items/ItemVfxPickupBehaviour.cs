using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    public class ItemVfxPickupBehaviour : IEntityInit, IEntityDispose
    {
        private readonly ParticleSystem _vfx;

        public ItemVfxPickupBehaviour(ParticleSystem vfx)
        {
            _vfx = vfx;
        }

        public void Init(in IEntity entity)
        {
            entity.GetPickupItemEvent().Subscribe(OnPickedUp);
        }


        public void Dispose(in IEntity entity)
        {
            entity.GetPickupItemEvent().Unsubscribe(OnPickedUp);
        }

        private void OnPickedUp()
        {
            _vfx.Play();
        }
    }
}
