using System;
using System.Collections.Generic;
using Modules.Entities;
using SampleGame.Common;
using UnityEngine;

namespace Game.Scripts.App
{
    [Serializable]
    public struct EntityWorldSnapshot
    {
        public List<EntitySnapshot> Entities;
    }

    [Serializable]
    public struct EntitySnapshot
    {
        public SerializedVector3 Position;
        public SerializedVector3 Rotation;
        public int EntityId;
        public string ConfigId;
        public Dictionary<string, string> EntityState;
    }

    public class EntitiesSerializer : GameSerializer<EntityWorldSnapshot>
    {
        private readonly EntityWorld _entityWorld;
        private readonly EntityCatalog _entityCatalog;
        private readonly Dictionary<Type, IEntityComponentSerializer> _serializers;
        private readonly List<IEntityComponent> _components = new();

        public EntitiesSerializer(EntityWorld entityWorld, EntityCatalog entityCatalog, IEnumerable<IEntityComponentSerializer> serializers)
        {
            _entityWorld = entityWorld;
            _entityCatalog = entityCatalog;

            _serializers = new Dictionary<Type, IEntityComponentSerializer>();
            foreach (var serializer in serializers)
            {
                _serializers.Add(serializer.Type, serializer);
            }
        }

        protected override EntityWorldSnapshot Serialize()
        {
            var snapshot = new EntityWorldSnapshot()
            {
                Entities = new List<EntitySnapshot>()
            };

            var entities = _entityWorld.GetAll();

            foreach (var entity in entities)
            {
                snapshot.Entities.Add(SerializeEntity(entity));
            }

            return snapshot;
        }

        protected override void Deserialize(EntityWorldSnapshot snapshot)
        {
            _entityWorld.DestroyAll();

            foreach (var entitySnapshot in snapshot.Entities)
            {
                DeserializeEntity(entitySnapshot);
            }
        }

        private EntitySnapshot SerializeEntity(Entity entity)
        {
            _components.Clear();
            entity.GetComponentsInChildren<IEntityComponent>(true, _components);
            var entityState = new Dictionary<string, string>();

            foreach (var component in _components)
            {
                if (TryGetSerializer(component, out var serializer))
                {
                    continue;
                }

                entityState.Add(serializer.Key, serializer.Serialize(component));
            }

            return new EntitySnapshot()
            {
                EntityState = entityState,
                ConfigId = entity.Name,
                EntityId = entity.Id,
                Position = entity.transform.position,
                Rotation = entity.transform.rotation,
            };
        }

        private void DeserializeEntity(EntitySnapshot snapshot)
        {
            if (!_entityCatalog.FindConfig(snapshot.ConfigId, out var config))
            {
                Debug.LogError($"Entity config {snapshot.ConfigId} not found, skipping");
                return;
            }

            var entity = _entityWorld.Spawn(config, snapshot.Position,
                snapshot.Rotation, snapshot.EntityId);

            _components.Clear();
            entity.GetComponentsInChildren<IEntityComponent>(true, _components);

            foreach (var component in _components)
            {
                if (TryGetSerializer(component, out var serializer))
                {
                    continue;
                }

                serializer.Deserialize(component, snapshot.EntityState[serializer.Key]);
            }
        }

        private bool TryGetSerializer(IEntityComponent component, out IEntityComponentSerializer serializer)
        {
            var componentType = component.GetType();
            if (!_serializers.TryGetValue(componentType, out serializer))
            {
                Debug.LogError($"No serializer for type {componentType}");
                return true;
            }

            return false;
        }
    }
}
