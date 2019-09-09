using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class TipoFilmesSeries
    {
        public TipoFilmesSeries()
        {
            Lancamentos = new HashSet<Lancamentos>();
        }

        public int IdTipoFilmeSerie { get; set; }
        public string TipoFilmeSerie { get; set; }

        public ICollection<Lancamentos> Lancamentos { get; set; }
    }
}
