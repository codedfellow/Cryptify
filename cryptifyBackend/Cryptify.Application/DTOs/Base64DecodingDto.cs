using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptify.Application.DTOs
{
    public record Base64DecodingDto
    {
        public string Base64Text { get; set; }
    }
}
