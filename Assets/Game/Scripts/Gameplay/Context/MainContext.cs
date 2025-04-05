using Atomic.Contexts;

namespace Game.Gameplay
{
    public interface IMainContext : IContext
    {
    }
    
    public class MainContext: SingletonSceneContext<MainContext>, IMainContext
    {
    }
}
