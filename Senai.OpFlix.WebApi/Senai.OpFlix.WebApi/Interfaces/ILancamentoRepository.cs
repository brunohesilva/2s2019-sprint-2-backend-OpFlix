using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    interface ILancamentoRepository
    {
        void Cadastrar(Lancamentos lancamento);

        List<Lancamentos> Listar();

        Lancamentos BuscarPorId(int IdLancamento);

        void Atualizar(Lancamentos lancamento);

        void Deletar(int id);
    }
}
