using RatingBooks.Domain.Dtos.LivroDtos;
using System.ComponentModel.DataAnnotations;

namespace RatingBooks.Domain.Dtos.AgendamentoDtos
{
    public class GetAgendamentoDto
    {
        [Required]
        public DateTime AgendamentoData { get; set; }
        public int LivroId { get; set; }
        public GetLivroDto livrosAgendados { get; set; }
    }
}
