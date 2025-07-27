using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptify.Application.DTOs
{
    public record EncryptCaesarCipherDto
    {
        public string PlainText { get; set; }
        public int Shift { get; set; }
    }
}
