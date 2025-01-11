using Modules.Ecryption;

namespace Game.Scripts.App
{
    public class AesEncryptionService
    {
        private readonly string _password;
        private readonly byte[] _salt;

        public AesEncryptionService(string password, byte[] salt)
        {
            _password = password;
            _salt = salt;
        }

        public string Encrypt(string unencrypted)
        {
            return AesEncryptor.Encrypt(unencrypted, _password, _salt);
        }

        public string Decrypt(string encrypted)
        {
            return AesEncryptor.Decrypt(encrypted, _password, _salt);
        }
    }
}
