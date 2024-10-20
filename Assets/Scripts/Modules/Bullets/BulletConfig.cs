using Modules.Common;
using Modules.Components;
using UnityEngine;

namespace Modules.Bullets
{
    [CreateAssetMenu(
        fileName = "BulletConfig",
        menuName = "Bullets/New BulletConfig"
    )]
    public sealed class BulletConfig : ScriptableObject
    {
        [SerializeField]
        private PhysicsLayer _physicsLayer;

        [SerializeField]
        private Color _color;

        [SerializeField]
        private int _damage;

        [SerializeField]
        private float _speed;

        [SerializeField]
        private Team _team;

        public PhysicsLayer PhysicsLayer => _physicsLayer;

        public Color Color => _color;

        public int Damage => _damage;

        public float Speed => _speed;

        public Team Team => _team;
    }
}
