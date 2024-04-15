using RatingBooks.Domain.Dtos.AgendamentoDtos;
using RatingBooks.Domain.Entidades;
using RatingBooks.Persistance.Repositories;
using System.Runtime.CompilerServices;

namespace RatingBooks.Application.Services;

public class AgendamentoService
{
    private readonly AgendamentoRepository _agendamentoRepository;
    public AgendamentoService(AgendamentoRepository agendamentoRepository)
    {
        _agendamentoRepository = agendamentoRepository;
    }
    public async Task<string> Agendar(CreateAgendamentoDto agendamentoDto, string userId)
    {
        return await _agendamentoRepository.Agendar(agendamentoDto, userId);
    }

    public async Task<List<GetAgendamentoDto>> TodosOsAgendamentos(string userId)
    {
        return await _agendamentoRepository.TodosOsAgendamentos(userId);
    }

    public async Task<List<GetAgendamentoDto>> LivrosExpirados(string userId)
    {
        return await _agendamentoRepository.LivrosExpirados(userId);
    }

    public async Task<List<GetAgendamentoDto>> LivrosNaoExpirados(string userId) 
    {
        return await _agendamentoRepository.LivrosNaoExpirados(userId);
    }

    public async Task<Agendamento> AtualiarDataAgendada(int id, UpdateAgendamentoDto agendamentoDto, string userId) 
    {
        return await _agendamentoRepository.AtualiarDataAgendada(id, agendamentoDto, userId);
    }
    public async Task<string> DeletarAgendamento(int id, string userId) 
    {
        return await _agendamentoRepository.Deletar(id, userId);
    }
}
