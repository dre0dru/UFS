using System;
using UnityEngine;

namespace Game.Scripts.Components
{
    //фигово работает, никогда не делал платформеры
    public class MoveWithPlatformComponent : MonoBehaviour
    {
        [SerializeField]
        private string _platformTag = "Platform";

        [SerializeField]
        private GroundCheckComponent _groundCheckComponent;

        [SerializeField]
        private Rigidbody2D _rigidbody;

        private void FixedUpdate()
        {
            if (_groundCheckComponent.IsGrounded && _groundCheckComponent.GroundTransform.CompareTag(_platformTag) &&
                _groundCheckComponent.GroundTransform.TryGetComponent<Rigidbody2D>(out var platformRigidbody))
            {
                _rigidbody.velocity = platformRigidbody.velocity;
            }
        }
    }
}
