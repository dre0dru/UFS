using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class ItemVisualInstaller : SceneEntityInstaller
    {
        [SerializeField]
        private ParticleSystem _vfx;

        [SerializeField]
        private GameObject _visual;

        [SerializeField]
        private AudioSource _audioSource;
        
        public override void Install(IEntity entity)
        {
            //TODO понимаю, что по названию не совсем подходит, но не хочется
            //еще один тип данных создавать чисто для визуала, поэтому переиспользую, что есть
            entity.AddAnimationTransform(_visual.transform);
            entity.AddAudioSource(_audioSource);

            entity.AddBehaviour<ItemAudioPickupBehaviour>();
            entity.AddBehaviour(new ItemVfxPickupBehaviour(_vfx));
        }
    }
}
