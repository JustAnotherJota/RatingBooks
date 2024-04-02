using RatingBooks.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RatingBooks.Data.Dtos.AgendamentoDtos
{
    public class CreateAgendamentoDto
    {
        [Required]
        public int LivroId { get; set; }
        [Required]
        public DateTime AgendamentoData { get; set; }
    }
}
