using System;
using System.Collections.Generic;
using Modules.Entities;
using SampleGame.Gameplay;

namespace Game.Scripts.App
{
    [Serializable]
    public struct ProductionOrderSnapshot
    {
        public List<string> Queue;
    }

    public class ProductionOrderSerializer: EntityComponentSerializer<ProductionOrderSnapshot, ProductionOrder>
    {
        private readonly EntityCatalog _entityCatalog;

        public ProductionOrderSerializer(EntityCatalog entityCatalog)
        {
            _entityCatalog = entityCatalog;
        }

        protected override ProductionOrderSnapshot Serialize(ProductionOrder entityComponent)
        {
            var snapshot = new ProductionOrderSnapshot
            {
                Queue = new List<string>()
            };

            foreach (var config in entityComponent.Queue)
            {
                snapshot.Queue.Add(config.Name);
            }

            return snapshot;
        }

        protected override void Deserialize(ProductionOrder entityComponent, ProductionOrderSnapshot snapshot)
        {
            var queue = new List<EntityConfig>();

            foreach (var configName in snapshot.Queue)
            {
                if (_entityCatalog.FindConfig(configName, out var config))
                {
                    queue.Add(config);
                }
            }

            entityComponent.Queue = queue;
        }
    }
}
