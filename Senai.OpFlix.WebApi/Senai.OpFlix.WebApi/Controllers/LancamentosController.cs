using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.Repositories;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LancamentosController : ControllerBase
    {
        private ILancamentoRepository LancamentoRepository { get; set; }

        public LancamentosController()
        {
            LancamentoRepository = new LancamentoRepository();
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Lancamentos lancamento)
        {
            LancamentoRepository.Cadastrar(lancamento);
            return Ok();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(LancamentoRepository.Listar());
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Lancamentos Lancamento = LancamentoRepository.BuscarPorId(id);
            if (Lancamento == null)
            {
                return NotFound();
            }
            return Ok(Lancamento);
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Lancamentos lancamento)
        {
            try
            {
                Lancamentos lancamentoBuscado = LancamentoRepository.BuscarPorId(id);
                if (lancamentoBuscado == null)
                    return NotFound();
                lancamento.IdLancamento = id;
                LancamentoRepository.Atualizar(lancamento);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        //[HttpPut("{id}")]
        //public IActionResult Atualizar(int id, Categorias categoria)
        //{
        //    try
        //    {
        //        Categorias categoriaBuscada = CategoriaRepository.BuscarPorId(id);
        //        if (categoriaBuscada == null)
        //            return NotFound();
        //        categoria.IdCategoria = id;
        //        CategoriaRepository.Atualizar(categoria);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { mensagem = ex.Message });
        //    }
        //}

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            LancamentoRepository.Deletar(id);
            return Ok();
        }
    }
}