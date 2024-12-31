using System;
using Game.Scripts.App;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class ControlsPresenter : IControlsPresenter
    {
        private readonly GameSaveLoader _gameSaveLoader;

        public ControlsPresenter(GameSaveLoader gameSaveLoader)
        {
            _gameSaveLoader = gameSaveLoader;
        }

        public void Save(Action<bool, int> callback)
        {
            _gameSaveLoader.Save(callback);
        }

        public void Load(string versionText, Action<bool, int> callback)
        {
            if (!int.TryParse(versionText, out var version))
            {
                Debug.LogError($"Invalid version number: {versionText}");
                callback?.Invoke(false, -1);
                return;
            }

            _gameSaveLoader.Load(version, callback);
        }
    }
}
