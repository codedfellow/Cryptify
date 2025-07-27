using Cryptify.Application.Contracts.Services;
using Cryptify.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptify.Application.Services
{
    public class XorCipherService : IXorCipherService
    {
        public GenericResponseDto Decrypt(XorCipherDecryptionDto model)
        {
            if (string.IsNullOrEmpty(model.CipherText))
                throw new ArgumentException("Ciphertext cannot be null or empty.");
            if (string.IsNullOrEmpty(model.Key))
                throw new ArgumentException("Key cannot be null or empty.");

            byte[] cipherBytes;
            try
            {
                cipherBytes = Convert.FromBase64String(model.CipherText);
            }
            catch (FormatException ex)
            {
                throw new ArgumentException("Invalid Base64 ciphertext: " + ex.Message);
            }

            string intermediate = Encoding.UTF8.GetString(cipherBytes);
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < intermediate.Length; i++)
            {
                char cipherChar = intermediate[i];
                char keyChar = model.Key[i % model.Key.Length]; // Repeat key if shorter than text
                result.Append((char)(cipherChar ^ keyChar));
            }
            return new GenericResponseDto(true, "Decryption successful", result.ToString());
        }

        public GenericResponseDto Encrypt(XorCipherEncryptionDto model)
        {
            if (string.IsNullOrEmpty(model.PlainText))
                throw new ArgumentException("Plaintext cannot be null or empty.");
            if (string.IsNullOrEmpty(model.Key))
                throw new ArgumentException("Key cannot be null or empty.");

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < model.PlainText.Length; i++)
            {
                char plainChar = model.PlainText[i];
                char keyChar = model.Key[i % model.Key.Length]; // Repeat key if shorter than text
                result.Append((char)(plainChar ^ keyChar));
            }
            string stringResult = Convert.ToBase64String(Encoding.UTF8.GetBytes(result.ToString()));
            return new GenericResponseDto(true, "Encryption successful", stringResult);
        }
    }
}
