﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptify.Application.DTOs
{
    public record AesEncryptDto
    {
        public string Key { get; set; }
        public string PlainText { get; set; }
    }
}
