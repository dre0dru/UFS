using System;
using SampleGame.Common;
using SampleGame.Gameplay;

namespace Game.Scripts.App
{
    [Serializable]
    public struct ResourceBagSnapshot
    {
        public ResourceType Type;
        public int Current;
    }

    public class ResourceBagSerializer : EntityComponentSerializer<ResourceBagSnapshot, ResourceBag>
    {
        protected override ResourceBagSnapshot Serialize(ResourceBag entityComponent)
        {
            return new ResourceBagSnapshot
            {
                Type = entityComponent.Type,
                Current = entityComponent.Current
            };
        }

        protected override void Deserialize(ResourceBag entityComponent, ResourceBagSnapshot snapshot)
        {
            entityComponent.Type = snapshot.Type;
            entityComponent.Current = snapshot.Current;
        }
    }
}
