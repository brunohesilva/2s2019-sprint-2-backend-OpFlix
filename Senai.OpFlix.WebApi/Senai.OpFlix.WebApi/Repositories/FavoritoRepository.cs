using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class FavoritoRepository : IFavoritoRepository
    {

        [Authorize(Roles = "ADMINISTRADOR")]
        public void Favoritar(Favoritos favoritos)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Favoritos.Add(favoritos);
                ctx.SaveChanges();
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        public List<Favoritos> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Favoritos.Include(x => x.Usuario).ToList();
            }
        }
    }
}
