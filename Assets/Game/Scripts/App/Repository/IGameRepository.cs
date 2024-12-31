using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Game.Scripts.App
{
    public interface IGameRepository
    {
        UniTask<(bool isSuccess, int version)> SetState(IDictionary<string, string> gameState);
        UniTask<(bool isSuccess, IDictionary<string, string> result)> GetState(int version = 1);
    }
}
