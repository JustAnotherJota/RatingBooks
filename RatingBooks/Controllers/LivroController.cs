using Microsoft.AspNetCore.Mvc;
using RatingBooks.Data.Dtos.LivroDtos;
using RatingBooks.Services;
using System.Security.Claims;

namespace RatingBooks.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class LivroController : ControllerBase
    {
        private LivroService _livroService;
        public LivroController(LivroService livroService)
        {
            _livroService = livroService;
        }

        [HttpPost("criandoLivro")]
        public async Task<IActionResult> CriarLivro([FromBody] CreateLivroDto livroDto)
        {

            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var resultado = await _livroService.CriarLivro(livroDto, userId);

            return Ok(resultado);
        }

        [HttpDelete("deletandoLivro")]
        public async Task<IActionResult> DeletarLivro(DeleteLivroDto livroDto)
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // UsuarioId = 66ffgs4343dy-rfdt432132 exemplo

            var resultado = await _livroService.DeletarLivro(livroDto, userId);

            return Ok(resultado);
        }

        [HttpGet("buscarLivro")]
        public async Task<IActionResult> GetAll()
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return Ok(await _livroService.GetAllLivros(userId));
        }
    }
}
