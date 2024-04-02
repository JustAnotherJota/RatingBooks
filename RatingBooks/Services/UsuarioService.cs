using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RatingBooks.Data;
using RatingBooks.Data.Dtos.LivroDtos;
using RatingBooks.Data.Dtos.UsuarioDtos;
using RatingBooks.Models;

namespace RatingBooks.Services
{
    public class UsuarioService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        public UsuarioService(IMapper mapper, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task CadastraUsuario(CreateUsuarioDto dto)
        {
            Usuario usuario = _mapper.Map<Usuario>(dto);

            IdentityResult resultado = await _userManager.CreateAsync(usuario, dto.Password);

            if (!resultado.Succeeded)
                throw new ApplicationException("Falha ao cadastrar Usuário");
        }
        public async Task<string> Login(LoginUsuarioDto dto)
        {
            var resultado = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);
            if (!resultado.Succeeded)
                throw new ApplicationException("Usuário não identificado!");

            var usuario = _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == dto.Username.ToUpper());

            await _signInManager.SignInAsync(usuario, false);

            return "Usuário Autenticado!";
        }

        public async Task Logoff()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
