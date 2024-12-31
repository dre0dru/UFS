using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Game.Scripts.App.Encryption;
using Game.Scripts.App.Network;
using Newtonsoft.Json;
using UnityEngine;

namespace Game.Scripts.App
{
    public class RemoteGameRepository : IGameRepository
    {
        private const string VersionKey = nameof(VersionKey);

        private readonly RemoteSavesClient _remoteSavesClient;
        private readonly AesEncryptionService _encryptionService;

        public RemoteGameRepository(RemoteSavesClient remoteSavesClient, AesEncryptionService encryptionService)
        {
            _remoteSavesClient = remoteSavesClient;
            _encryptionService = encryptionService;
        }

        public async UniTask<(bool isSuccess, int version)> SetState(IDictionary<string, string> gameState)
        {
            var json = JsonConvert.SerializeObject(gameState);

            Debug.Log($"Debug state:\n {json}");

            var encrypted = _encryptionService.Encrypt(json);

            var nextVersion = GetNextVersion();
            var isSuccess = await _remoteSavesClient.UploadSave(encrypted, nextVersion);

            if (isSuccess)
            {
                SetVersion(nextVersion);
            }

            return (isSuccess, nextVersion);
        }

        public async UniTask<(bool isSuccess, IDictionary<string, string> result)> GetState(int version = 1)
        {
            var (isSuccess, encrypted) = await _remoteSavesClient.DownloadSave(version);

            if (!isSuccess)
            {
                return (false, null);
            }

            var json = _encryptionService.Decrypt(encrypted);

            Debug.Log($"Debug state:\n {json}");

            return (true, JsonConvert.DeserializeObject<Dictionary<string, string>>(json));
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
