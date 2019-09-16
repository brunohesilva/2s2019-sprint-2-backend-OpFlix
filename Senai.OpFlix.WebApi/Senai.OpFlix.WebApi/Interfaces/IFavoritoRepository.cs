﻿using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    interface IFavoritoRepository
    {
        List<Favoritos> Listar();

        void Favoritar(Favoritos favoritos);
    }
}
