using AutoMapper;
using RatingBooks.Domain.Dtos.UsuarioDtos;
using RatingBooks.Domain.Entidades;

namespace RatingBooks.Persistance.Mapping.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
        }
    }
}
