using Cryptify.Application.Contracts.Services;
using Cryptify.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Security.Cryptography;

namespace Cryptify.Application.Services
{
    public class AesService : IAesService
    {
        public GenericResponseDto Decrypt(AesDescryptDto model)
        {
            if (string.IsNullOrEmpty(model.CipherText))
                throw new ArgumentException("Ciphertext cannot be null or empty.");
            if (string.IsNullOrEmpty(model.Key))
                throw new ArgumentException("Key cannot be null or empty.");
            if (string.IsNullOrEmpty(model.Iv))
                throw new ArgumentException("IV cannot be null or empty.");

            byte[] keyBytes = Convert.FromBase64String(model.Key);
            if (keyBytes.Length != 16 && keyBytes.Length != 24 && keyBytes.Length != 32)
                throw new ArgumentException("Key must be 16, 24, or 32 bytes (Base64 encoded).");

            byte[] ivBytes;
            byte[] cipherBytes;
            try
            {
                ivBytes = Convert.FromBase64String(model.Iv);
                cipherBytes = Convert.FromBase64String(model.CipherText);
            }
            catch (FormatException ex)
            {
                throw new ArgumentException("Invalid Base64 string for ciphertext or IV: " + ex.Message);
            }

            try
            {
                using Aes aes = Aes.Create();
                aes.Key = keyBytes;
                aes.IV = ivBytes;
                using var decryptor = aes.CreateDecryptor();
                byte[] decryptedBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                return new GenericResponseDto(true, "Decryption successful", Encoding.UTF8.GetString(decryptedBytes));
            }
            catch (CryptographicException ex)
            {
                throw new InvalidOperationException("Error during AES decryption (possible invalid key or IV): " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error during AES decryption: " + ex.Message);
            }
        }

        public GenericResponseDto Encrypt(AesEncryptDto model)
        {
            if (string.IsNullOrEmpty(model.PlainText))
                throw new ArgumentException("Plaintext cannot be null or empty.");
            if (string.IsNullOrEmpty(model.Key))
                throw new ArgumentException("Key cannot be null or empty.");

            byte[] keyBytes = Convert.FromBase64String(model.Key);
            if (keyBytes.Length != 16 && keyBytes.Length != 24 && keyBytes.Length != 32)
                throw new ArgumentException("Key must be 16, 24, or 32 bytes (Base64 encoded).");

            try
            {
                using Aes aes = Aes.Create();
                aes.Key = keyBytes;
                aes.GenerateIV(); // Generate a random IV for each encryption
                using var encryptor = aes.CreateEncryptor();
                byte[] plainBytes = Encoding.UTF8.GetBytes(model.PlainText);
                byte[] cipherBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
                (string,string) result = (Convert.ToBase64String(cipherBytes), Convert.ToBase64String(aes.IV));
                return new GenericResponseDto(true, "Encryption successful", new { CipherBytes = result.Item1, Iv = result.Item2 });
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error during AES encryption: " + ex.Message);
            }
        }
    }
}
