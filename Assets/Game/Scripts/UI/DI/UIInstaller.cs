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
        private ParticleAnimator _particleAnimator;

        public override void InstallBindings()
        {
            PlanetViewsInstaller.Install(Container, _planetViews);
            MoneyViewInstaller.Install(Container, _particleAnimator);
            PlanetPopupInstaller.Install(Container);
        }
    }
}
