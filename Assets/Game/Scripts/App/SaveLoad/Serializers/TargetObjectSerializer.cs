using System;
using Modules.Entities;
using SampleGame.Gameplay;

namespace Game.Scripts.App
{
    [Serializable]
    public struct TargetObjectSnapshot
    {
        public int EntityId;
    }

    public class TargetObjectSerializer: EntityComponentSerializer<TargetObjectSnapshot, TargetObject>
    {
        private const int DefaultEntityId = -1;

        private readonly EntityWorld _entityWorld;

        public TargetObjectSerializer(EntityWorld entityWorld)
        {
            _entityWorld = entityWorld;
        }

        protected override TargetObjectSnapshot Serialize(TargetObject entityComponent)
        {
            var entityId = DefaultEntityId;

            if (entityComponent.Value != null)
            {
                entityId = entityComponent.Value.Id;
            }

            return new TargetObjectSnapshot
            {
                EntityId = entityId,
            };
        }

        protected override void Deserialize(TargetObject entityComponent, TargetObjectSnapshot snapshot)
        {
            if (!_entityWorld.TryGet(snapshot.EntityId, out var entity))
            {
                return;
            }

            entityComponent.Value = entity;
        }
    }
}
