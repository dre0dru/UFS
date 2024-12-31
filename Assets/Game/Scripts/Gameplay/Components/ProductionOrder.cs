using System.Collections.Generic;
using Game.Scripts.App;
using Modules.Entities;
using UnityEngine;

namespace SampleGame.Gameplay
{
    //Can be extended
    public sealed class ProductionOrder : MonoBehaviour, IEntityComponent
    {
        ///Variable
        [SerializeField]
        private List<EntityConfig> _queue;
        
        public IReadOnlyList<EntityConfig> Queue
        {
            get { return _queue; }
            set { _queue = new List<EntityConfig>(value); }
        }
    }
}
