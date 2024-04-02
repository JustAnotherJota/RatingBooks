using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RatingBooks.Data;
using RatingBooks.Data.Dtos.AgendamentoDtos;
using RatingBooks.Models;

namespace RatingBooks.Services;

public class AgendamentoService
{
    private readonly UsuarioDbContext _context;
    private readonly IMapper _mapper;
    private readonly LivroService _livroService;
    public AgendamentoService(UsuarioDbContext context, IMapper mapper, LivroService livroService)
    {
        _context = context;
        _mapper = mapper;
        _livroService = livroService;
    }
    public async Task<string> Agendar(CreateAgendamentoDto agendamentoDto, string userId) 
    {
        Agendamento agendamento = _mapper.Map<Agendamento>(agendamentoDto);
        agendamento.UsuarioId = userId;

        _context.Add(agendamento);
        await _context.SaveChangesAsync();

        return "Livro Agendado :D";
    }

    public async Task<List<GetAgendamentoDto>> TodosOsAgendamentos(string userId) 
    {
        List<Agendamento> agendamentos = await _context.Agendamentos.Where(x => x.UsuarioId == userId).ToListAsync();

        List<GetAgendamentoDto> agendamentosDto = _mapper.Map<List<GetAgendamentoDto>>(agendamentos);

        //agendamentosDto.ForEach(async x => x.livrosAgendados = await _livroService.GetById(x.LivroId, userId));

        foreach (var item in agendamentosDto)
        {
            item.livrosAgendados = await _livroService.GetById(item.LivroId, userId);
        }

        return agendamentosDto;
    }

    //public async Task<List<Agendamento>> LivrosExpirados()
    //public async Task<List<Agendamento>> LivrosAgendados()
}
