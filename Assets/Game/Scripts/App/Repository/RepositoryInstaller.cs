using UnityEngine;
using Zenject;

namespace Game.Scripts.App
{
    [CreateAssetMenu(
        fileName = "RepositoryInstaller",
        menuName = "Zenject/App/New RepositoryInstaller"
    )]
    public sealed class RepositoryInstaller : ScriptableObjectInstaller
    {
        [SerializeField]
        private string _aesPassword = "123";

        [SerializeField]
        private byte[] _aesSalt = { 0x52, 0x41, 0x16, 0x79, 0x86, 0x64, 0x97, 0x22 };

        [SerializeField]
        private string _serverUrl = "http://127.0.0.1:8888";

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GameRepository>().AsSingle();
            Container.Bind<AesEncryptionService>().AsSingle().WithArguments(_aesPassword, _aesSalt);
            Container.Bind<RemoteSavesClient>().AsSingle().WithArguments(_serverUrl);
            Container.Bind<LocalStorage>().AsSingle().WithArguments(Application.persistentDataPath);
        }
    }
}
