using SnakeGame;
using Zenject;

namespace Game.DI
{
    public class WorldBoundsInstaller : Installer<WorldBounds, WorldBoundsInstaller>
    {
        private readonly WorldBounds _worldBounds;

        public WorldBoundsInstaller(WorldBounds worldBounds)
        {
            _worldBounds = worldBounds;
        }

        public override void InstallBindings()
        {
            Container.Bind<IWorldBounds>().FromInstance(_worldBounds).AsSingle();
        }
    }
}
