using Modules;
using Zenject;

namespace Game.DI
{
    public class ScoreInstaller: Installer<ScoreInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IScore>().To<Score>().AsSingle();
        }
    }
}
