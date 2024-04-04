using RatingBooks.Domain.Dtos.LivroDtos;
using RatingBooks.Domain.Entidades;
using RatingBooks.Persistance.Repositories;

namespace RatingBooks.Application.Services
{
    public class LivroService
    {
        private readonly LivroRepository _livroRepository;
        public LivroService(LivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<string> CriarLivro(CreateLivroDto livroDto, string userId)
        {
            return await _livroRepository.CriarLivro(livroDto, userId);
        }

        public async Task<string> DeletarLivro(DeleteLivroDto livroDto, string userId)
        {
            return await _livroRepository.DeletarLivro(livroDto, userId);
        }

        public async Task<List<GetLivroDto>> GetAllLivros(string userId)
        {
            return await _livroRepository.GetAllLivros(userId);
        }

        public async Task<List<GetLivroDto>> GetByNameLivro(string tituloLivro, string userId)
        {
            return await _livroRepository.GetByNameLivro(tituloLivro, userId);
        }

        public async Task<GetLivroDto> GetById(int id, string userId)
        {
            return await _livroRepository.GetById(id, userId);
        }

        public async Task<Livro> AtualizarLivro(int id, string userId, UpdateLivroDto livroUpdate)
        {
            return await _livroRepository.AtualizarLivro(id, userId, livroUpdate);
        }
    }
}
