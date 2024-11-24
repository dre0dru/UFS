using Game.GameInput;
using Zenject;

namespace Game.DI
{
    public class GameInputInstaller : Installer<GameInputInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IGameInput>().To<LegacyGameInput>().AsSingle();
        }
    }
}
