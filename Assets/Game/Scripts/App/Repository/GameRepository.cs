using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Game.Scripts.App.Encryption;
using Game.Scripts.App.Network;
using Newtonsoft.Json;
using UnityEngine;

namespace Game.Scripts.App
{
    public class GameRepository : IGameRepository
    {
        private const string VersionKey = nameof(VersionKey);

        private readonly RemoteSavesClient _remoteSavesClient;
        private readonly AesEncryptionService _encryptionService;
        private readonly LocalStorage _localStorage;

        public GameRepository(RemoteSavesClient remoteSavesClient, AesEncryptionService encryptionService, LocalStorage localStorage)
        {
            _remoteSavesClient = remoteSavesClient;
            _encryptionService = encryptionService;
            _localStorage = localStorage;
        }

        public async UniTask<(bool isSuccess, int version)> SetState(IDictionary<string, string> gameState)
        {
            var json = JsonConvert.SerializeObject(gameState);

            Debug.Log($"Debug state:\n {json}");

            var encrypted = _encryptionService.Encrypt(json);

            var nextVersion = GetNextVersion();
            _localStorage.Save(encrypted, nextVersion);
            SetVersion(nextVersion);

            await _remoteSavesClient.UploadSave(encrypted, nextVersion);

            return (true, nextVersion);
        }

        public async UniTask<(bool isSuccess, IDictionary<string, string> result)> GetState(int version = 1)
        {
            var (isSuccess, encrypted) = await _remoteSavesClient.DownloadSave(version);

            if (!isSuccess && _localStorage.TryLoadSave(version, out encrypted))
            {
                isSuccess = true;
            }

            var json = _encryptionService.Decrypt(encrypted);

            Debug.Log($"Debug state:\n {json}");

            return (isSuccess, JsonConvert.DeserializeObject<Dictionary<string, string>>(json));
        }

        private int GetNextVersion()
        {
            return PlayerPrefs.GetInt(VersionKey, 0) + 1;
        }

        private void SetVersion(int version)
        {
            PlayerPrefs.SetInt(VersionKey, version);
        }
    }
}
