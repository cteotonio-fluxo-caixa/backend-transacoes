﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transacoes.Aplicacao.DTOs
{
    public class BaseDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
