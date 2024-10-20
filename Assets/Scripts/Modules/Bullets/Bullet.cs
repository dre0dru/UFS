using System;
using UnityEngine;

namespace Modules.Bullets
{
    public sealed class Bullet : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        public int Damage { get; private set; }

        public event Action<Bullet, Collision2D> OnCollisionEntered;

        //отдельный CollisionComponent делать не стал, так как больше негде будет
        //переиспользовать этот компонент
        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollisionEntered?.Invoke(this, collision);
        }

        public Bullet SetDamage(int damage)
        {
            Damage = damage;
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
    }
}
