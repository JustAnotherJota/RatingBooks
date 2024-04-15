using RatingBooks.Domain.Dtos.AgendamentoDtos;
using RatingBooks.Domain.Entidades;

namespace RatingBooks.Domain.Repository
{
    public interface IAgendamentoRepository
    {
        public Task<string> Agendar(CreateAgendamentoDto agendamentoDto, string userId);
        public Task<List<GetAgendamentoDto>> TodosOsAgendamentos(string userId);
        public Task<List<GetAgendamentoDto>> LivrosExpirados(string userId);
        public Task<List<GetAgendamentoDto>> LivrosNaoExpirados(string userId);
        public Task<Agendamento> AtualiarDataAgendada(int id,UpdateAgendamentoDto agendamentoDto ,string userId);
        public Task<string> Deletar(int id, string userId);
    }
}
