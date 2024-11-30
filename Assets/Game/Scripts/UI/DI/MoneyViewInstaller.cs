using Game.Scripts.UI.Money;
using Zenject;

namespace Game.Scripts.UI.DI
{
    public class MoneyViewInstaller : Installer<MoneyViewInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<MoneyView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<MoneyViewPresenter>().AsSingle().NonLazy();
        }
    }
}
