using System;
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
        private const string SAVE_TIME_KEY = "SaveTime";
        private static readonly DateTime OriginTime = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private const string VersionKey = nameof(VersionKey);

        private readonly RemoteSavesClient _remoteSavesClient;
        private readonly AesEncryptionService _encryptionService;
        private readonly LocalStorage _localStorage;

        public GameRepository(RemoteSavesClient remoteSavesClient, AesEncryptionService encryptionService,
            LocalStorage localStorage)
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

            var saveTime = (DateTime.UtcNow - OriginTime).Ticks.ToString();
            gameState[SAVE_TIME_KEY] = saveTime;

            var nextVersion = GetNextVersion();
            _localStorage.Save(encrypted, nextVersion);
            SetVersion(nextVersion);

            await _remoteSavesClient.UploadSave(encrypted, nextVersion);

            return (true, nextVersion);
        }

        public async UniTask<(bool isSuccess, IDictionary<string, string> result)> GetState(int version = 1)
        {
            var remoteEncrypted = await _remoteSavesClient.DownloadSave(version);

            _localStorage.TryLoadSave(version, out var localEncrypted);

            if (string.IsNullOrEmpty(localEncrypted) && string.IsNullOrEmpty(remoteEncrypted))
            {
                return (false, null);
            }

            var remote = Parse(Decrypt(remoteEncrypted));
            var local = Parse(Decrypt(localEncrypted));

            var remoteTime = GetTimestamp(remote);
            var localTime = GetTimestamp(local);

            return (true, remoteTime > localTime ? remote : local);
        }

        private int GetNextVersion()
        {
            return PlayerPrefs.GetInt(VersionKey, 0) + 1;
        }

        private void SetVersion(int version)
        {
            PlayerPrefs.SetInt(VersionKey, version);
        }

        private string Decrypt(string encrypted)
        {
            if (string.IsNullOrEmpty(encrypted))
            {
                return null;
            }

            return _encryptionService.Decrypt(encrypted);
        }

        private IDictionary<string, string> Parse(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }

        private static long GetTimestamp(IDictionary<string, string> gameState)
        {
            if (gameState == null)
            {
                return long.MinValue;
            }

            if (gameState.TryGetValue(SAVE_TIME_KEY, out var value) &&
                long.TryParse(value, out var timestamp))
            {
                return timestamp;
            }

            return long.MinValue;
        }
    }
}
