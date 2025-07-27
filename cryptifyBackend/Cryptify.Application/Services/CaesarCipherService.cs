using Cryptify.Application.Contracts.Services;
using Cryptify.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptify.Application.Services
{
    public class CaesarCipherService : ICaesarCipherService
    {
        public GenericResponseDto Decrypt(DecryptCaesarCipherDto model)
        {
            if (string.IsNullOrEmpty(model.CipherText))
                throw new ArgumentException("Ciphertext cannot be null or empty.");
            if (model.Shift < 0 || model.Shift > 25)
                throw new ArgumentException("Shift must be between 0 and 25.");

            // Decryption is just encryption with the reverse shift
            var decryptModel = new EncryptCaesarCipherDto
            {
                PlainText = model.CipherText,
                Shift = 26 - model.Shift
            };
            var result = Encrypt(decryptModel);
            return new GenericResponseDto(true, "Decryption successful", result.Data);
        }

        public GenericResponseDto Encrypt(EncryptCaesarCipherDto model)
        {
            if (string.IsNullOrEmpty(model.PlainText))
                throw new ArgumentException("Plaintext cannot be null or empty.");
            if (model.Shift < 0 || model.Shift > 25)
                throw new ArgumentException("Shift must be between 0 and 25.");

            StringBuilder result = new StringBuilder();
            foreach (char c in model.PlainText)
            {
                if (char.IsLetter(c))
                {
                    char baseChar = char.IsUpper(c) ? 'A' : 'a';
                    result.Append((char)((((c - baseChar) + model.Shift) % 26) + baseChar));
                }
                else
                {
                    result.Append(c); // Preserve non-letters
                }
            }

            string stringResult = result.ToString();
            return new GenericResponseDto(true, "Encryption successful", stringResult);
        }
    }
}
