using System;
using Newtonsoft.Json;
using SampleGame.Gameplay;

namespace Game.Scripts.App
{
    public interface IEntityComponentSerializer
    {
        Type Type { get; }
        string Key { get; }
        string Serialize(IEntityComponent entityComponent);
        void Deserialize(IEntityComponent entityComponent, string serialized);
    }

    public abstract class EntityComponentSerializer<TSnapshot, TEntityComponent> : IEntityComponentSerializer
        where TEntityComponent : IEntityComponent
    {
        public Type Type => typeof(TEntityComponent);
        public string Key => Type.Name;

        public string Serialize(IEntityComponent entityComponent)
        {
            return JsonConvert.SerializeObject(Serialize((TEntityComponent)entityComponent));
        }

        public void Deserialize(IEntityComponent entityComponent, string serialized)
        {
            Deserialize((TEntityComponent)entityComponent, JsonConvert.DeserializeObject<TSnapshot>(serialized));
        }

        protected abstract TSnapshot Serialize(TEntityComponent entityComponent);
        protected abstract void Deserialize(TEntityComponent entityComponent, TSnapshot snapshot);
    }
}
