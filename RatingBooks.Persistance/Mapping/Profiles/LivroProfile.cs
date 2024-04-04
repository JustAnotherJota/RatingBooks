using AutoMapper;
using RatingBooks.Domain.Dtos.LivroDtos;
using RatingBooks.Domain.Entidades;

namespace RatingBooks.Persistance.Mapping.Profiles
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
