using System;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class PistolVfxInstaller : SceneEntityInstaller
    {
        [SerializeField]
        private ParticleSystem _attackVfx;

        public override void Install(IEntity entity)
        {
            entity.GetAttackEvent().Subscribe(() => _attackVfx.Play());
        }
    }
}
