using Cryptify.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptify.Application.Contracts.Services
{
    public interface ICaesarCipherService
    {
        GenericResponseDto Encrypt(EncryptCaesarCipherDto model);
        GenericResponseDto Decrypt(DecryptCaesarCipherDto model);
    }
}
