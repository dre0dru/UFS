using Game.Scripts.App;
using SampleGame.Common;
using UnityEngine;

namespace SampleGame.Gameplay
{
    //Can be extended
    public sealed class Team : MonoBehaviour, IEntityComponent
    {
        ///Variable
        [field: SerializeField]
        public TeamType Type { get; set; }
    }
}
