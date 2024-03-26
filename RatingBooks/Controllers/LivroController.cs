using Microsoft.AspNetCore.Mvc;
using RatingBooks.Data.Dtos.LivroDtos;
using RatingBooks.Models;
using RatingBooks.Services;
using System.Security.Claims;
using static RatingBooks.Models.Livro;

namespace RatingBooks.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class LivroController : ControllerBase
    {
        private LivroService _livroService;
        private StatusLivro _statusLivro;
        public LivroController(LivroService livroService, StatusLivro statusLivro)
        {
            _livroService = livroService;
            _statusLivro = statusLivro;
        }

        [HttpPost("criandoLivro")]
        public async Task<IActionResult> CriarLivro([FromBody] CreateLivroDto livroDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!_statusLivro.statusLivroArray.Contains(livroDto.Status))
                return BadRequest("O status do livro necessita ser inserido corretamente");

            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var resultado = await _livroService.CriarLivro(livroDto, userId);

            return Ok(resultado);
        }

        [HttpDelete("deletandoLivro")]
        public async Task<IActionResult> DeletarLivro(DeleteLivroDto livroDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // UsuarioId = 66ffgs4343dy-rfdt432132 exemplo

            var resultado = await _livroService.DeletarLivro(livroDto, userId);

            return Ok(resultado);
        }

        [HttpGet("buscarLivros")]
        public async Task<IActionResult> GetAll()
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var resultado = await _livroService.GetAllLivros(userId);

            if (resultado == null)
                return NotFound("Que tal inserir um livro :D ?");

            return Ok(resultado);
        }

        [HttpGet("buscarLivro")]
        public async Task<IActionResult> GetByName(string tituloLivro)
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var resultado = await _livroService.GetByNameLivro(tituloLivro, userId);

            if (resultado == null)
                return NotFound("O livro solicitado não foi encontrado");

            return Ok(resultado);
        }

        [HttpGet("BuscarLivro/{id}")]
        public async Task<IActionResult> GetById(int id) 
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var resultado = await _livroService.GetById(id, userId);

            if (resultado == null) 
            {
                return NotFound("O livro solicitado não foi encontrado");
            }
            return Ok(resultado);
        }

        [HttpPut("atualizarLivro/{id}")]
        public async Task<IActionResult> AtualizaLivro(int id, UpdateLivroDto livroDto) 
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!_statusLivro.statusLivroArray.Contains(livroDto.Status))
                return BadRequest("O status do livro necessita ser inserido corretamente");

            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var resultado = await _livroService.AtualizarLivro(id, userId, livroDto);

            if (resultado == null)
                return NotFound("Livro não encontrado");

            return NoContent();
        }

        //adicionar padrão early return 
    }
}
