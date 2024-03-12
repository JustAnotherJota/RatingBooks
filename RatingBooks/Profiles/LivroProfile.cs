using AutoMapper;
using RatingBooks.Data.Dtos.LivroDtos;
using RatingBooks.Models;

namespace RatingBooks.Profiles
{
    public class LivroProfile : Profile
    {
        public LivroProfile()
        {
            CreateMap<CreateLivroDto, Livro>();
            CreateMap<DeleteLivroDto, Livro>();
            CreateMap<Livro, GetLivroDto>();
            CreateMap<Livro, UpdateLivroDto>();
            CreateMap<UpdateLivroDto, Livro>();
        }
    }
}
