using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptify.Application.DTOs
{
    public record AesDescryptDto
    {
        public string CipherText { get; set; }
        public string Key { get; set; }
        public string Iv { get; set; }
    }
}
