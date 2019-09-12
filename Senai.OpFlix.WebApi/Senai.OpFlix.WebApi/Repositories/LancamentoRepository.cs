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
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Lancamentos LancamentoBuscado = ctx.Lancamentos.FirstOrDefault(x => x.IdLancamento == lancamento.IdLancamento);
                LancamentoBuscado.Titulo = lancamento.Titulo;
                ctx.Lancamentos.Update(LancamentoBuscado);
                ctx.SaveChanges();
            }
        }

        //public void Atualizar(Categorias categoria)
        //{
        //    using (OpFlixContext ctx = new OpFlixContext())
        //    {
        //        Categorias CategoriaBuscada = ctx.Categorias.FirstOrDefault(x => x.IdCategoria == categoria.IdCategoria);
        //        CategoriaBuscada.Categoria = categoria.Categoria;
        //        ctx.Categorias.Update(CategoriaBuscada);
        //        ctx.SaveChanges();
        //    }

        //}

        public Lancamentos BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Lancamentos.FirstOrDefault(x => x.IdLancamento == id);
            }

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
                using (OpFlixContext ctx = new OpFlixContext())
                {
                    Lancamentos LancamentoBuscado = ctx.Lancamentos.Find(id);
                    ctx.Lancamentos.Remove(LancamentoBuscado);
                    ctx.SaveChanges();
                }
        }

        //public void Deletar(int id)
        //{
        //    using (GufosContext ctx = new GufosContext())
        //    {
        //        Categorias CategoriaBuscada = ctx.Categorias.Find(id);
        //        ctx.Categorias.Remove(CategoriaBuscada);
        //        ctx.SaveChanges();
        //    }
        //}

        public List<Lancamentos> Listar()
        {
            //using (OpFlixContext ctx = new OpFlixContext())
            //{
            //    return ctx.Lancamentos.OrderBy(x => x.IdLancamento).ToList();
            //}

            List<Lancamentos> lancamentos = new List<Lancamentos>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT Lancamentos.IdLancamento, Lancamentos.Titulo, Lancamentos.Sinopse, Lancamentos.IdCategoria, Lancamentos.TempoDuracao, Lancamentos.FilmeSerie, Lancamentos.DataLancamento, Categorias.IdCategoria, Categorias.Categoria FROM Lancamentos JOIN Categorias ON Lancamentos.IdCategoria = Categorias.IdCategoria";
                con.Open();
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Lancamentos lancamento = new Lancamentos
                        {
                            IdLancamento = Convert.ToInt32(rdr["IdLancamento"]),
                            Titulo = rdr["Titulo"].ToString(),
                            Sinopse = rdr["Sinopse"].ToString(),
                            TempoDuracao = rdr["TempoDuracao"].ToString(),
                            FilmeSerie = rdr["FilmeSerie"].ToString(),
                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"]),
                            IdCategoriaNavigation = new Categorias
                            {
                                IdCategoria = Convert.ToInt32(rdr["IdCategoria"]),
                                Categoria = rdr["Categoria"].ToString()
                            }
                        };
                        lancamentos.Add(lancamento);
                    }
                }
            }
            return lancamentos;
        }
    }
}
