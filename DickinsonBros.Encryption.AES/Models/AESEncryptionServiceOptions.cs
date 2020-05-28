using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace DickinsonBros.Encryption.AES.Models
{
    [ExcludeFromCodeCoverage]
    public abstract class AESEncryptionServiceOptions
    {
        public string Key { set; get; }
        public string InitializationVector { set; get; }
    }
}
