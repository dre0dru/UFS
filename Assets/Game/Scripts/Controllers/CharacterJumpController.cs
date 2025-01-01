using Game.Scripts.Components;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Controllers
{
    public class CharacterJumpController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _character;

        [ShowInInspector]
        private JumpComponent _jumpComponent;

        private void Awake()
        {
            _jumpComponent = _character.GetComponent<JumpComponent>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _jumpComponent.Jump();
            }
        }
    }
}
