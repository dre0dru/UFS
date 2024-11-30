using Game.Scripts.UI.Popups;
using Modules.Planets;
using Zenject;

namespace Game.Scripts.UI.DI
{
    public class PlanetPopupInstaller: Installer<PlanetPopupInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindFactory<IPlanet, PlanetPopupPresenter, PlanetPopupPresenter.Factory>();
            Container.Bind<PlanetPopup>().FromComponentInHierarchy(true).AsSingle();
            Container.Bind<PlanetPopupOpener>().AsSingle();
        }
    }
}
