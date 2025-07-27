using Cryptify.Application.Contracts.Services;
using Cryptify.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptify.Application.Services
{
    public class Base64Service : IBase64Service
    {
        public GenericResponseDto DecodeBase64String(string base64Text)
        {
            if (string.IsNullOrEmpty(base64Text))
            {
                throw new ArgumentException("Input text cannot be null or empty.");
            }

            try
            {
                byte[] base64Bytes = Convert.FromBase64String(base64Text);
                string result = Encoding.UTF8.GetString(base64Bytes);
                return new GenericResponseDto(true, "Decoding successful", result);
            }
            catch (FormatException ex)
            {
                throw new ArgumentException("Invalid Base64 string: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error decoding from Base64: " + ex.Message);
            }
        }

        public GenericResponseDto EncodeToBase64(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
            {
                throw new ArgumentException("Input text cannot be null or empty.");
            }

            try
            {
                byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                string result = Convert.ToBase64String(plainBytes);
                return new GenericResponseDto(true, "Encoding successful", result);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error encoding to Base64: " + ex.Message);
            }
        }
    }
}
