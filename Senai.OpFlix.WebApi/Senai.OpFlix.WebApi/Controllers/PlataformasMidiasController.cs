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
    public class PlataformasMidiasController : ControllerBase
    {
        private IPlataformaMidiaRepository PlataformaMidiaRepository { get; set; }

        public PlataformasMidiasController()
        {
            PlataformaMidiaRepository = new PlataformaMidiaRepository();
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(PlataformasMidias plataformamidia)
        {
            PlataformaMidiaRepository.Cadastrar(plataformamidia);
            return Ok();
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(PlataformaMidiaRepository.Listar());
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, PlataformasMidias plataformamidia)
        {
            try
            {
                PlataformasMidias plataformamididaBuscada = PlataformaMidiaRepository.BuscarPorId(id);
                if (plataformamididaBuscada == null)
                    return NotFound();
                plataformamidia.IdPlataformaMidia = id;
                PlataformaMidiaRepository.Atualizar(plataformamidia);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{nome}")]
        public IActionResult Filtrar(string nome)
        {
            try
            {
                PlataformasMidias plataformamidia = PlataformaMidiaRepository.FiltrarPlataforma(nome);
                if (plataformamidia == null)
                    return NotFound();
                return Ok(plataformamidia);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}