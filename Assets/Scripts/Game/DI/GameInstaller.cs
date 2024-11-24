using Modules;
using SnakeGame;
using UnityEngine;
using Zenject;

namespace Game.DI
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField]
        private GameUI _gameUI;

        [SerializeField]
        private Coin _coin;

        [SerializeField]
        private Transform _coinsParent;

        [SerializeField]
        private int _maxDifficulty;

        [SerializeField]
        private Modules.Snake _snake;

        [SerializeField]
        private WorldBounds _worldBounds;

        public override void InstallBindings()
        {
            Container.Bind<GameFinisher>().AsSingle();

            WorldBoundsInstaller.Install(Container, _worldBounds);
            SnakeInstaller.Install(Container, _snake);
            CoinInstaller.Install(Container, _coin, _coinsParent);
            ScoreInstaller.Install(Container);
            GameUIInstaller.Install(Container, _gameUI);
            GameInputInstaller.Install(Container);
            DifficultyInstaller.Install(Container, _maxDifficulty);
        }
    }
}
