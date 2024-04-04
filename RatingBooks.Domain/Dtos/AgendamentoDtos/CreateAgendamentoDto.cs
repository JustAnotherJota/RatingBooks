using System.ComponentModel.DataAnnotations;

namespace RatingBooks.Domain.Dtos.AgendamentoDtos
{
    public class CreateAgendamentoDto
    {
        [Required]
        public int LivroId { get; set; }
        [Required]
        public DateTime AgendamentoData { get; set; }
    }
}
