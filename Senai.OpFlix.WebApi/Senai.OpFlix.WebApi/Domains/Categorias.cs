﻿using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Categorias
    {
        public Categorias()
        {
            Lancamentos = new HashSet<Lancamentos>();
        }

        public int IdCategoria { get; set; }
        public string Categoria { get; set; }
        //public int? IdUsuario { get; set; }

        public ICollection<Lancamentos> Lancamentos { get; set; }

        //public Usuarios Usuario { get; set; }
    }
}
