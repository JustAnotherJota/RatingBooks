using RatingBooks.Domain.Dtos.AgendamentoDtos;

namespace RatingBooks.Domain.Repository
{
    public interface IAgendamentoRepository
    {
        public Task<string> Agendar(CreateAgendamentoDto agendamentoDto, string userId);
        public Task<List<GetAgendamentoDto>> TodosOsAgendamentos(string userId);
        public Task<List<GetAgendamentoDto>> LivrosExpirados(string userId);
        //public Task<List<Agendamento>> LivrosAgendados(string userId);
    }
}
