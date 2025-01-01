using System.IO;

namespace Game.Scripts.App
{
    public class LocalStorage
    {
        private readonly string _savesFolderPath;

        public LocalStorage(string savesFolderPath)
        {
            _savesFolderPath = savesFolderPath;
        }

        public void Save(string gameState, int version)
        {
            CreateDirectoryIfNotExists();

            var filePath = GetFilePath(version);

            File.WriteAllText(filePath, gameState);
        }

        public bool TryLoadSave(int version, out string gameState)
        {
            gameState = default;
            var filePath = GetFilePath(version);

            if (!File.Exists(filePath))
            {
                return false;
            }

            gameState = File.ReadAllText(filePath);
            return !string.IsNullOrEmpty(gameState);
        }

        private string GetFilePath(int version)
        {
            return Path.Combine(_savesFolderPath, $"GameState_{version}.save");
        }

        private void CreateDirectoryIfNotExists()
        {
            if (!Directory.Exists(_savesFolderPath))
            {
                Directory.CreateDirectory(_savesFolderPath);
            }
        }
    }
}
