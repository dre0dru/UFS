using UnityEngine;
using Zenject;

namespace Game.Scripts.App
{
    [CreateAssetMenu(
        fileName = "SaveLoadInstaller",
        menuName = "Zenject/App/New SaveLoadInstaller"
    )]
    public sealed class SaveLoadInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameSaveLoader>().AsSingle();
            Container.BindInterfacesTo<EntitiesSerializer>().AsSingle();

            Container.BindInterfacesTo<ProductionOrderSerializer>().AsSingle();
            Container.BindInterfacesTo<HealthSerializer>().AsSingle();
            Container.BindInterfacesTo<ResourceBagSerializer>().AsSingle();
            Container.BindInterfacesTo<DestinationPointSerializer>().AsSingle();
            Container.BindInterfacesTo<TeamSerializer>().AsSingle();
            Container.BindInterfacesTo<CountdownSerializer>().AsSingle();
            Container.BindInterfacesTo<TargetObjectSerializer>().AsSingle();
        }
    }
}
