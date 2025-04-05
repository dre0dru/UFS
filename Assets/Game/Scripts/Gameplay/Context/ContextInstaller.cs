using Atomic.Contexts;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class ContextInstaller : SceneContextInstaller<IMainContext>
    {
        [SerializeField]
        private SceneEntity _playerCharacter;

        protected override void Install(IMainContext context)
        {
            context.AddPlayer(_playerCharacter);
            context.AddScore(new ReactiveInt());
        }
    }
}
