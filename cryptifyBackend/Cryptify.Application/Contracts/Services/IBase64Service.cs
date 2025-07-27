using Cryptify.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptify.Application.Contracts.Services
{
    public interface IBase64Service
    {
        GenericResponseDto EncodeToBase64(string plainText);
        GenericResponseDto DecodeBase64String(string base64Text);
    }
}
