using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptify.Application.DTOs
{
    public record DecryptCaesarCipherDto
    {
        public string CipherText { get; set; }
        public int Shift { get; set; }
    }
}
