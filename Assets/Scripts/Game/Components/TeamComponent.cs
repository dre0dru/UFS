using JetBrains.Annotations;
using Modules.Common;
using UnityEngine;

namespace Game.Components
{
    public class TeamComponent : MonoBehaviour
    {
        [SerializeField]
        private Team _team;

        public Team Team
        {
            get => _team;
            set => _team = value;
        }

        public static bool operator !=([NotNull] TeamComponent lhs, [NotNull] TeamComponent rhs)
        {
            return lhs.Team != rhs.Team;
        }

        public static bool operator ==([NotNull] TeamComponent lhs, [NotNull] TeamComponent rhs)
        {
            return lhs.Team == rhs.Team;
        }
    }
}
