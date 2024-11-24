using Game.Coins;
using Modules;
using UnityEngine;
using Zenject;

namespace Game.DI
{
    public class CoinInstaller : Installer<Coin, Transform, CoinInstaller>
    {
        private readonly Coin _coin;
        private readonly Transform _transform;

        public CoinInstaller(Coin coin, Transform transform)
        {
            _coin = coin;
            _transform = transform;
        }

        public override void InstallBindings()
        {
            Container.BindMemoryPool<Coin, CoinsPool>()
                .FromComponentInNewPrefab(_coin)
                .UnderTransform(_transform);

            Container.BindInterfacesAndSelfTo<CoinsDifficultyObserver>().AsSingle();
            Container.Bind<CoinsSpawner>().AsSingle();
        }
    }
}
