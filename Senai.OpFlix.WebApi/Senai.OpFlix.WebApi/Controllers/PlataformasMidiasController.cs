using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpPost]
        public IActionResult Cadastrar(PlataformasMidias plataformamidia)
        {
            PlataformaMidiaRepository.Cadastrar(plataformamidia);
            return Ok();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(PlataformaMidiaRepository.Listar());
        }

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
    }
}