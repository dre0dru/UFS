using System;
using SampleGame.Gameplay;

namespace Game.Scripts.App
{
    [Serializable]
    public struct HealthSnapshot
    {
        public int Current;
    }

    public class HealthSerializer : EntityComponentSerializer<HealthSnapshot, Health>
    {
        protected override HealthSnapshot Serialize(Health entityComponent)
        {
            return new HealthSnapshot
            {
                Current = entityComponent.Current
            };
        }

        protected override void Deserialize(Health entityComponent, HealthSnapshot snapshot)
        {
            entityComponent.Current = snapshot.Current;
        }
    }
}
