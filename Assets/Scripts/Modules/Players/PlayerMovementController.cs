using System;
using Modules.Components;
using Modules.GameInput;
using UnityEngine;

namespace Modules.Players
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField]
        private PlayerService _playerService;

        [SerializeField]
        private MovementInput _movementInput;

        private MoveComponent _moveComponent;

        private void Start()
        {
            _moveComponent = _playerService.Player.GetComponent<MoveComponent>();
        }

        private void Update()
        {
            MoveHorizontally();
        }

        private void MoveHorizontally()
        {
            _moveComponent.MoveByRigidbodyVelocity(new Vector2(_movementInput.HorizontalInput, 0) * Time.fixedDeltaTime);
        }
    }
}
