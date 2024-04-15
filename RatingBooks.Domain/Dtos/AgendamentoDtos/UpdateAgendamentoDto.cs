using System.ComponentModel.DataAnnotations;

namespace RatingBooks.Domain.Dtos.AgendamentoDtos
{
    public class UpdateAgendamentoDto
    {
        [Required]
        public DateTime AgendamentoData { get; set; }
    }
}
