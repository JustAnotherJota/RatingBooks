using Microsoft.AspNetCore.Mvc;
using RatingBooks.Data.Dtos.AgendamentoDtos;
using RatingBooks.Services;
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
            if (!ModelState.IsValid)
                return BadRequest();

            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var resultado = await _agendamentoService.TodosOsAgendamentos(userId);

            return Ok(resultado);
        }
    }
}
