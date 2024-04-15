using RatingBooks.Domain.Entidades;
using RatingBooks.Domain.Dtos.LivroDtos;

namespace RatingBooks.Domain.Repository
{
    public interface ILivroRepository 
    {
        public Task<string> CriarLivro(CreateLivroDto livroDto, string userId);
        public Task<string> DeletarLivro(DeleteLivroDto livroDto, string userId);
        public Task<List<GetLivroDto>> GetAllLivros(string userId);
        public Task <List<GetLivroDto>> GetByNameLivro(string tituloLivro, string userId);
        public Task <GetLivroDto> GetById(int id, string userId);
        public Task<Livro> AtualizarLivro(int id, string userId, UpdateLivroDto livroUpdate);
    }
}
