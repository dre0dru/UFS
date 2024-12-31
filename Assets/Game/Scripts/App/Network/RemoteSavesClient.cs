using System;
using System.Text;
using Cysharp.Threading.Tasks;
using UnityEngine.Networking;

namespace Game.Scripts.App.Network
{
    public class RemoteSavesClient
    {
        private readonly string _url;

        public RemoteSavesClient(string url)
        {
            _url = url;
        }

        public async UniTask<bool> UploadSave(string gameState, int version)
        {
            string url = $"{_url}/save?version={version}";

            using var request = new UnityWebRequest(url, "PUT");
            request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(gameState));
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "text/plain");

            await request.SendWebRequest();

            return request.result == UnityWebRequest.Result.Success;
        }

        public async UniTask<(bool isSuccess, string result)> DownloadSave(int version)
        {
            var url = $"{_url}/load?version={version}";

            using var request = UnityWebRequest.Get(url);

            await request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                return (true, request.downloadHandler.text);
            }

            return (false, string.Empty);
        }
    }
}
