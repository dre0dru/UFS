using System;
using Game.Scripts.Components;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Controllers
{
    public class CharacterMovementController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _character;

        [ShowInInspector]
        private MovementComponent _movementComponent;

        private void Awake()
        {
            _movementComponent = _character.GetComponent<MovementComponent>();
        }

        private void Update()
        {
            var movementDirection = Vector2.zero;

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                movementDirection += Vector2.left;
            }

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                movementDirection += Vector2.right;
            }

            _movementComponent.SetMovementDirection(movementDirection);
        }
    }
}
