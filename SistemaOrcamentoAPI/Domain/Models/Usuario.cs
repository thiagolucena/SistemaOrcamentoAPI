﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }

}
