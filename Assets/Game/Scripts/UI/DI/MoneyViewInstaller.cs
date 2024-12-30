using Game.Scripts.UI.Money;
using Modules.UI;
using Zenject;

namespace Game.Scripts.UI.DI
{
    public class MoneyViewInstaller : Installer<ParticleAnimator, MoneyViewInstaller>
    {
        private readonly ParticleAnimator _particleAnimator;

        public MoneyViewInstaller(ParticleAnimator particleAnimator)
        {
            _particleAnimator = particleAnimator;
        }

        public override void InstallBindings()
        {
            Container.Bind<MoneyView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<MoneyViewPresenter>().AsSingle().WithArguments(_particleAnimator).NonLazy();
        }
    }
}
