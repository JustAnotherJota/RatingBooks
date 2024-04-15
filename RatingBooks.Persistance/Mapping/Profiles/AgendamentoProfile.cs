using AutoMapper;
using RatingBooks.Domain.Dtos.AgendamentoDtos;
using RatingBooks.Domain.Entidades;

namespace RatingBooks.Persistance.Mapping.Profiles
{
    public class AgendamentoProfile : Profile
    {
        public AgendamentoProfile()
        {
            CreateMap<Agendamento, GetAgendamentoDto>();
            CreateMap<CreateAgendamentoDto, Agendamento>();
            CreateMap<UpdateAgendamentoDto, Agendamento>();
        }
    }
}
