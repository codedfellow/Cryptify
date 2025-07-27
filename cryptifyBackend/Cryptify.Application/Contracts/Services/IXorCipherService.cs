using Cryptify.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptify.Application.Contracts.Services
{
    public interface IXorCipherService
    {
        GenericResponseDto Encrypt(XorCipherEncryptionDto model);
        GenericResponseDto Decrypt(XorCipherDecryptionDto model);
    }
}
