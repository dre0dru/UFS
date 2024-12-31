using System;
using SampleGame.Common;
using SampleGame.Gameplay;

namespace Game.Scripts.App
{
    [Serializable]
    public struct TeamSnapshot
    {
        public TeamType Type;
    }

    public class TeamSerializer: EntityComponentSerializer<TeamSnapshot, Team>
    {
        protected override TeamSnapshot Serialize(Team entityComponent)
        {
            return new TeamSnapshot
            {
                Type = entityComponent.Type
            };
        }

        protected override void Deserialize(Team entityComponent, TeamSnapshot snapshot)
        {
            entityComponent.Type = snapshot.Type;
        }
    }
}
