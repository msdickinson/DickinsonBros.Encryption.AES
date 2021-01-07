using System.Diagnostics.CodeAnalysis;

namespace DickinsonBros.Encryption.AES.Models
{
    [ExcludeFromCodeCoverage]
    public abstract class AESEncryptionServiceOptions
    {
        public string Key { set; get; }
        public string InitializationVector { set; get; }
    }
}
