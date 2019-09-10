using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class LancamentoRepository : ILancamentoRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_OpFlix;User Id=sa;Pwd=132;";

        public void Atualizar(Lancamentos lancamento)
        {
            throw new NotImplementedException();
        }

        public Lancamentos BuscarPorId(int IdLancamento)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Lancamentos lancamento)
        {
            string Query = "INSERT INTO Lancamentos(Titulo, Sinopse, IdCategoria, TempoDuracao, FilmeSerie, DataLancamento) VALUES (@Titulo, @Sinopse, @IdCategoria, @TempoDuracao, @FilmeSerie, @DataLancamento)";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Titulo", lancamento.Titulo);
                cmd.Parameters.AddWithValue("@Sinopse", lancamento.Sinopse);
                cmd.Parameters.AddWithValue("@IdCategoria", lancamento.IdCategoria);
                cmd.Parameters.AddWithValue("@TempoDuracao", lancamento.TempoDuracao);
                cmd.Parameters.AddWithValue("@FilmeSerie", lancamento.FilmeSerie);
                cmd.Parameters.AddWithValue("@DataLancamento", lancamento.DataLancamento);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Lancamentos> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
