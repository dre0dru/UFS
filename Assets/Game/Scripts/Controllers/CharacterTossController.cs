using System;
using Game.Scripts.Components;
using Game.Scripts.Objects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Controllers
{
    public class CharacterTossController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _character;

        [ShowInInspector]
        private TossComponent _tossComponent;

        private void Awake()
        {
            _tossComponent = _character.GetComponent<TossComponent>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                _tossComponent.Toss();
            }
        }
    }
}
