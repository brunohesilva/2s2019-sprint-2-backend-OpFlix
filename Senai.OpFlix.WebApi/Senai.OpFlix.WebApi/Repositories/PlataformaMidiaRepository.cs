using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class PlataformaMidiaRepository : IPlataformaMidiaRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_OpFlix;User Id=sa;Pwd=132;";

        public void Atualizar(PlataformasMidias plataformamidia)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                PlataformasMidias PlataformaMidiaBuscada = ctx.PlataformasMidias.FirstOrDefault(x => x.IdPlataformaMidia == plataformamidia.IdPlataformaMidia);
                PlataformaMidiaBuscada.PlataformaMidia = plataformamidia.PlataformaMidia;
                ctx.PlataformasMidias.Update(PlataformaMidiaBuscada);
                ctx.SaveChanges();
            }
        }

        public PlataformasMidias BuscarPorId(int Idplataformamidia)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.PlataformasMidias.FirstOrDefault(x => x.IdPlataformaMidia == Idplataformamidia);
            }
        }

        public void Cadastrar(PlataformasMidias plataformamidia)
        {
            string Query = "INSERT INTO PlataformasMidias(PlataformaMidia) VALUES (@PlataformaMidia)";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@PlataformaMidia", plataformamidia.PlataformaMidia);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public PlataformasMidias FiltrarPlataforma(string nome)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                PlataformasMidias PlataformaMidiaBuscada = ctx.PlataformasMidias.FirstOrDefault(x => x.PlataformaMidia == nome);
                return PlataformaMidiaBuscada;
            }
        }

        public List<PlataformasMidias> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.PlataformasMidias.OrderBy(x => x.IdPlataformaMidia).ToList();
            }
        }
    }
}
