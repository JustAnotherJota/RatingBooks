using Microsoft.AspNetCore.Mvc;
using RatingBooks.Services;

namespace RatingBooks.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AgendamentoController : ControllerBase
    {
        private AgendamentoService _agendamentoService;

        public AgendamentoController(AgendamentoService agendamentoService)
        {
            _agendamentoService = agendamentoService;
        }


    }
}
