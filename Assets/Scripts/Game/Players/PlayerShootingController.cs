using Game.Components;
using Modules.GameInput;
using UnityEngine;

namespace Game.Players
{
    public sealed class PlayerShootingController : MonoBehaviour
    {
        [SerializeField]
        private PlayerService _playerService;

        [SerializeField]
        private FireInput _fireInput;

        private WeaponComponent _weaponComponent;

        private void Start()
        {
            _weaponComponent = _playerService.Player.GetComponent<WeaponComponent>();
        }

        private void Update()
        {
            Shoot();
        }

        private void Shoot()
        {
            if (_fireInput.IsShootInputPressed)
            {
                ShootBullet();
            }
        }

        private void ShootBullet()
        {
            _weaponComponent.Shoot(Vector2.up);
        }
    }
}
