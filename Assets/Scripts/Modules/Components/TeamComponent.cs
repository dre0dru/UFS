using JetBrains.Annotations;
using UnityEngine;

namespace Modules.Components
{
    public enum Team
    {
        Player = 0,
        Enemy = 1
    }

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
