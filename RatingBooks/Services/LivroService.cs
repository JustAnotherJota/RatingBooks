using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RatingBooks.Data;
using RatingBooks.Data.Dtos.LivroDtos;
using RatingBooks.Models;

namespace RatingBooks.Services
{
    public class LivroService
    {
        private IMapper _mapper;
        private UsuarioDbContext _context;
        public LivroService(IMapper mapper, UsuarioDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<string> CriarLivro(CreateLivroDto livroDto, string userId)
        {
            Livro livro = _mapper.Map<Livro>(livroDto);

            livro.UsuarioId = userId;

            _context.Livros.Add(livro);

            await _context.SaveChangesAsync();

            return "Livro Adicionado com sucesso!";
        }

        public async Task<string> DeletarLivro(DeleteLivroDto livroDto, string userId)
        {
            Livro livro = await _context.Livros.SingleOrDefaultAsync(lvr => lvr.Id == livroDto.Id);

            if (livro is null || !(livro.UsuarioId == userId))
                return "Solicitação inválida";

            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();
            return "Livro deletado!";
        }

        public async Task<List<GetLivroDto>> GetAllLivros(string userId) 
        {
            List<Livro> Livros = await _context.Livros.Where( lvr => lvr.UsuarioId == userId).ToListAsync();
            List<GetLivroDto> livrosDto = _mapper.Map<List<GetLivroDto>>(Livros);

            return livrosDto;
        }

        //public async Task<GetLivroDto> GetByIdLivro (string userId)
        //{
            
        //}
    }
}
