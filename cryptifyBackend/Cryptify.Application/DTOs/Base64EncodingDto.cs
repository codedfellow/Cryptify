using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptify.Application.DTOs
{
    public record Base64EncodingDto
    {
        public string TextToEncode { get; set; }
    }
}
