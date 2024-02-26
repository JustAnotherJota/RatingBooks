using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RatingBooks.Data;
using RatingBooks.Data.Dtos.LivroDtos;
using RatingBooks.Data.Dtos.UsuarioDtos;
using RatingBooks.Models;

namespace RatingBooks.Services
{
    public class UsuarioService
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;
        private UsuarioDbContext _context;
        public UsuarioService(IMapper mapper, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, UsuarioDbContext context)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task Cadastra(CreateUsuarioDto dto)
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

        public async Task<string> CriarLivro(CreateLivroDto livroDto, string userId) 
        {
            Livro livro = _mapper.Map<Livro>(livroDto);

            livro.UsuarioId = userId;

            _context.Livros.Add(livro);

            await _context.SaveChangesAsync();

            return "Livro Adicionado com sucesso!";
            
        }
    }
}
