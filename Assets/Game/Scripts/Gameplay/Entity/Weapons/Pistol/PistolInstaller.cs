using Atomic.Elements;
using Atomic.Entities;
using Game.Gameplay;
using Modules.Gameplay;
using UnityEngine;

namespace Game.Gameplay
{
    //TODO у кулаков тоже свой отдельный инсталлер, посмотреть, может что-то можно
    //в общий инсталлер вынести
    public class PistolInstaller : SceneEntityInstaller
    {
        [SerializeField]
        private SceneEntity _bulletPrefab;

        [SerializeField]
        private Ammo _ammo = new(10);

        [SerializeField]
        private float _spreadAngle = 0.25f;
        
        public override void Install(IEntity entity)
        {
            entity.AddRangedTag();

            //TODO не забывать про экстеншены вида AsXXX
            entity.AddSpreadAngle(_spreadAngle.AsСonst());

            entity.AddAttackAction(new BaseAction(
                //TODO вынести в бехавиор, чтобы не было такого инлайн/незаметного использования синглтона?
                () => PistolUseCase.Fire(MainContext.Instance, entity))
            );

            entity.AddAmmo(_ammo);
            entity.AddProjectilePrefab(_bulletPrefab);
            entity.GetAttackCondition().Append(() => entity.GetAmmo().Exists());
        }
    }
}
