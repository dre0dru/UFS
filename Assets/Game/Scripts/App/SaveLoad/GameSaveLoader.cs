using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.Scripts.App
{
    public class GameSaveLoader
    {
        private readonly IGameRepository _repository;
        private readonly IEnumerable<IGameSerializer> _serializers;

        public GameSaveLoader(IGameRepository repository, IEnumerable<IGameSerializer> serializers)
        {
            _repository = repository;
            _serializers = serializers;
        }

        public void Save(Action<bool, int> callback)
        {
            SaveAsync(callback).Forget();
        }

        public void Load(int version, Action<bool, int> callback)
        {
            LoadAsync(version, callback).Forget();
        }

        private async UniTaskVoid SaveAsync(Action<bool, int> callback)
        {
            var gameState = new Dictionary<string, string>();

            foreach (var serializer in _serializers)
            {
                serializer.Serialize(gameState);
            }

            var (isSuccess, version) = await _repository.SetState(gameState);

            callback?.Invoke(isSuccess, version);
        }

        private async UniTaskVoid LoadAsync(int version, Action<bool, int> callback)
        {
            var (isSuccess, gameState) = await _repository.GetState(version);

            if (isSuccess)
            {
                foreach (var serializer in _serializers)
                {
                    serializer.Deserialize(gameState);
                }
            }

            callback?.Invoke(isSuccess, version);
        }
    }
}
