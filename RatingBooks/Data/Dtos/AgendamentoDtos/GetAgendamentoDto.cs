using RatingBooks.Data.Dtos.LivroDtos;
using RatingBooks.Models;
using System.ComponentModel.DataAnnotations;

namespace RatingBooks.Data.Dtos.AgendamentoDtos
{
    public class GetAgendamentoDto
    {
        [Required]
        public DateTime AgendamentoData { get; set; }
        public int LivroId { get; set; }
        public GetLivroDto livrosAgendados { get; set; }
    }
}
