using Game.Snake;
using Modules;
using Zenject;

namespace Game.DI
{
    public class SnakeInstaller: Installer<Modules.Snake, SnakeInstaller>
    {
        private readonly ISnake _snake;

        public SnakeInstaller(ISnake snake)
        {
            _snake = snake;
        }

        public override void InstallBindings()
        {
            Container.Bind<ISnake>().FromInstance(_snake).AsSingle();

            Container.BindInterfacesAndSelfTo<SnakeController>().AsSingle();
            Container.BindInterfacesAndSelfTo<SnakeSelfCollisionObserver>().AsSingle();
            Container.BindInterfacesAndSelfTo<SnakeCoinCollisionObserver>().AsSingle();
            Container.BindInterfacesAndSelfTo<SnakeBoundsCollisionObserver>().AsSingle();
            Container.BindInterfacesAndSelfTo<SnakeGameFinishedObserver>().AsSingle();
            Container.BindInterfacesAndSelfTo<SnakeDifficultyObserver>().AsSingle();
        }
    }
}
