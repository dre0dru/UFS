using System.Collections.Generic;
using Newtonsoft.Json;

namespace Game.Scripts.App
{
    public interface IGameSerializer
    {
        public void Serialize(IDictionary<string, string> state);
        public void Deserialize(IDictionary<string, string> state);
    }

    //предпочел не делать генерик TService, где нужно ручками пропишу нужные сервисы
    //не нравится, когда нужных сервисов становится 2-3, куча генериков
    public abstract class GameSerializer<TSnapshot> : IGameSerializer
    {
        protected virtual string Key => typeof(TSnapshot).Name;

        public void Serialize(IDictionary<string, string> state)
        {
            var snapshot = Serialize();
            state[Key] = JsonConvert.SerializeObject(snapshot);

        }

        public void Deserialize(IDictionary<string, string> state)
        {
            if (!state.TryGetValue(Key, out var serialized))
            {
                return;
            }

            var snapshot = JsonConvert.DeserializeObject<TSnapshot>(serialized);
            Deserialize(snapshot);
        }

        protected abstract TSnapshot Serialize();
        protected abstract void Deserialize(TSnapshot snapshot);
    }
}
