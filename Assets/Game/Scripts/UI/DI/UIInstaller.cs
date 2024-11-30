using Game.Scripts.UI.Animations;
using Game.Scripts.UI.Planets;
using Modules.UI;
using UnityEngine;
using Zenject;

namespace Game.Scripts.UI.DI
{
    public class UIInstaller: MonoInstaller
    {
        [SerializeField]
        private PlanetView[] _planetViews;

        [SerializeField]
        private Transform _moneyAnimationTarget;

        [SerializeField]
        private ParticleAnimator _particleAnimator;

        public override void InstallBindings()
        {
            Container.Bind<IMoneyCollectAnimationService>().To<MoneyCollectAnimationService>()
                .AsSingle().WithArguments(_particleAnimator, _moneyAnimationTarget);

            PlanetViewsInstaller.Install(Container, _planetViews);
            MoneyViewInstaller.Install(Container);
            PlanetPopupInstaller.Install(Container);
        }
    }
}
