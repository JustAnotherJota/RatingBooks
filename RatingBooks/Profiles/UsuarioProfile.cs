using AutoMapper;
using RatingBooks.Data.Dtos.UsuarioDtos;
using RatingBooks.Models;

namespace RatingBooks.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
        }
    }
}
