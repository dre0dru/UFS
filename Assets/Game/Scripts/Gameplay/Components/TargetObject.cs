using Game.Scripts.App;
using Modules.Entities;
using UnityEngine;

namespace SampleGame.Gameplay
{
    //Can be extended
    public sealed class TargetObject : MonoBehaviour, IEntityComponent
    {
        ///Variable
        [field: SerializeField]
        public Entity Value { get; set; }
    }
}
