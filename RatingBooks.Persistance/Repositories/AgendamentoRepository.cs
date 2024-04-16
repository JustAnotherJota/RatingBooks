using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RatingBooks.Domain.Dtos.AgendamentoDtos;
using RatingBooks.Domain.Entidades;
using RatingBooks.Domain.Repository;
using RatingBooks.Persistance.Configuration;

namespace RatingBooks.Persistance.Repositories
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private readonly UsuarioDbContext _context;
        private readonly IMapper _mapper;
        private readonly LivroRepository _livroRepository;

        public AgendamentoRepository(IMapper mapper, UsuarioDbContext context, LivroRepository livroRepository)
        {
            _mapper = mapper;
            _context = context;
            _livroRepository = livroRepository;
        }
        public async Task<string> Agendar(CreateAgendamentoDto agendamentoDto, string userId)
        {
            if (await AgendamentoById(agendamentoDto.LivroId, userId) != null)
                return "Esse livro já foi agendado";

            Agendamento agendamento = _mapper.Map<Agendamento>(agendamentoDto);

            agendamento.UsuarioId = userId;

            _context.Add(agendamento);
            await _context.SaveChangesAsync();

            return "Livro Agendado :D";
        }

        public async Task<Agendamento> AgendamentoById(int id, string userId) 
        {
            Agendamento validandoIdExistente = await _context.Agendamentos.Where(x => x.UsuarioId == userId && x.LivroId == id).FirstOrDefaultAsync();
            if (validandoIdExistente != null)
                return validandoIdExistente;
            return null;
        }

        public async Task<List<GetAgendamentoDto>> TodosOsAgendamentos(string userId)
        {
            List<Agendamento> agendamentos = await _context.Agendamentos.Where(x => x.UsuarioId == userId).ToListAsync();

            List<GetAgendamentoDto> agendamentosDto = _mapper.Map<List<GetAgendamentoDto>>(agendamentos);

            //agendamentosDto.ForEach(async x => x.livrosAgendados = await _livroService.GetById(x.LivroId, userId));

            foreach (var item in agendamentosDto)
            {
                item.livrosAgendados = await _livroRepository.GetById(item.LivroId, userId);
            }

            return agendamentosDto;
        }
        public async Task<List<GetAgendamentoDto>> LivrosExpirados(string userId)
        {
            List<Agendamento> agendamentos = await _context.Agendamentos.Where(x => x.UsuarioId == userId).ToListAsync();

            List<GetAgendamentoDto> agendamentosDto = _mapper.Map<List<GetAgendamentoDto>>(agendamentos);

            List<GetAgendamentoDto> agendamentosExpiradosDto = new();

            foreach (var item in agendamentosDto)
            {
                if (item.AgendamentoData < DateTime.Now)
                {
                    item.livrosAgendados = await _livroRepository.GetById(item.LivroId, userId);
                    agendamentosExpiradosDto.Add(item);
                }
            }

            return agendamentosExpiradosDto;
        }

        public async Task<List<GetAgendamentoDto>> LivrosNaoExpirados(string userId)
        {
            List<Agendamento> agendamentos = await _context.Agendamentos.Where(x => x.AgendamentoData > DateTime.Now && x.UsuarioId == userId).ToListAsync();

            List<GetAgendamentoDto> agendamentoDto = _mapper.Map<List<GetAgendamentoDto>>(agendamentos);

            List<GetAgendamentoDto> agendamentoDtosNaoExpirados = new();

            foreach (var item in agendamentoDto)
            {
                if (item.AgendamentoData > DateTime.Now)
                {
                    item.livrosAgendados = await _livroRepository.GetById(item.LivroId, userId);
                    agendamentoDtosNaoExpirados.Add(item);
                }
            }
            return agendamentoDtosNaoExpirados;
        }

        public async Task<Agendamento> AtualiarDataAgendada(int id, UpdateAgendamentoDto agendamentoDto, string userId)
        {
            Agendamento agendamento = await _context.Agendamentos.Where(x => x.UsuarioId == userId && x.LivroId == id).FirstOrDefaultAsync();

            if (agendamento is null)
                return null;

            var agendamentoAtualiadoDto = _mapper.Map(agendamentoDto, agendamento);
            await _context.SaveChangesAsync();

            return agendamentoAtualiadoDto;
        }

        public async Task<string> Deletar(int id, string userId)
        {
            Agendamento agendamento = await _context.Agendamentos.Where(x => x.LivroId == id && x.UsuarioId == userId).FirstOrDefaultAsync();

            if (agendamento is null || agendamento.UsuarioId != userId)
                return "Solicitação inválida";

            _context.Agendamentos.Remove(agendamento);

            await _context.SaveChangesAsync();

            return "Lidro Deletado";
        }

        //UpdateAgendamento  agendamentoDto.LivroId = id;  passar o LivroId atraves de parametro int Id ???
    }
}
