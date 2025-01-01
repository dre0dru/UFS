using System;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class CollisionSensorComponent : MonoBehaviour
    {
        public event Action<Collision2D> CollisionEntered;
        public event Action<Collision2D> CollisionStayed;
        public event Action<Collision2D> CollisionExited;

        private void OnCollisionEnter2D(Collision2D other)
        {
            CollisionEntered?.Invoke(other);
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            CollisionStayed?.Invoke(other);
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            CollisionExited?.Invoke(other);
        }
    }
}
