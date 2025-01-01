using System;
using Game.Scripts.Components;
using Game.Scripts.Objects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Controllers
{
    public class CharacterPushController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _character;

        [ShowInInspector]
        private PushComponent _pushComponent;

        private void Awake()
        {
            _pushComponent = _character.GetComponent<PushComponent>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _pushComponent.Push();
            }
        }
    }
}
