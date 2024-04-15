using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Mvc;
using RatingBooks.Application.Services;
using RatingBooks.Domain.Dtos.AgendamentoDtos;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace RatingBooks.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AgendamentoController : ControllerBase
    {
        private readonly AgendamentoService _agendamentoService;

        public AgendamentoController(AgendamentoService agendamentoService)
        {
            _agendamentoService = agendamentoService;
        }

        [HttpPost("AgendarLivro")]
        public async Task<IActionResult> Agendar([FromBody] CreateAgendamentoDto agendamento)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var resultado = await _agendamentoService.Agendar(agendamento, userId);

            return Ok(resultado);
        }
        [HttpGet("TodosLivrosAgendados")]
        public async Task<IActionResult> GetAllAgendados()
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var resultado = await _agendamentoService.TodosOsAgendamentos(userId);

            return Ok(resultado);
        }

        [HttpGet("AgendamentoExpirado")]
        public async Task<IActionResult> GetAgendamentoExpirado()
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var resultado = await _agendamentoService.LivrosExpirados(userId);


            return Ok(resultado);
        }

        [HttpGet("AgendamentoNaoExpirado")]
        public async Task<IActionResult> GetAgendamentoNaoExpirado()
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var resultado = await _agendamentoService.LivrosNaoExpirados(userId);

            return Ok(resultado);
        }
        [HttpPut("AtualizarAgendamento/{id}")]
        public async Task<IActionResult> PutAgendamento(int id, UpdateAgendamentoDto agendamentoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var resultado = await _agendamentoService.AtualiarDataAgendada(id, agendamentoDto, userId);

            if (resultado is null)
                return NotFound("Livro não encontrado");

            return Ok(resultado.AgendamentoData); //Arrumar dps, voltando Agendamento base, retornar um DTO
        }

        [HttpDelete("DeletarAgendamento")]
        public async Task<IActionResult> DeleteAgendamento(int id) 
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var resultado = await _agendamentoService.DeletarAgendamento(id, userId);

            return Ok(resultado);
        }
    }
}
