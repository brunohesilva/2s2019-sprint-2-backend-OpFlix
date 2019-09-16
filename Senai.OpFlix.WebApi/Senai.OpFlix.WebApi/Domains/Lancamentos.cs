using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Lancamentos
    {
        public int IdLancamento { get; set; }
        public string Titulo { get; set; }
        public string Sinopse { get; set; }
        public int? IdCategoria { get; set; }
        public string TempoDuracao { get; set; }
        public string FilmeSerie { get; set; }
        public DateTime DataLancamento { get; set; }

        public Categorias IdCategoriaNavigation { get; set; }
        public List<Favoritos> Favoritos { get; set; }
    }
}
