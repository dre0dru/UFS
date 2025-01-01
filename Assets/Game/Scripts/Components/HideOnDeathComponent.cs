using UnityEngine;

namespace Game.Scripts.Components
{
    public class HideOnDeathComponent : MonoBehaviour
    {
        [SerializeField]
        private HealthComponent _healthComponent;

        [SerializeField]
        private GameObject _root;

        private void Awake()
        {
            _healthComponent.Died += Hide;
        }

        private void OnDestroy()
        {
            _healthComponent.Died -= Hide;
        }

        private void Hide()
        {
            _root.SetActive(false);
        }
    }
}
