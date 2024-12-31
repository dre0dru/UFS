using System;
using SampleGame.Gameplay;

namespace Game.Scripts.App
{
    [Serializable]
    public struct CountdownSnapshot
    {
        public float Current;
    }

    public class CountdownSerializer : EntityComponentSerializer<CountdownSnapshot, Countdown>
    {
        protected override CountdownSnapshot Serialize(Countdown entityComponent)
        {
            return new CountdownSnapshot
            {
                Current = entityComponent.Current
            };
        }

        protected override void Deserialize(Countdown entityComponent, CountdownSnapshot snapshot)
        {
            entityComponent.Current = snapshot.Current;
        }
    }
}
