using System.ComponentModel.DataAnnotations;

namespace RatingBooks.Domain.Dtos.LivroDtos
{
    public class DeleteLivroDto
    {
        [Required]
        public int Id { get; set; }
    }
}
