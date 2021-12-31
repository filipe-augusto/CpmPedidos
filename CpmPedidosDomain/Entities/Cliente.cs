﻿using System;

namespace CpmPedidos.Domain
{
    public class Cliente : BaseDomain, IExibivel
    {

        public string Nome { get; set; }
        
        public string Cpf { get; set; }
        
        public string IdEndereco { get; set; }
        
        public Endereco Endereco { get; set; }
        
        public bool Ativo { get; set; }
    }
}
