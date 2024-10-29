using System;
using Game.Components;
using Modules.Common;
using UnityEngine;

namespace Game.Bullets
{
    public sealed class Bullet : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        [SerializeField]
        private TeamComponent _teamComponent;

        private int _damage;

        public event Action<Bullet> OnDestroyed;

        //отдельный CollisionComponent делать не стал, так как больше негде будет
        //переиспользовать этот компонент
        private void OnCollisionEnter2D(Collision2D collision)
        {
            DealDamage(collision.gameObject);
            OnDestroyed?.Invoke(this);
        }

        public Bullet SetDamage(int damage)
        {
            _damage = damage;
            return this;
        }

        public Bullet SetVelocity(Vector2 velocity)
        {
            _rigidbody.velocity = velocity;
            return this;
        }

        public Bullet SetPhysicsLayer(int physicsLayer)
        {
            gameObject.layer = physicsLayer;
            return this;
        }

        public Bullet SetPosition(Vector3 position)
        {
            transform.position = position;
            return this;
        }

        public Bullet SetColor(Color color)
        {
            _spriteRenderer.color = color;
            return this;
        }

        public Bullet SetTeam(Team team)
        {
            _teamComponent.Team = team;
            return this;
        }

        private void DealDamage(GameObject other)
        {
            if (!other.TryGetComponent(out TeamComponent otherTeam))
            {
                return;
            }

            if (_teamComponent == otherTeam)
            {
                return;
            }

            if (other.TryGetComponent(out HealthComponent healthComponent))
            {
                healthComponent.TakeDamage(_damage);
            }
        }
    }
}
