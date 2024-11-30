using Modules.Planets;
using Zenject;

namespace Game.Scripts.UI.Popups
{
    public class PlanetPopupOpener
    {
        private readonly PlanetPopup _planetPopup;
        private readonly PlanetPopupPresenter.Factory _planetPopupPresenterFactory;

        public PlanetPopupOpener(PlanetPopup planetPopup, PlanetPopupPresenter.Factory planetPopupPresenterFactory)
        {
            _planetPopup = planetPopup;
            _planetPopupPresenterFactory = planetPopupPresenterFactory;
        }

        public void OpenFor(IPlanet planet)
        {
            _planetPopup.Open(_planetPopupPresenterFactory.Create(planet));
        }
    }
}
