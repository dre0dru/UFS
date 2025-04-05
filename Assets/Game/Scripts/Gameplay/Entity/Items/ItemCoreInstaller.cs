using Atomic.Entities;
using Modules.Gameplay;
using UnityEngine;

namespace Game.Gameplay
{
    public class ItemCoreInstaller : SceneEntityInstaller
    {
        [SerializeField]
        private TriggerEventReceiver _triggerEventReceiver;

        public override void Install(IEntity entity)
        {
            entity.AddPickUppableTag();
            entity.AddTriggerReceiver(_triggerEventReceiver);
        }
    }
}
