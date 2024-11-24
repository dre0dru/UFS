using Game.UI;
using SnakeGame;
using Zenject;

namespace Game.DI
{
    public class GameUIInstaller : Installer<GameUI, GameUIInstaller>
    {
        private readonly GameUI _gameUI;

        public GameUIInstaller(GameUI gameUI)
        {
            _gameUI = gameUI;
        }

        public override void InstallBindings()
        {
            Container.Bind<IGameUI>().FromInstance(_gameUI).AsSingle();
            Container.BindInterfacesAndSelfTo<UIDifficultyObserver>().AsSingle();
            Container.BindInterfacesAndSelfTo<UIScoreObserver>().AsSingle();
            Container.BindInterfacesAndSelfTo<UIGameFinishedObserver>().AsSingle();
        }
    }
}
