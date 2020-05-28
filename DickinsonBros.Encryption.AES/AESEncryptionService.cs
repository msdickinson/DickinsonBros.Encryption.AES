using DickinsonBros.Encryption.AES.Abstractions;
using DickinsonBros.Encryption.AES.Models;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Security.Cryptography;

namespace DickinsonBros.Encryption.AES
{
    public class AESEncryptionService<T> :  IAESEncryptionService<T>
    {
        internal readonly byte[] _key;
        internal readonly byte[] _initializationVector;

        public AESEncryptionService(IOptions<AESEncryptionServiceOptions<T>> aesEncryptionOptions)
        {
            _key = Convert.FromBase64String(aesEncryptionOptions.Value.Key);
            _initializationVector = Convert.FromBase64String(aesEncryptionOptions.Value.InitializationVector);
        }

        public byte[] Encrypt(string plainText)
        {
            byte[] encrypted;

            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = _key;
                aesAlg.IV = _initializationVector;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            return encrypted;
        }

        public string Decrypt(byte[] cipherText)
        {
            string plaintext = null;

            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = _key;
                aesAlg.IV = _initializationVector;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }

    }
}
