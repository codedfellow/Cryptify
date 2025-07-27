using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptify.Application.DTOs
{
    public record XorCipherDecryptionDto
    {
        public string CipherText { get; set; }
        public string Key { get; set; }
    }
}
