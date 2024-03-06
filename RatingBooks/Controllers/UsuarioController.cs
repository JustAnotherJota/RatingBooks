using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RatingBooks.Data.Dtos.LivroDtos;
using RatingBooks.Data.Dtos.UsuarioDtos;
using RatingBooks.Models;
using RatingBooks.Services;
using System.Net;
using System.Security.Claims;

namespace RatingBooks.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService _usuarioService;
        public UsuarioController(UsuarioService service)
        {
            _usuarioService = service;
        }
        [HttpPost("cadastro")]
        public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto dto) 
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _usuarioService.CadastraUsuario(dto);

            return Ok("Usuario Cadastrado");
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUsuario(LoginUsuarioDto dto) 
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var login = await _usuarioService.Login(dto);

            return Ok(login);
        }

        [HttpPost("logoff")]
        public async Task<IActionResult> DeslogarUsuario() 
        {
              await _usuarioService.Logoff();
              return Ok();
        }


    }
}
