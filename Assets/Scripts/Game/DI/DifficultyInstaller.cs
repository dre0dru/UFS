using Game.Difficulty;
using Modules;
using Zenject;

namespace Game.DI
{
    public class DifficultyInstaller: Installer<int, DifficultyInstaller>
    {
        private readonly int _maxDifficulty;

        public DifficultyInstaller(int maxDifficulty)
        {
            _maxDifficulty = maxDifficulty;
        }

        public override void InstallBindings()
        {
            Container.Bind<IDifficulty>().To<Modules.Difficulty>()
                .AsSingle().WithArguments(_maxDifficulty);

            Container.BindInterfacesTo<DifficultyController>().AsSingle();
        }
    }
}
