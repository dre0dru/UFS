using System;
using Newtonsoft.Json;

namespace Game.Scripts.App
{
    //интерфейс-маркер, чтобы можно было получить необходимые компоненты с Entity
    //не нравится такое, так как в геймплейный код залезает код сериализации получается,
    //но есть ли еще варианты как получить нужные компоненты без явного хардкода получения каждого компонента?
    //новый общий наследник не в счет, так как по сути то же самое
    //просто я чет хз как можно это реализовать без хардкода и без изменений кода компонентов
    //а что делать, если у нас компоненты от какой сторонней либы? только хардкод с GetComponent?

    //хотя в целом вроде неплохая идея пришла, но уже когда все дописал текущим способом))
    //в сериалайзеры передавать вместо компонента сам Entity. сами сериалайзеры так и останутся генериками,
    //а в абстрактном сериалайзере будем брать Entity.GetComponent<TEntityComponent> и так же передавать
    //в абстрактный Serialize метод. выглядит довольно удобно и маштабируемо, без всяких интерфейсов-маркеров
    //и изменений геймплейного кода
    public interface IEntityComponent
    {

    }

    public interface IEntityComponentSerializer
    {
        Type Type { get; }
        string Key { get; }
        string Serialize(IEntityComponent entityComponent);
        void Deserialize(IEntityComponent entityComponent, string serialized);
    }

    public abstract class EntityComponentSerializer<TSnapshot, TEntityComponent> : IEntityComponentSerializer
        where TEntityComponent : IEntityComponent
    {
        public Type Type => typeof(TEntityComponent);
        public string Key => Type.Name;

        public string Serialize(IEntityComponent entityComponent)
        {
            return JsonConvert.SerializeObject(Serialize((TEntityComponent)entityComponent));
        }

        public void Deserialize(IEntityComponent entityComponent, string serialized)
        {
            Deserialize((TEntityComponent)entityComponent, JsonConvert.DeserializeObject<TSnapshot>(serialized));
        }

        protected abstract TSnapshot Serialize(TEntityComponent entityComponent);
        protected abstract void Deserialize(TEntityComponent entityComponent, TSnapshot snapshot);
    }
}
