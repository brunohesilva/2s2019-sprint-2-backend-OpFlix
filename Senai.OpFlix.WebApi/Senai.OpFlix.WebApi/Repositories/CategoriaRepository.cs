using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_OpFlix;User Id=sa;Pwd=132;";

        public void Atualizar(Categorias categoria)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Categorias CategoriaBuscada = ctx.Categorias.FirstOrDefault(x => x.IdCategoria == categoria.IdCategoria);
                CategoriaBuscada.Categoria = categoria.Categoria;
                ctx.Categorias.Update(CategoriaBuscada);
                ctx.SaveChanges();
            }

        }

        public void Cadastrar(Categorias categoria)
        {
            string Query = "INSERT INTO Categorias(Categoria) VALUES (@Categoria)";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Categoria", categoria.Categoria);  
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Categorias> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Categorias.OrderBy(x => x.IdCategoria).ToList();
            }
        }

        public Categorias BuscarPorId(int IdCategoria)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Categorias.FirstOrDefault(x => x.IdCategoria == IdCategoria);
            }
        }

    }
}
