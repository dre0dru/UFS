using System;
using Modules.Bullets;
using Modules.Components;
using Modules.GameInput;
using UnityEngine;

namespace Modules.Players
{
    public sealed class PlayerShootingController : MonoBehaviour
    {
        [SerializeField]
        private PlayerService _playerService;

        [SerializeField]
        private BulletSystem _bulletSystem;

        [SerializeField]
        private BulletConfig _bulletConfig;

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
            _bulletSystem.ShootBullet(new BulletArgs
            {
                BulletConfig = _bulletConfig,
                Position = _weaponComponent.Position,
                Direction = _weaponComponent.Rotation * Vector3.up
            });
        }
    }
}
