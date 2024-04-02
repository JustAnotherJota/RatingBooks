using AutoMapper;
using RatingBooks.Data.Dtos.AgendamentoDtos;
using RatingBooks.Models;

namespace RatingBooks.Profiles
{
    public class AgendamentoProfile : Profile
    {
        public AgendamentoProfile()
        {
            CreateMap<Agendamento, GetAgendamentoDto>();
            CreateMap<CreateAgendamentoDto, Agendamento>();
        }
    }
}
