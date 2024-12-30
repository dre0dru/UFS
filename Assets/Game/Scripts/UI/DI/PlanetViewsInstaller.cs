using Game.Scripts.UI.Planets;
using Modules.Planets;
using Zenject;

namespace Game.Scripts.UI.DI
{
    public class PlanetViewsInstaller : Installer<PlanetView[], PlanetViewsInstaller>
    {
        private readonly PlanetView[] _planetViews;

        //прикольно, такое нравится в zenject, что не нужно ручками прокидывать/резолвить
        private readonly IPlanet[] _planets;

        public PlanetViewsInstaller(PlanetView[] planetViews, IPlanet[] planets)
        {
            _planetViews = planetViews;
            _planets = planets;
        }

        public override void InstallBindings()
        {
            for (var i = 0; i < _planets.Length; i++)
            {
                Container.BindInterfacesAndSelfTo<PlanetViewPresenter>().AsCached()
                    .WithArguments(_planetViews[i], _planets[i]).NonLazy();
            }
        }
    }
}
