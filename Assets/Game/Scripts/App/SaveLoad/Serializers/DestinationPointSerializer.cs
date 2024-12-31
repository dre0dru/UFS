using System;
using SampleGame.Common;
using SampleGame.Gameplay;
using UnityEngine;

namespace Game.Scripts.App
{
    [Serializable]
    public struct DestinationPointSnapshot
    {
        public SerializedVector3 Value;
    }

    public class DestinationPointSerializer : EntityComponentSerializer<DestinationPointSnapshot, DestinationPoint>
    {
        protected override DestinationPointSnapshot Serialize(DestinationPoint entityComponent)
        {
            return new DestinationPointSnapshot
            {
                Value = entityComponent.Value
            };
        }

        protected override void Deserialize(DestinationPoint entityComponent, DestinationPointSnapshot snapshot)
        {
            entityComponent.Value = snapshot.Value;
        }
    }
}
